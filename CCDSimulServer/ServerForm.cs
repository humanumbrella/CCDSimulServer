using System;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Diagnostics;
using System.IO;
using ManPol;

namespace CCDSimulServer
{
    public partial class ServerForm : Form
    {
        private int port = 0;
        private Socket _serverSocket,_clientSocket;
        private byte[] _buffer;
        FolderBrowserDialog fbd = new FolderBrowserDialog();

        private MaxIm.CCDCamera ccd;
        private ObsRun or = new ObsRun(@"C:\Users\jmoore\Dropbox\Polarimetry\", "GRB160428", 1, 1.0);
        //private string maximpath = @"C:\Program Files (x86)\Diffraction Limited\MaxIm DL V5\MaxIm_DL.exe";
        
        //private string savepath = @"C:\Users\jmo\Dropbox\Polarimetry\Target1\";
        //private string clientsavepath = @"C:\Users\jmoore\Dropbox\Polarimetry\Target1\";
        private string savedClientSavePath = string.Empty;
        private int orderPos = -1;
        private string filter = string.Empty;

        private string targetName = string.Empty;
        

        //FOR P8 SERVER
        private string maximpath = @"C:\Program Files\Diffraction Limited\MaxIm DL V5\MaxIm_DL.exe";
        private string savepath = @"C:\Skynet-Testing\";
        private string clientsavepath = @"C:\Skynet-Testing\Target1\";
        

        mainForm mp;

        public ServerForm()
        {
            InitializeComponent();
            //if maxim isn't open - let's open it.
            Process[] localByName = Process.GetProcessesByName("MaxIm_DL");

            Console.WriteLine(Properties.Settings.Default.ClientSavePath);
            Console.WriteLine(Properties.Settings.Default.SavePath);
            Console.WriteLine(Properties.Settings.Default.MaximPath);


            savepath = Properties.Settings.Default.SavePath;
            clientsavepath = Properties.Settings.Default.ClientSavePath;
            maximpath = Properties.Settings.Default.MaximPath;

            while (true)
            {
                try
                {
                    if (localByName.Length == 0)
                    {
                        Process.Start(maximpath);
                        break;
                    }
                    break;

                }
                catch (Exception error)
                {
                    Console.WriteLine(error.ToString());
                    MessageBox.Show("Whoops!  Couldn't find MaximDL - choose the folder it lives under please!");
                    DialogResult result = fbd.ShowDialog();
                    if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        maximpath = fbd.SelectedPath + "\\MaxIm_DL.exe";
                    }

                    Properties.Settings.Default["MaximPath"] = maximpath;
                    Console.WriteLine("Reset MaximPath variable to: \n");
                    Console.WriteLine(Properties.Settings.Default.MaximPath);
                    Console.WriteLine(maximpath);
                    Properties.Settings.Default.Save(); // Saves settings in application configuration file
                    Console.WriteLine("Maxim path saved!");
                }
            }
            
        }

        private void StartServer(int port)
        {
            try
            {
                _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
                _serverSocket.Listen(0);
                _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
                AppendToTextBox("Server started, waiting for connections!");
                toggleServe(true);
                toggleExpose(false);
                AppendToTextBox("save path: \n" + Properties.Settings.Default.SavePath);
                AppendToTextBox("client save path: \n" + Properties.Settings.Default.ClientSavePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                _clientSocket = _serverSocket.EndAccept(ar);
                _buffer = new byte[_clientSocket.ReceiveBufferSize];
                _clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(receiveCallback), null);
                IPEndPoint clientIP = (IPEndPoint)_clientSocket.RemoteEndPoint;
                AppendToTextBox("Client " + clientIP.Address.ToString() + " connected, waiting for messages!");
                clientLblUpdate(clientIP.Address.ToString());

                _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void receiveCallback(IAsyncResult ar)
        {
            try
            {
                int received = _clientSocket.EndReceive(ar);

                if (received == 0)
                {
                    IPEndPoint clientIP = (IPEndPoint)_clientSocket.LocalEndPoint;
                    AppendToTextBox("Client " + clientIP.Address.ToString() + " disconnected!");
                    clientLblUpdate("None");
                    return; //eliminate the beginreceive below... bc client likely disconnected
                }
                Array.Resize(ref _buffer, received);
                string text = Encoding.ASCII.GetString(_buffer);
                //handle the packet
                AppendToTextBox(text);
                Array.Resize(ref _buffer, _clientSocket.ReceiveBufferSize);
                //restart receive
                _clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(receiveCallback), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void AppendToTextBox(string text)
        {
            MethodInvoker invoker = new MethodInvoker(delegate
            {
                tbLog.AppendText(text + "\r\n");
                if (text.Contains("connected")){
                    if (text.Contains("dis")){
                        btnSyncCams.Enabled = false;
                        btnDiscCams.Enabled = false;
                        ccd.LinkEnabled = false;
                        AppendToTextBox("Server Camera Is Disconnected!");
                        toggleExpose(false);
                    }
                    else{
                        toggleSync(true);
                    }
                }
            });
            this.Invoke(invoker);
        }

        private void clientLblUpdate(string text)
        {
            MethodInvoker invoker = new MethodInvoker(delegate
            {
                lblClient.Text = text;
            });
            this.Invoke(invoker);
        }

        private void btnServe_Click(object sender, EventArgs e)
        {
            Int32.TryParse(tbPort.Text, out port);
            StartServer(port);            
        }

        private void btnSyncCams_Click(object sender, EventArgs e)
        {
            string syncCam = "setup_ccd";
            byte[] sync = Encoding.ASCII.GetBytes(syncCam);
            _clientSocket.Send(sync);

            try
            {
                ccd = new MaxIm.CCDCamera();
                ccd.LinkEnabled = true;
                ccd.CoolerOn = true;
                AppendToTextBox("Server Camera Is Ready!");
                toggleSync(false);
                toggleExpose(true);
            }
            catch (Exception ex)
            {
                AppendToTextBox("cant connect to server camera");
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnExposeCams_Click(object sender, EventArgs e)
        {
            ushort epsilon = 0;
            double expTime = 0;
            UInt16.TryParse(tbTimeBeforeExpose.Text, out epsilon);
            Double.TryParse(tbExposureLength.Text, out expTime);
            toggleExpose(false);
            if (mp != null)
            {
                switch (mp.TrayPos){
                    case 0:
                        filter = "V";
                        orderPos = mp.VPos;
                        break;
                    case 1:
                        filter = "O";
                        orderPos = -1;
                        break;
                    case 2:
                        filter = "I";
                        orderPos = mp.IPos;
                        break;
                }
            }
            string saveInfo = clientsavepath + "," + filter + "," + orderPos;
            Console.WriteLine(saveInfo);
            ExposePackage exposure = new ExposePackage(chkDark.Checked, epsilon, expTime, chkSave.Checked, saveInfo);


            byte[] buffer = exposure.toByteArray();
            _clientSocket.Send(buffer);

            waitFor(exposure.epsilon);

            try
            {
                exposeFor(exposure.isDark, exposure.expTime);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            

            while (!ccd.ImageReady)
            {
                //wait
            }
            //lets get some info on exp time (datetime and jd[maybe more accuracy])
            
            string dt = string.Empty;
            double jd = 0.0;
            dt = ccd.Document.GetFITSKey("DATE-OBS");
            AppendToTextBox("server_cam: " + dt);
            jd = ccd.Document.GetFITSKey("JD");
            AppendToTextBox("server_cam: " + jd.ToString());

            /*
            string fireCam = "expose_ccd";
            byte[] expose = Encoding.ASCII.GetBytes(fireCam);
            _clientSocket.Send(expose);

            ccd.Expose(1, 1, 0);*/
            toggleExpose(true);
        }
        //directory,expSets,expLen,band
        public void startSequence(string dir,int numSets, double expLen, bool band)
        {
            toggleExpose(false);
            tbExposureLength.Text = expLen.ToString();
            AppendToTextBox("Saving to " + dir);
            savedClientSavePath = clientsavepath;


            checkForDirectory(savepath+dir);
            clientsavepath += dir;

            AppendToTextBox(numSets.ToString() + " sets of images (x4, so " + (numSets * 8).ToString() + " total images.)");

            targetName = dir;

            //int orderPos;
            bool orderDir = true;
            //assume v;
            filter="V";
            orderPos = mp.VPos;
            int[] exposeOrder = new int[] {0,2,1,3};
            int[] reverseOrder = new int[] {3,1,2,0};

            

            if (band){
                filter = "I";
                orderPos = mp.IPos;
            }

            
            AppendToTextBox("each for " + expLen.ToString() + " seconds in "+filter+" filter.");
            waitFor(3);

            //need to determine order
            if (orderPos == 0)
            {
                //aka going to go 0>45>22.5>67.5
                orderDir = true;
            }
            else
            {
                //aka going to go 67.5>22.5>45>0
                orderDir = false;
            }

            switch (filter)
            {
                case "V":
                    for (int i = 0; i < numSets; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            mp.getStatus();
                            //change HWP
                            if (orderDir)
                            {
                                //increasing
                                mp.VPos = exposeOrder[j];
                                Console.WriteLine("Imaging V from 0>67.5");
                                /*
                                while (mp.VPos != j)
                                {
                                    mp.getStatus();
                                    waitFor(1);
                                }*/
                            }
                            else
                            {
                                mp.VPos = reverseOrder[j];
                                Console.WriteLine("Imaging V from 67.5>0");
                                /*
                                while (mp.VPos != 3-j)
                                {
                                    mp.getStatus();
                                    waitFor(1);
                                }*/
                            }

                            btnExposeCams_Click(this, new EventArgs());
                        }
                        //recheck orderDir after first set

                        if (filter == "V")
                        {
                            orderPos = mp.VPos;
                        }
                        else
                        {
                            orderPos = mp.IPos;
                        }


                        //need to determine order
                        if (orderPos == 0)
                        {
                            //aka going to go 0>45>22.5>67.5
                            orderDir = true;
                        }
                        else
                        {
                            //aka going to go 67.5>22.5>45>0
                            orderDir = false;
                        }
                    }
                    break;
                case "I":
                    for (int i = 0; i < numSets; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            mp.getStatus();
                            //change HWP
                            if (orderDir)
                            {
                                //increasing
                                mp.IPos = j;
                                Console.WriteLine("Imaging I from 0>67.5");
                            }
                            else
                            {
                                mp.IPos = 3 - j;
                                Console.WriteLine("Imaging I from 67.5>0");
                            }

                            btnExposeCams_Click(this, new EventArgs());
                        }
                    }
                    break;
            }

            

            toggleExpose(true);
            targetName = string.Empty;
            //revert
            clientsavepath = savedClientSavePath;
            savedClientSavePath = string.Empty;
            orderPos = -1;
            filter = string.Empty;
        }

        private void waitFor(ushort s)
        {
            Thread.Sleep(s*1000);
        }
        private void exposeFor(bool dark, double exp)
        {

            ccd.Expose(exp, Convert.ToInt16(!dark));

            while (!ccd.ImageReady)
            {
                //wait
                //rotate the HWP to the next spot, it is possible to do it while waiting on readout!
            }
            AppendToTextBox("Server Camera Exposure Is Done!");


            string dt = string.Empty;
            dt = ccd.Document.GetFITSKey("DATE-OBS");
            checkForDirectory(savepath);
            if (chkSave.Checked)
            {
                saveImage(targetName, dt.Replace(":", "-"), savepath);
            }
            else
            {
                AppendToTextBox("Server Camera Exposure *not* saved!");
            }
        }
        private void saveImage(string obsname, string imagename, string path)
        {
            string testing = string.Empty;
            if (orderPos > -1)
            {
                testing = path + targetName + imagename + "-" + filter + "-" + orderPos + "-U42.fit";

            }
            else
            {
                testing = path + targetName + imagename + "-U42.fit";
            }
            ccd.SaveImage(testing);
            //ccd.SaveImage(path + targetName + imagename + "-U42.fit");
            Console.WriteLine(testing);
            AppendToTextBox("Server Camera Exposure Saved!");
            AppendToTextBox("Server:" + savepath + targetName);
        }

        private void checkForDirectory(string fp){
            if (!Directory.Exists(fp))
            {
                Directory.CreateDirectory(fp);
            }
        }
        private void toggleServe(bool change)
        {
            if (change)
            {
                btnServe.Enabled = false;
                btnStopServe.Enabled = true;
            }
            else
            {
                btnServe.Enabled = true;
                btnStopServe.Enabled = false;
            }
            return;
        }

        private void toggleSync(bool change)
        {
            if (change)
            {
                btnSyncCams.Enabled = true;
                btnDiscCams.Enabled = false;
            }
            else
            {
                btnSyncCams.Enabled = false;
                btnDiscCams.Enabled = true;
            }
            return;
        }

        private void toggleExpose(bool change)
        {
            if (change)
            {
                btnExposeCams.Enabled = true;
                tbExposureLength.Enabled = true;
                chkDark.Enabled = true;
                tbTimeBeforeExpose.Enabled = true;
                chkSave.Enabled = true;

                lblX.Enabled = true;
                lblY.Enabled = true;
                tbX.Enabled = true;
                tbY.Enabled = true;
                btnResetFrame.Enabled = true;
                btnSubFrame.Enabled = true;
            }
            else
            {
                btnExposeCams.Enabled = false;
                tbExposureLength.Enabled = false;
                chkDark.Enabled = false;
                tbTimeBeforeExpose.Enabled = false;
                chkSave.Enabled = false;
                lblX.Enabled = false;
                lblY.Enabled = false;
                tbX.Enabled = false;
                tbY.Enabled = false;
                btnResetFrame.Enabled = false;
                btnSubFrame.Enabled = false;
            }
            return;
        }
        private void btnStopServe_Click(object sender, EventArgs e)
        {
            _clientSocket.Shutdown(SocketShutdown.Both);
            _serverSocket.Close();
            AppendToTextBox("Stopped serving!");
            
            toggleServe(false);
            btnSyncCams.Enabled = false;
            btnDiscCams.Enabled = false;
            toggleExpose(false);
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            Int32.TryParse(tbPort.Text, out port);
            StartServer(port);            
        }

        private void btnDiscCams_Click(object sender, EventArgs e)
        {
            string syncCam = "teardown_ccd";
            byte[] sync = Encoding.ASCII.GetBytes(syncCam);
            _clientSocket.Send(sync);

            try
            {
                ccd.CoolerOn = false;
                ccd.LinkEnabled = false;
                AppendToTextBox("Server Camera Is Disconnected!");
                toggleSync(true);
                toggleExpose(false);
            }
            catch (Exception ex)
            {
                AppendToTextBox("cant connect to server camera");
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void observingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ObservingRun orfrm = new ObservingRun(this);
            orfrm.Show();
            Console.WriteLine(or);
        }

        private void polarimeterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mp = new mainForm(this,true,"COM9");
            mp.Show();
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void serverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fbd.SelectedPath = savepath;

            DialogResult result = fbd.ShowDialog();
            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                savepath = fbd.SelectedPath + "\\";
            }

            Properties.Settings.Default["SavePath"] = savepath;
            Properties.Settings.Default.Save(); // Saves settings in application configuration file

            AppendToTextBox("Server Path Updated:");
            AppendToTextBox(savepath);
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult result = InputBox("Enter directory for the client machine", "Directory:  ", ref clientsavepath);

            Properties.Settings.Default["ClientSavePath"] = clientsavepath;
            Properties.Settings.Default.Save(); // Saves settings in application configuration file

            AppendToTextBox("Client Path Updated:");
            AppendToTextBox(clientsavepath);
            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBox1 box = new AboutBox1())
            {
                box.ShowDialog(this);
            }
        }


        private void btnSubFrame_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;

            Int32.TryParse(tbX.Text, out x);
            ccd.StartX = (short)x;
            ccd.NumX = 1024;
            Int32.TryParse(tbY.Text, out y);
            ccd.StartY = (short)y;
            ccd.NumY = 1024;

            AppendToTextBox("Set subframing up!");
            AppendToTextBox(x+" , "+y);
            AppendToTextBox("Now 1024 x 1024");
        }

        private void btnResetFrame_Click(object sender, EventArgs e)
        {
            ccd.StartX = 0;
            ccd.StartY = 0;
            ccd.NumX = 2048;
            ccd.NumY = 2048;

            AppendToTextBox("Cleared subframing!");
        }

    }
}

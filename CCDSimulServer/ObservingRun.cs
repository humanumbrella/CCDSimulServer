using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCDSimulServer
{
    public partial class ObservingRun : Form
    {
        private string defaultSavePath = @"C:\Users\jmo\Dropbox\Polarimetry\";
        private string defaultName = "GRB160428";
        private int defaultExpSets = 1;
        private double defaultExpLen = 1.0;
        FolderBrowserDialog fbd = new FolderBrowserDialog();

        private int maxExpSets = 100;
        private double minExposeTime = 0.03;
        private double maxExposeTime = 300;

        private ServerForm mainForm;


        public ObservingRun()
        {
            InitializeComponent();
        }

        public ObservingRun(ServerForm sender)
        {
            InitializeComponent();
            mainForm = sender;
        }

        private void ObservingRun_Load(object sender, EventArgs e)
        {

        }

        private void btnBeginRun_Click(object sender, EventArgs e)
        {

            //create class of params and return it to the previous form.
            string ex = "Directory name for data: \"" + tbName.Text + "\\\"" ;
            string directory = tbName.Text+"\\";

            ushort expSets = 0;
            double expLen = 0.0;
            bool band = false;

            UInt16.TryParse(tbExpSets.Text, out expSets);
            Double.TryParse(tbExpLen.Text, out expLen);

            if (expSets > maxExpSets)
            {
                MessageBox.Show("Can't do that many sets.\nMax number of sets is " + maxExpSets.ToString() + ".", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (expLen < minExposeTime){
                MessageBox.Show("Can't do that short of an exposure.\nMinimum exposure time is " + minExposeTime.ToString() + " seconds.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (expLen > maxExposeTime){
                MessageBox.Show("Can't do that long of an exposure.\nMaximum exposure time is " + maxExposeTime.ToString() + " seconds.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ex += "\nExposure sets: " + tbExpSets.Text + " (total of " + 4 * expSets + " exposures) ";
            ex += "for " + tbExpLen.Text + " second(s) ";
            if (rbV.Checked == true)
            {
                ex += "in V band.";
                band = false;
            }
            else
            {
                ex += "in I band.";
                band = true;
            }

            //MessageBox.Show(ex, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            mainForm.startSequence(directory,expSets,expLen,band);
        }


        private void btnDefaults_Click(object sender, EventArgs e)
        {
            tbRootDir.Text = defaultSavePath;
            tbName.Text = defaultName;
            tbExpSets.Text = defaultExpSets.ToString();
            tbExpLen.Text = defaultExpLen.ToString();
            rbI.Checked = false;
            rbV.Checked = true;
        }

        private void tbRootDir_Click(object sender, EventArgs e)
        {
            DialogResult result = fbd.ShowDialog();
            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                tbRootDir.Text = fbd.SelectedPath+"\\";
            }
        }

        private void tbExpLen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (Char.IsControl(e.KeyChar)) return;
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.Contains('.') == false)) return;
            if ((e.KeyChar == '.') && ((sender as TextBox).SelectionLength == (sender as TextBox).TextLength)) return;
            e.Handled = true;
        }

        private void tbExpSets_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            if (Char.IsControl(e.KeyChar)) return;
            e.Handled = true;
        }

    }
}

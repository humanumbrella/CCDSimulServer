namespace CCDSimulServer
{
    partial class ServerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnServe = new System.Windows.Forms.Button();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.btnSyncCams = new System.Windows.Forms.Button();
            this.btnExposeCams = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbExposureLength = new System.Windows.Forms.TextBox();
            this.chkDark = new System.Windows.Forms.CheckBox();
            this.tbTimeBeforeExpose = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDiscCams = new System.Windows.Forms.Button();
            this.lblCC = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.btnStopServe = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setSavePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polarimeterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.observingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkSave = new System.Windows.Forms.CheckBox();
            this.tbY = new System.Windows.Forms.TextBox();
            this.tbX = new System.Windows.Forms.TextBox();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.btnResetFrame = new System.Windows.Forms.Button();
            this.btnSubFrame = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnServe
            // 
            this.btnServe.Location = new System.Drawing.Point(128, 38);
            this.btnServe.Margin = new System.Windows.Forms.Padding(4);
            this.btnServe.Name = "btnServe";
            this.btnServe.Size = new System.Drawing.Size(57, 28);
            this.btnServe.TabIndex = 1;
            this.btnServe.Text = "Serve";
            this.btnServe.UseVisualStyleBackColor = true;
            this.btnServe.Click += new System.EventHandler(this.btnServe_Click);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(59, 41);
            this.tbPort.Margin = new System.Windows.Forms.Padding(4);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(61, 22);
            this.tbPort.TabIndex = 2;
            this.tbPort.Text = "37204";
            // 
            // tbLog
            // 
            this.tbLog.AcceptsReturn = true;
            this.tbLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLog.BackColor = System.Drawing.SystemColors.Window;
            this.tbLog.Location = new System.Drawing.Point(18, 168);
            this.tbLog.Margin = new System.Windows.Forms.Padding(4);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.Size = new System.Drawing.Size(579, 274);
            this.tbLog.TabIndex = 3;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(13, 45);
            this.lblPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(38, 17);
            this.lblPort.TabIndex = 4;
            this.lblPort.Text = "Port:";
            // 
            // btnSyncCams
            // 
            this.btnSyncCams.Enabled = false;
            this.btnSyncCams.Location = new System.Drawing.Point(18, 76);
            this.btnSyncCams.Margin = new System.Windows.Forms.Padding(4);
            this.btnSyncCams.Name = "btnSyncCams";
            this.btnSyncCams.Size = new System.Drawing.Size(169, 27);
            this.btnSyncCams.TabIndex = 5;
            this.btnSyncCams.Text = "Sync Cameras";
            this.btnSyncCams.UseVisualStyleBackColor = true;
            this.btnSyncCams.Click += new System.EventHandler(this.btnSyncCams_Click);
            // 
            // btnExposeCams
            // 
            this.btnExposeCams.Location = new System.Drawing.Point(387, 130);
            this.btnExposeCams.Margin = new System.Windows.Forms.Padding(4);
            this.btnExposeCams.Name = "btnExposeCams";
            this.btnExposeCams.Size = new System.Drawing.Size(100, 25);
            this.btnExposeCams.TabIndex = 11;
            this.btnExposeCams.Text = "Expose";
            this.btnExposeCams.UseVisualStyleBackColor = true;
            this.btnExposeCams.Click += new System.EventHandler(this.btnExposeCams_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 109);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Exposure Length (sec)";
            // 
            // tbExposureLength
            // 
            this.tbExposureLength.Location = new System.Drawing.Point(250, 130);
            this.tbExposureLength.Margin = new System.Windows.Forms.Padding(4);
            this.tbExposureLength.Name = "tbExposureLength";
            this.tbExposureLength.Size = new System.Drawing.Size(129, 22);
            this.tbExposureLength.TabIndex = 10;
            this.tbExposureLength.Text = "1";
            // 
            // chkDark
            // 
            this.chkDark.AutoSize = true;
            this.chkDark.Location = new System.Drawing.Point(182, 130);
            this.chkDark.Margin = new System.Windows.Forms.Padding(4);
            this.chkDark.Name = "chkDark";
            this.chkDark.Size = new System.Drawing.Size(60, 21);
            this.chkDark.TabIndex = 9;
            this.chkDark.Text = "Dark";
            this.chkDark.UseVisualStyleBackColor = true;
            // 
            // tbTimeBeforeExpose
            // 
            this.tbTimeBeforeExpose.Location = new System.Drawing.Point(18, 130);
            this.tbTimeBeforeExpose.Margin = new System.Windows.Forms.Padding(4);
            this.tbTimeBeforeExpose.Name = "tbTimeBeforeExpose";
            this.tbTimeBeforeExpose.Size = new System.Drawing.Size(156, 22);
            this.tbTimeBeforeExpose.TabIndex = 8;
            this.tbTimeBeforeExpose.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 109);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Time Before Expose (s)";
            // 
            // btnDiscCams
            // 
            this.btnDiscCams.Enabled = false;
            this.btnDiscCams.Location = new System.Drawing.Point(195, 74);
            this.btnDiscCams.Margin = new System.Windows.Forms.Padding(4);
            this.btnDiscCams.Name = "btnDiscCams";
            this.btnDiscCams.Size = new System.Drawing.Size(169, 27);
            this.btnDiscCams.TabIndex = 6;
            this.btnDiscCams.Text = "Disc Cameras";
            this.btnDiscCams.UseVisualStyleBackColor = true;
            this.btnDiscCams.Click += new System.EventHandler(this.btnDiscCams_Click);
            // 
            // lblCC
            // 
            this.lblCC.AutoSize = true;
            this.lblCC.Location = new System.Drawing.Point(273, 44);
            this.lblCC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCC.Name = "lblCC";
            this.lblCC.Size = new System.Drawing.Size(119, 17);
            this.lblCC.TabIndex = 12;
            this.lblCC.Text = "Connected Client:";
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(402, 44);
            this.lblClient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(42, 17);
            this.lblClient.TabIndex = 13;
            this.lblClient.Text = "None";
            // 
            // btnStopServe
            // 
            this.btnStopServe.Location = new System.Drawing.Point(191, 38);
            this.btnStopServe.Name = "btnStopServe";
            this.btnStopServe.Size = new System.Drawing.Size(82, 28);
            this.btnStopServe.TabIndex = 18;
            this.btnStopServe.Text = "StopServe";
            this.btnStopServe.UseVisualStyleBackColor = true;
            this.btnStopServe.Click += new System.EventHandler(this.btnStopServe_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.scriptsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(616, 28);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setSavePathToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // setSavePathToolStripMenuItem
            // 
            this.setSavePathToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverToolStripMenuItem,
            this.clientToolStripMenuItem});
            this.setSavePathToolStripMenuItem.Name = "setSavePathToolStripMenuItem";
            this.setSavePathToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.setSavePathToolStripMenuItem.Text = "Set Save Path";
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.serverToolStripMenuItem.Text = "Server";
            this.serverToolStripMenuItem.Click += new System.EventHandler(this.serverToolStripMenuItem_Click);
            // 
            // clientToolStripMenuItem
            // 
            this.clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            this.clientToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.clientToolStripMenuItem.Text = "Client";
            this.clientToolStripMenuItem.Click += new System.EventHandler(this.clientToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // scriptsToolStripMenuItem
            // 
            this.scriptsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.polarimeterToolStripMenuItem,
            this.observingToolStripMenuItem});
            this.scriptsToolStripMenuItem.Name = "scriptsToolStripMenuItem";
            this.scriptsToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.scriptsToolStripMenuItem.Text = "Scripts";
            // 
            // polarimeterToolStripMenuItem
            // 
            this.polarimeterToolStripMenuItem.Name = "polarimeterToolStripMenuItem";
            this.polarimeterToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.polarimeterToolStripMenuItem.Text = "Polarimeter";
            this.polarimeterToolStripMenuItem.Click += new System.EventHandler(this.polarimeterToolStripMenuItem_Click);
            // 
            // observingToolStripMenuItem
            // 
            this.observingToolStripMenuItem.Name = "observingToolStripMenuItem";
            this.observingToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.observingToolStripMenuItem.Text = "Observing Run";
            this.observingToolStripMenuItem.Click += new System.EventHandler(this.observingToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // chkSave
            // 
            this.chkSave.AutoSize = true;
            this.chkSave.Checked = true;
            this.chkSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSave.Location = new System.Drawing.Point(494, 130);
            this.chkSave.Name = "chkSave";
            this.chkSave.Size = new System.Drawing.Size(111, 21);
            this.chkSave.TabIndex = 20;
            this.chkSave.Text = "Save Images";
            this.chkSave.UseVisualStyleBackColor = true;
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(143, 478);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(100, 22);
            this.tbY.TabIndex = 22;
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(25, 478);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(100, 22);
            this.tbX.TabIndex = 21;
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(140, 458);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(17, 17);
            this.lblY.TabIndex = 26;
            this.lblY.Text = "Y";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(22, 458);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(17, 17);
            this.lblX.TabIndex = 25;
            this.lblX.Text = "X";
            // 
            // btnResetFrame
            // 
            this.btnResetFrame.Location = new System.Drawing.Point(363, 477);
            this.btnResetFrame.Name = "btnResetFrame";
            this.btnResetFrame.Size = new System.Drawing.Size(160, 23);
            this.btnResetFrame.TabIndex = 24;
            this.btnResetFrame.Text = "Reset Full Frame";
            this.btnResetFrame.UseVisualStyleBackColor = true;
            this.btnResetFrame.Click += new System.EventHandler(this.btnResetFrame_Click);
            // 
            // btnSubFrame
            // 
            this.btnSubFrame.Location = new System.Drawing.Point(266, 478);
            this.btnSubFrame.Name = "btnSubFrame";
            this.btnSubFrame.Size = new System.Drawing.Size(80, 23);
            this.btnSubFrame.TabIndex = 23;
            this.btnSubFrame.Text = "Subframe";
            this.btnSubFrame.UseVisualStyleBackColor = true;
            this.btnSubFrame.Click += new System.EventHandler(this.btnSubFrame_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 602);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.tbX);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.btnResetFrame);
            this.Controls.Add(this.btnSubFrame);
            this.Controls.Add(this.chkSave);
            this.Controls.Add(this.btnStopServe);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.lblCC);
            this.Controls.Add(this.btnDiscCams);
            this.Controls.Add(this.tbTimeBeforeExpose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkDark);
            this.Controls.Add(this.tbExposureLength);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExposeCams);
            this.Controls.Add(this.btnSyncCams);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.btnServe);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ServerForm";
            this.Text = "CCD Simultaneous Server";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnServe;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Button btnSyncCams;
        private System.Windows.Forms.Button btnExposeCams;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbExposureLength;
        private System.Windows.Forms.CheckBox chkDark;
        private System.Windows.Forms.TextBox tbTimeBeforeExpose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDiscCams;
        private System.Windows.Forms.Label lblCC;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.Button btnStopServe;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polarimeterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem observingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkSave;
        private System.Windows.Forms.ToolStripMenuItem setSavePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientToolStripMenuItem;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Button btnResetFrame;
        private System.Windows.Forms.Button btnSubFrame;
    }
}


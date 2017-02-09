namespace CCDSimulServer
{
    partial class ObservingRun
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbExpSets = new System.Windows.Forms.TextBox();
            this.tbExpLen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBeginRun = new System.Windows.Forms.Button();
            this.tbRootDir = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDefaults = new System.Windows.Forms.Button();
            this.rbV = new System.Windows.Forms.RadioButton();
            this.rbI = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Target Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Imaging Band:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Num. Exposures:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Exposure Length:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(165, 49);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(167, 22);
            this.tbName.TabIndex = 1;
            this.tbName.Text = "GRB160428";
            // 
            // tbExpSets
            // 
            this.tbExpSets.Location = new System.Drawing.Point(165, 104);
            this.tbExpSets.Name = "tbExpSets";
            this.tbExpSets.Size = new System.Drawing.Size(39, 22);
            this.tbExpSets.TabIndex = 4;
            this.tbExpSets.Text = "1";
            this.tbExpSets.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbExpSets_KeyPress);
            // 
            // tbExpLen
            // 
            this.tbExpLen.Location = new System.Drawing.Point(165, 133);
            this.tbExpLen.Name = "tbExpLen";
            this.tbExpLen.Size = new System.Drawing.Size(77, 22);
            this.tbExpLen.TabIndex = 5;
            this.tbExpLen.Text = "1";
            this.tbExpLen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbExpLen_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(248, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "x4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(248, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "seconds";
            // 
            // btnBeginRun
            // 
            this.btnBeginRun.Location = new System.Drawing.Point(255, 165);
            this.btnBeginRun.Name = "btnBeginRun";
            this.btnBeginRun.Size = new System.Drawing.Size(77, 34);
            this.btnBeginRun.TabIndex = 6;
            this.btnBeginRun.Text = "Go";
            this.btnBeginRun.UseVisualStyleBackColor = true;
            this.btnBeginRun.Click += new System.EventHandler(this.btnBeginRun_Click);
            // 
            // tbRootDir
            // 
            this.tbRootDir.Location = new System.Drawing.Point(165, 21);
            this.tbRootDir.Name = "tbRootDir";
            this.tbRootDir.Size = new System.Drawing.Size(167, 22);
            this.tbRootDir.TabIndex = 0;
            this.tbRootDir.Text = "C:\\Users\\jmo\\Dropbox\\Polarimetry\\";
            this.tbRootDir.Visible = false;
            this.tbRootDir.Click += new System.EventHandler(this.tbRootDir_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Root Directory:";
            this.label7.Visible = false;
            // 
            // btnDefaults
            // 
            this.btnDefaults.Location = new System.Drawing.Point(45, 165);
            this.btnDefaults.Name = "btnDefaults";
            this.btnDefaults.Size = new System.Drawing.Size(84, 34);
            this.btnDefaults.TabIndex = 7;
            this.btnDefaults.Text = "Defaults";
            this.btnDefaults.UseVisualStyleBackColor = true;
            this.btnDefaults.Click += new System.EventHandler(this.btnDefaults_Click);
            // 
            // rbV
            // 
            this.rbV.AutoSize = true;
            this.rbV.Checked = true;
            this.rbV.Location = new System.Drawing.Point(165, 80);
            this.rbV.Name = "rbV";
            this.rbV.Size = new System.Drawing.Size(38, 21);
            this.rbV.TabIndex = 2;
            this.rbV.TabStop = true;
            this.rbV.Text = "V";
            this.rbV.UseVisualStyleBackColor = true;
            // 
            // rbI
            // 
            this.rbI.AutoSize = true;
            this.rbI.Location = new System.Drawing.Point(211, 80);
            this.rbI.Name = "rbI";
            this.rbI.Size = new System.Drawing.Size(32, 21);
            this.rbI.TabIndex = 3;
            this.rbI.Text = "I";
            this.rbI.UseVisualStyleBackColor = true;
            // 
            // ObservingRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 214);
            this.Controls.Add(this.rbV);
            this.Controls.Add(this.rbI);
            this.Controls.Add(this.btnDefaults);
            this.Controls.Add(this.tbRootDir);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnBeginRun);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbExpLen);
            this.Controls.Add(this.tbExpSets);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ObservingRun";
            this.Text = "Observing Run Params";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbExpSets;
        private System.Windows.Forms.TextBox tbExpLen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBeginRun;
        private System.Windows.Forms.TextBox tbRootDir;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDefaults;
        private System.Windows.Forms.RadioButton rbV;
        private System.Windows.Forms.RadioButton rbI;
    }
}
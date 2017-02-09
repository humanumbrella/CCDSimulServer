namespace CCDSimulServer
{
    partial class SubFraming
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
            this.btnSubFrame = new System.Windows.Forms.Button();
            this.btnResetFrame = new System.Windows.Forms.Button();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.tbX = new System.Windows.Forms.TextBox();
            this.tbY = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSubFrame
            // 
            this.btnSubFrame.Location = new System.Drawing.Point(265, 39);
            this.btnSubFrame.Name = "btnSubFrame";
            this.btnSubFrame.Size = new System.Drawing.Size(80, 23);
            this.btnSubFrame.TabIndex = 0;
            this.btnSubFrame.Text = "Subframe";
            this.btnSubFrame.UseVisualStyleBackColor = true;
            // 
            // btnResetFrame
            // 
            this.btnResetFrame.Location = new System.Drawing.Point(362, 38);
            this.btnResetFrame.Name = "btnResetFrame";
            this.btnResetFrame.Size = new System.Drawing.Size(160, 23);
            this.btnResetFrame.TabIndex = 1;
            this.btnResetFrame.Text = "Reset Full Frame";
            this.btnResetFrame.UseVisualStyleBackColor = true;
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(21, 19);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(17, 17);
            this.lblX.TabIndex = 2;
            this.lblX.Text = "X";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(139, 19);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(17, 17);
            this.lblY.TabIndex = 3;
            this.lblY.Text = "Y";
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(24, 39);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(100, 22);
            this.tbX.TabIndex = 0;
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(142, 39);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(100, 22);
            this.tbY.TabIndex = 1;
            // 
            // SubFraming
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 81);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.tbX);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.btnResetFrame);
            this.Controls.Add(this.btnSubFrame);
            this.Name = "SubFraming";
            this.Text = "Sub Frame the U42 (2k) camera!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubFrame;
        private System.Windows.Forms.Button btnResetFrame;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.TextBox tbY;
    }
}
namespace SubnetCalculator
{
    partial class Form1
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
            this.tbIpAddress = new System.Windows.Forms.TextBox();
            this.btApply = new System.Windows.Forms.Button();
            this.presenterPanel = new System.Windows.Forms.Panel();
            this.btGetLocalIP = new System.Windows.Forms.Button();
            this.btPing = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // tbIpAddress
            // 
            this.tbIpAddress.Location = new System.Drawing.Point(17, 24);
            this.tbIpAddress.Name = "tbIpAddress";
            this.tbIpAddress.Size = new System.Drawing.Size(116, 20);
            this.tbIpAddress.TabIndex = 0;
            this.tbIpAddress.Text = "192.168.10.44/29";
            // 
            // btApply
            // 
            this.btApply.Location = new System.Drawing.Point(139, 22);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(75, 23);
            this.btApply.TabIndex = 1;
            this.btApply.Text = "Apply";
            this.btApply.UseVisualStyleBackColor = true;
            this.btApply.Click += new System.EventHandler(this.btApply_Click);
            // 
            // presenterPanel
            // 
            this.presenterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.presenterPanel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.presenterPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.presenterPanel.Location = new System.Drawing.Point(12, 64);
            this.presenterPanel.Name = "presenterPanel";
            this.presenterPanel.Size = new System.Drawing.Size(446, 381);
            this.presenterPanel.TabIndex = 5;
            // 
            // btGetLocalIP
            // 
            this.btGetLocalIP.Location = new System.Drawing.Point(220, 22);
            this.btGetLocalIP.Name = "btGetLocalIP";
            this.btGetLocalIP.Size = new System.Drawing.Size(103, 23);
            this.btGetLocalIP.TabIndex = 6;
            this.btGetLocalIP.Text = "Get local address";
            this.btGetLocalIP.UseVisualStyleBackColor = true;
            this.btGetLocalIP.Click += new System.EventHandler(this.btGetLocalIP_Click);
            // 
            // btPing
            // 
            this.btPing.Enabled = false;
            this.btPing.Location = new System.Drawing.Point(329, 22);
            this.btPing.Name = "btPing";
            this.btPing.Size = new System.Drawing.Size(56, 23);
            this.btPing.TabIndex = 7;
            this.btPing.Text = "Ping";
            this.btPing.UseVisualStyleBackColor = true;
            this.btPing.Click += new System.EventHandler(this.btPing_Click);
            // 
            // btSave
            // 
            this.btSave.Enabled = false;
            this.btSave.Location = new System.Drawing.Point(391, 22);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(67, 23);
            this.btSave.TabIndex = 8;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 450);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btPing);
            this.Controls.Add(this.btGetLocalIP);
            this.Controls.Add(this.presenterPanel);
            this.Controls.Add(this.btApply);
            this.Controls.Add(this.tbIpAddress);
            this.Name = "Form1";
            this.Text = "Subnet Calc";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbIpAddress;
        private System.Windows.Forms.Button btApply;
        private System.Windows.Forms.Panel presenterPanel;
        private System.Windows.Forms.Button btGetLocalIP;
        private System.Windows.Forms.Button btPing;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}


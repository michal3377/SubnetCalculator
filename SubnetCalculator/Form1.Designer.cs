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
            this.SuspendLayout();
            // 
            // tbIpAddress
            // 
            this.tbIpAddress.Location = new System.Drawing.Point(208, 44);
            this.tbIpAddress.Name = "tbIpAddress";
            this.tbIpAddress.Size = new System.Drawing.Size(143, 20);
            this.tbIpAddress.TabIndex = 0;
            this.tbIpAddress.Text = "192.168.10.44/29";
            // 
            // btApply
            // 
            this.btApply.Location = new System.Drawing.Point(208, 90);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(75, 23);
            this.btApply.TabIndex = 1;
            this.btApply.Text = "Apply";
            this.btApply.UseVisualStyleBackColor = true;
            this.btApply.Click += new System.EventHandler(this.btApply_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btApply);
            this.Controls.Add(this.tbIpAddress);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbIpAddress;
        private System.Windows.Forms.Button btApply;
    }
}


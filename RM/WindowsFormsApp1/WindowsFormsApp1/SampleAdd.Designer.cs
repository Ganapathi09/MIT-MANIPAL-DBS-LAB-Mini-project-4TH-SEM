namespace WindowsFormsApp1
{
    partial class SampleAdd
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(153, 17);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 45);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(85)))), ((int)(((byte)(126)))));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(26, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 45);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(175, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Header";
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(41, 26);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(109, 79);
            this.guna2CirclePictureBox1.TabIndex = 3;
            this.guna2CirclePictureBox1.TabStop = false;
            this.guna2CirclePictureBox1.UseTransparentBackground = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(89)))));
            this.panel1.Controls.Add(this.guna2CirclePictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 108);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Location = new System.Drawing.Point(0, 380);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 89);
            this.panel2.TabIndex = 7;
            // 
            // guna2MessageDialog1
            // 
            this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.guna2MessageDialog1.Caption = "RM";
            this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
            this.guna2MessageDialog1.Parent = this;
            this.guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.guna2MessageDialog1.Text = null;
            // 
            // SampleAdd
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 468);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SampleAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SampleAdd";
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.Label label1;
        public Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panel2;
        public Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
    }
}
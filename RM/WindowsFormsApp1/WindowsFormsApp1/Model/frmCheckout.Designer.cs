namespace WindowsFormsApp1.Model
{
    partial class frmCheckout
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
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.txtBillAmount = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtReceived = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChange = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(90, 23);
            this.label1.Text = "Check Out";
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.icons8_bill_503;
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.guna2ControlBox1);
            this.panel1.Size = new System.Drawing.Size(570, 108);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.guna2CirclePictureBox1, 0);
            this.panel1.Controls.SetChildIndex(this.guna2ControlBox1, 0);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 318);
            this.panel2.Size = new System.Drawing.Size(570, 77);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(152)))), ((int)(((byte)(166)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(500, 33);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 4;
            // 
            // txtBillAmount
            // 
            this.txtBillAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBillAmount.DefaultText = "";
            this.txtBillAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBillAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBillAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBillAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBillAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBillAmount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBillAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBillAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBillAmount.Location = new System.Drawing.Point(26, 155);
            this.txtBillAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBillAmount.Name = "txtBillAmount";
            this.txtBillAmount.PasswordChar = '\0';
            this.txtBillAmount.PlaceholderText = "";
            this.txtBillAmount.SelectedText = "";
            this.txtBillAmount.Size = new System.Drawing.Size(252, 42);
            this.txtBillAmount.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Bill Amount";
            // 
            // txtReceived
            // 
            this.txtReceived.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtReceived.DefaultText = "";
            this.txtReceived.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtReceived.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtReceived.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtReceived.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtReceived.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtReceived.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtReceived.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtReceived.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtReceived.Location = new System.Drawing.Point(301, 155);
            this.txtReceived.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtReceived.Name = "txtReceived";
            this.txtReceived.PasswordChar = '\0';
            this.txtReceived.PlaceholderText = "";
            this.txtReceived.SelectedText = "";
            this.txtReceived.Size = new System.Drawing.Size(252, 42);
            this.txtReceived.TabIndex = 10;
            this.txtReceived.TextChanged += new System.EventHandler(this.txtRecived_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(297, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 23);
            this.label3.TabIndex = 11;
            this.label3.Text = "Payment Received";
            // 
            // txtChange
            // 
            this.txtChange.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtChange.DefaultText = "";
            this.txtChange.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtChange.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtChange.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtChange.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtChange.Enabled = false;
            this.txtChange.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtChange.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtChange.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtChange.Location = new System.Drawing.Point(26, 257);
            this.txtChange.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtChange.Name = "txtChange";
            this.txtChange.PasswordChar = '\0';
            this.txtChange.PlaceholderText = "";
            this.txtChange.SelectedText = "";
            this.txtChange.Size = new System.Drawing.Size(252, 42);
            this.txtChange.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Change";
            // 
            // frmCheckout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 398);
            this.Controls.Add(this.txtChange);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtReceived);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBillAmount);
            this.Controls.Add(this.label2);
            this.Name = "frmCheckout";
            this.Text = "frmCheckout";
            this.Load += new System.EventHandler(this.frmCheckout_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtBillAmount, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtReceived, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtChange, 0);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        public Guna.UI2.WinForms.Guna2TextBox txtBillAmount;
        private System.Windows.Forms.Label label2;
        public Guna.UI2.WinForms.Guna2TextBox txtReceived;
        private System.Windows.Forms.Label label3;
        public Guna.UI2.WinForms.Guna2TextBox txtChange;
        private System.Windows.Forms.Label label4;
    }
}
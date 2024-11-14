namespace WindowsFormsApp1.Model
{
    partial class frmCategoryAdd
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.TabIndex = 0;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnClose
            // 
            this.btnClose.TabIndex = 0;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(115, 23);
            this.label1.Text = "Add Category";
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.icons8_medium_priority_50;
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // panel1
            // 
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.DefaultText = "";
            this.txtName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtName.Location = new System.Drawing.Point(56, 167);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.PlaceholderText = "";
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(252, 42);
            this.txtName.TabIndex = 0;
            // 
            // frmCategoryAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 468);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Name = "frmCategoryAdd";
            this.Text = "frmCategoryAdd";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        public Guna.UI2.WinForms.Guna2TextBox txtName;
    }
}
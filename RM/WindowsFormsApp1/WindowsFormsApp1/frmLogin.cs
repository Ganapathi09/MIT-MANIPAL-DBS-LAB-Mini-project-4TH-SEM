using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

       

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // create db and user table

            if(MainClass.IsValidUser(txtUser.Text,txtPass.Text) == false)
            {
                guna2MessageDialog1.Show("invalid username or password");
                return;
            }
            else
            {
                this.Hide();
                frmMain frm = new frmMain();
                frm.Show();
            }

            //let us insert the user

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

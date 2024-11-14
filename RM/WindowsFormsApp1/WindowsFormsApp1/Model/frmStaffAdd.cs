using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Model
{
    public partial class frmStaffAdd : SampleAdd
    {
        public frmStaffAdd()
        {
            InitializeComponent();
        }

        public int id = 0;

        private void frmStaffAdd_Load(object sender, EventArgs e)
        {

        }

       

        private void btnSave_Click_2(object sender, EventArgs e)
        {
            string qry = "";

            if (id == 0) //insert
            {
                qry = "Insert into Staff values (@Name,@phone,@role)";

            }
            else //update
            {
                qry = "Update Staff Set sName = @Name, sphone = @phone, sRole = @role where staffID = @id";


            }
            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtName.Text);
            ht.Add("@phone", txtPhone.Text);
            ht.Add("@role", cbRole.Text);


            if (MainClass.SQl(qry, ht) > 0)
            {
                guna2MessageDialog1.Show("Saved successfully..");
                id = 0;
                txtName.Text = "";
                txtPhone.Text = "";
                cbRole.SelectedIndex = -1;
                txtName.Focus();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

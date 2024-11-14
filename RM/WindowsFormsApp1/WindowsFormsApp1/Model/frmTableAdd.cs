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
    public partial class frmTableAdd : SampleAdd
    {
        public frmTableAdd()
        {
            InitializeComponent();
        }

        public int id = 0;
      

        private void btnSave_Click_2(object sender, EventArgs e)
        {
            string qry = "";

            if (id == 0) //insert
            {
                qry = "Insert into tables values(@Name)";

            }
            else //update
            {
                qry = "Update tables Set tName = @Name where tID = @id ";


            }
            Hashtable ht = new Hashtable();
            ht.Add("@id", id);
            ht.Add("@Name", txtName.Text);

            if (MainClass.SQl(qry, ht) > 0)
            {
                guna2MessageDialog1.Show("Saved successfully..");
                id = 0;
                txtName.Text = "";
                txtName.Focus();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

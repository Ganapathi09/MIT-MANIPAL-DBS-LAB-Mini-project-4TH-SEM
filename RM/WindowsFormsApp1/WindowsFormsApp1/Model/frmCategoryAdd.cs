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
    public partial class frmCategoryAdd : SampleAdd
    {
        public frmCategoryAdd()
        {
            InitializeComponent();
        }

       

         public int id = 0;

         //public override void btnSave_Click(object sender, EventArgs e)
         //{




         //}

         private void button1_Click(object sender, EventArgs e)
         {
             this.Close();
         }

         private void btnSave_Click_1(object sender, EventArgs e)
         {
             string qry = "";

             if (id == 0) //insert
             {
                 qry = "Insert into category values(@Name,1)";

             }
             else //update
             {
                 qry = "Update category Set catName = @Name where catID = @id ";


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

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

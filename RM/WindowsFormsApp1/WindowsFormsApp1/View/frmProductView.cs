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
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.View
{
    public partial class frmProductView : SampleView
    {
        public frmProductView()
        {
            InitializeComponent();
        }

        private void frmProductView_Load(object sender, EventArgs e)
        {
            GetData();

        }

        //public void GetData()
        //{
        //    string qry = "SELECT p.pID, p.pName, p.pPrice, p.CategoryID, c.catName FROM products p INNER JOIN category c ON c.catID = p.CategoryID;  where pName like '%" + txtSearch.Text + "%'";
        //    ListBox lb = new ListBox();
        //    lb.Items.Add(dgvid);
        //    lb.Items.Add(dgvName);
        //    lb.Items.Add(dvgPrice);
        //    lb.Items.Add(dvgcatID);
        //    lb.Items.Add(dvgcat);


        //    MainClass.LoadData(qry, guna2DataGridView1, lb);

        //}

        public void GetData()
        {
            string qry = "SELECT p.pID, p.pName, p.pPrice, p.CategoryID, c.catName FROM products p INNER JOIN category c ON c.catID = p.CategoryID WHERE  p.active=1 and p.pName LIKE '%" + txtSearch.Text + "%'";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);
            lb.Items.Add(dvgPrice);
            lb.Items.Add(dvgcatID);
            lb.Items.Add(dvgcat);

            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            MainClass.BlurBackground(new Model.frmProductAdd());
            //frmCategoryAdd frm = new frmCategoryAdd();
            //frm.ShowDialog();
            GetData();

        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GetData();

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                //this is change as have to set form text property before open
                frmProductAdd frm = new frmProductAdd();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.cID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dvgcatID"].Value);

                MainClass.BlurBackground(frm);
                GetData();




            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                // need to confirm before delete

                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo;

                if (guna2MessageDialog1.Show("do you want to delete?") == DialogResult.Yes)
                {

                    int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                    string qry = "update  products set active=0 where pID=" + id + "";
                    Hashtable ht = new Hashtable();
                    MainClass.SQl(qry, ht);

                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    guna2MessageDialog1.Show("Deleted successfully");
                    GetData();

                }


            }
        }

        
    }
}

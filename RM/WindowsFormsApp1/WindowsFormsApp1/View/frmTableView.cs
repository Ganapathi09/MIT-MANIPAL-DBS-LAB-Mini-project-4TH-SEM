using Guna.UI2.WinForms;
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
    public partial class frmTableView : SampleView
    {
        public frmTableView()
        {
            InitializeComponent();
        }

        private void frmTableView_Load(object sender, EventArgs e)
        {
            //Create table
            GetData();

        }
        public void GetData()
        {
            string qry = "Select * From tables where tName like '%" + txtSearch.Text + "%'";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvName);

            MainClass.LoadData(qry, guna2DataGridView1, lb);

        }
        public override void btnAdd_Click(object sender, EventArgs e)
        {
            //adding blue effect
            // frmTableAdd frm = new frmTableAdd();
            //frm.ShowDialog();

            MainClass.BlurBackground(new frmTableAdd());
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

                frmTableAdd frm = new frmTableAdd();
                frm.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
                frm.txtName.Text = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvName"].Value);
                frm.ShowDialog();
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
                    string qry = "Delete from tables where tID=" + id + "";
                    Hashtable ht = new Hashtable();

                    MainClass.SQl(qry, ht);

                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    guna2MessageDialog1.Show("Deleted successfully");
                    GetData();

                }


            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

        }
    }
}

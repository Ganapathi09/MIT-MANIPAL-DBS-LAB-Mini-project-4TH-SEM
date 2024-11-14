using Microsoft.Reporting.WebForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Model
{
    public partial class frmBillList : SampleAdd
    {
        public frmBillList()
        {
            InitializeComponent();
        }
        public int MainID=0;
        private void frmBillList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string qry = @"SELECT MainID,tables.tname as TableName,staff.sName as WaiterName ,orderType,status,total
                        from tblMain 
                         join tables on tables.tid=tblMain.tableid
                          join staff on  staff.staffID=tblMain.Waiterid
                          where status <> 'Pending'";
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvTable);
            lb.Items.Add(dgvWaiter);
            lb.Items.Add(dgvType);
            lb.Items.Add(dgvStatus);
            lb.Items.Add(dgvTotal);

            MainClass.LoadData(qry, guna2DataGridView1, lb);
        }
        private void guna2DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //for serial no

            int count = 0;

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MainID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvedit")
            {
                //this is change as have to set form text property before open

                
                MainID = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);
               this.Close();
                

            }
            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvdel")
            {
                List<ReportParameter> parameters = new List<ReportParameter>() { new ReportParameter("MainId", MainID.ToString()) };
                string procedurename = "orderdetailsForBilling";
                List<SqlParameter> sqlParameters = new List<SqlParameter>() { new SqlParameter("MainId", MainID.ToString()) };
                string reportdatasourcename = "OrderDetails";
                MainClass.GenerateReport(@"D:\DBMS PROJECT\RM\Report\BillReport.rdl", parameters, reportdatasourcename, procedurename,sqlParameters);
            }


        }

    }
}

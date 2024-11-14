using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;
using WindowsFormsApp1.View;

namespace WindowsFormsApp1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        //for accesing
        static frmMain _obj;
        public static frmMain Instance
        {
            get { if( _obj == null) { _obj = new frmMain(); } return _obj; } 


        }

        // Methods to add a control in Main form

        public  void AddControls(Form f)
        {
            ControlsPanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            ControlsPanel.Controls.Add(f);
            f.Show();

        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUser.Text = MainClass.USER;
            _obj = this;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            AddControls(new frmHome());
            
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            AddControls(new frmCategoryView());
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            AddControls(new frmTableView());

        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            AddControls(new frmStaffView());
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            AddControls(new frmProductView());

        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            frmPOS frm = new frmPOS();
            frm.Show();
        }

        private void btnKitchen_Click(object sender, EventArgs e)
        {
            AddControls(new frmKitchenView());
        }

       
    }
}

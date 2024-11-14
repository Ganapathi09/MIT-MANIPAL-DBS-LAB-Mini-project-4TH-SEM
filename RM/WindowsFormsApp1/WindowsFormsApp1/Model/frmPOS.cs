using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WindowsFormsApp1.Model
{
    public partial class frmPOS : Form
    {
        public frmPOS()
        {
            InitializeComponent();
        }

        public int MainID = 0;
        public string OrderType="";
        public int driverID = 0;
        public string customerName = "";
        public string customerPhone = "";



        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.BorderStyle = BorderStyle.FixedSingle;
            AddCategory();

            //ProductPanel.Controls.Clear();
            //LoadProducts();
            ProductPanel.Controls.Clear();
            LoadProducts();
        }

        private void AddCategory()
        {
            string qry = "Select * from Category";
            SqlCommand cmd = new SqlCommand(qry,MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CategoryPanel.Controls.Clear(); 

            if(dt.Rows.Count > 0 )
            {
                foreach (DataRow row in dt.Rows)
                {
                    Guna.UI2.WinForms.Guna2Button b = new Guna.UI2.WinForms.Guna2Button();
                    b.FillColor = Color.FromArgb(50, 55, 89);
                    b.Size = new Size(180, 45);
                    b.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
                    b.Text = row["catName"].ToString();
                    b.CheckedState.FillColor = Color.FromArgb(241, 85, 126);

                    //event for click
                    b.Click += new EventHandler(b_Click);
                    CategoryPanel.Controls.Add(b);

                }
                

            }
        }
        

        private void b_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Guna.UI2.WinForms.Guna2Button b = ( Guna.UI2.WinForms.Guna2Button)sender;
            if (b.Text=="All categories")
            {
                txtSearch.Text = "1";
                txtSearch.Text = "";
                return;
            }



            foreach (var item in ProductPanel.Controls)
            {
                var pro = (ucProduct)item;
                pro.Visible = pro.PCategory.ToLower().Contains(b.Text.Trim().ToLower());

            }
        }

        private void AddItems(string id, string proID,string name, string cat, string price, Image pimage)
        {
            var w = new ucProduct
            {
                PName = name,
                PPrice = price,
                PCategory = cat,
                PImage = pimage,
                id = Convert.ToInt32(proID)
            };

            ProductPanel.Controls.Add(w);

            w.onSelect += (ss, ee) =>
            {
                var wdg = (ucProduct)ss;

                foreach (DataGridViewRow item in guna2DataGridView1.Rows)
                {
                    //this will check it  product alredy there then a oe to quantity and update price
                    if (Convert.ToInt32(item.Cells["dgvproID"].Value) == wdg.id)
                    {
                        item.Cells["dvgQty"].Value = int.Parse(item.Cells["dvgQty"].Value.ToString()) + 1;
                        item.Cells["dgvAmount"].Value = int.Parse(item.Cells["dvgQty"].Value.ToString()) *
                                                        double.Parse(item.Cells["dvgPrice"].Value.ToString());
                        return;

                    }
                    
                }
                //this line add new product first for sr# and 2nd 0 for id
                guna2DataGridView1.Rows.Add(new object[] { 0,wdg.id, wdg.id, wdg.PName, 1, wdg.PPrice, wdg.PPrice });
                GetTotal();
            };
       
        }


        //getting product  from database

        private void LoadProducts()
        {
            string qry = "Select * from products INNER JOIN category  ON catID = CategoryID";
            SqlCommand cmd = new SqlCommand(qry, MainClass.con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            foreach (DataRow item in dt.Rows)
            {
                byte[] imagearray = (byte[])item["pImage"];
                byte[] imagebytearry = imagearray;

                AddItems(item["pID"].ToString(), item["pID"].ToString(), item["pName"].ToString(), item["catName"].ToString(),
                    item["pPrice"].ToString(), Image.FromStream(new MemoryStream(imagearray)));

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in CategoryPanel.Controls)
            {
                if (item is Guna.UI2.WinForms.Guna2Button)
                {
                    Guna.UI2.WinForms.Guna2Button b = (Guna.UI2.WinForms.Guna2Button)item;
                    b.Checked=false;

                }
            }
            foreach (var item in ProductPanel.Controls)
            {
                var pro=(ucProduct)item;
                pro.Visible = pro.PName.ToLower().Contains(txtSearch.Text.Trim().ToLower());
                
            }
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

        private void GetTotal()
        {
            double tot = 0;
            lblTotal.Text = "";

            foreach (DataGridViewRow item in guna2DataGridView1.Rows)
            {
                tot += double.Parse(item.Cells["dgvAmount"].Value.ToString());
            }
            lblTotal.Text=tot.ToString("N2");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible=false;
            lblWaiter.Visible=false;
            guna2DataGridView1.Rows.Clear();
            MainID = 0;
            lblTotal.Text = "00";
        }

        /* private void btnDelivery_Click(object sender, EventArgs e)
         {
             lblTable.Text = "";
             lblWaiter.Text = "";
             lblTable.Visible = false;
             lblWaiter.Visible = false;
             OrderType = "Delivery";

             frmAddCustomer frm = new frmAddCustomer();
             frm.mainID = MainID;
             frm.ordertype = OrderType;
             MainClass.BlurBackground(frm);

             if (frm.txtName.Text != "")//as take away did not have driver info
             {
                 driverID = frm.driverID;
                 lblDriverName.Text = "Customer Name:" + frm.txtName.Text + "Phone:" + frm.txtPhone.Text + "Driver:" + frm.cbDriver.Text;
                 lblDriverName.Visible = true;
                 customerName = frm.txtName.Text;
                 customerPhone = frm.txtPhone.Text;
             }


         }*/
        private void btnDelivery_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            OrderType = "Delivery";

            frmAddCustomer frm = new frmAddCustomer();
            frm.mainID = MainID;
            frm.ordertype = OrderType;
            MainClass.BlurBackground(frm);

            if (frm.txtName.Text != "")
            {
                // Check if the name contains any digits
                if (ContainsDigits(frm.txtName.Text))
                {
                    MessageBox.Show("Name cannot contain numbers.");
                    return;
                }
                if (!IsNumeric(frm.txtPhone.Text) || frm.txtPhone.Text.Length != 10)
                {
                    MessageBox.Show("Please enter a valid 10-digit numeric phone number.");
                    return;
                }

                // Check if the phone number is numeric
                if (!IsNumeric(frm.txtPhone.Text))
                {
                    MessageBox.Show("Please enter a numeric phone number.");
                    return;
                }

                driverID = frm.driverID;
                lblDriverName.Text = "Customer Name: " + frm.txtName.Text + ", Phone: " + frm.txtPhone.Text + ", Driver: " + frm.cbDriver.Text;
                lblDriverName.Visible = true;
                customerName = frm.txtName.Text;
                customerPhone = frm.txtPhone.Text;
            }
        }

        // Function to check if a string contains any digits
        private bool ContainsDigits(string text)
        {
            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }

        // Function to check if a string is numeric
        private bool IsNumeric(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }


        /*  private void btnTake_Click(object sender, EventArgs e)
          {
              lblTable.Text = "";
              lblWaiter.Text = "";
              lblTable.Visible = false;
              lblWaiter.Visible = false;
              OrderType = "Take Away";

              frmAddCustomer frm= new frmAddCustomer();
              frm.mainID = MainID;
              frm.ordertype = OrderType;
              MainClass.BlurBackground(frm);

              if (frm.txtName.Text!="")//as take away did not have driver info
              {
                  driverID = frm.driverID;
                  lblDriverName.Text="Customer Name:"+ frm.txtName.Text+ "Phone:"+frm.txtPhone.Text;   
                  lblDriverName.Visible=true;
                  customerName=frm.txtName.Text;
                  customerPhone = frm.txtPhone.Text;
              }

          }*/
        private void btnTake_Click(object sender, EventArgs e)
        {
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            OrderType = "Take Away";

            frmAddCustomer frm = new frmAddCustomer();
            frm.mainID = MainID;
            frm.ordertype = OrderType;
            MainClass.BlurBackground(frm);

            if (frm.txtName.Text != "")
            {
                // Check if the name contains any digits
                if (ContainsDigites(frm.txtName.Text))
                {
                    MessageBox.Show("Name cannot contain numbers.");
                    return;
                }
                if (!IsNumeric(frm.txtPhone.Text) || frm.txtPhone.Text.Length != 10)
                {
                    MessageBox.Show("Please enter a valid 10-digit numeric phone number.");
                    return;
                }

                // Check if the phone number is numeric
                if (!IsNumerice(frm.txtPhone.Text))
                {
                    MessageBox.Show("Please enter a numeric phone number.");
                    return;
                }

                driverID = frm.driverID;
                lblDriverName.Text = "Customer Name: " + frm.txtName.Text + ", Phone: " + frm.txtPhone.Text;
                lblDriverName.Visible = true;
                customerName = frm.txtName.Text;
                customerPhone = frm.txtPhone.Text;
            }
        }

        // Function to check if a string contains any digits
        private bool ContainsDigites(string text)
        {
            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }

        // Function to check if a string is numeric
        private bool IsNumerice(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }



        private void btnDin_Click(object sender, EventArgs e)
        {
            OrderType = "Din in";
            lblDriverName.Visible=false;
            //need to create form for table selection  and witer  selection


            frmTableSelect frm = new frmTableSelect();
            MainClass.BlurBackground(frm);

            if (frm.TableName !="")
            {
                lblTable.Text=frm.TableName;
                lblTable.Visible=true;
                
            }
            else
            {
                lblTable.Text = "";
                lblTable.Visible = false;

            }

            frmWaiterSelect frm2 = new frmWaiterSelect();
            MainClass.BlurBackground(frm2);

            if (frm2.waiterName != "")
            {
                lblWaiter.Text = frm2.waiterName;
                lblWaiter.Visible = true;

            }
            else
            {
                lblWaiter.Text = "";
                lblWaiter.Visible = false;
            }
        }

        private void btnKot_Click(object sender, EventArgs e)
        {
            // save the dat in database
            //craete database
            //need to add field to table to store addition info


            string qry1 = "";//main table
            string qry2 = "";//Detail table


            int detailID = 0;

            if (MainID==0)//insert
            {
                qry1 = @"Insert into tblMain(aDate,Time,tableid,waiterid,status,orderType,total,received,change,driverID,CustName,CustPhone) Values(@aDate,@aTime,(select top 1 tid from tables where tname=@TableName),(select top 1 staffID from staff where sname=@WaiterName),@status,@orderType,@total,@received,@change,@driverID,@CustName,@CustPhone);
                    Select SCOPE_IDENTITY()";
                //this line will get recent add id value
            }
            else//update
            {
                qry1 = @"Update tblMain Set status= @status,total = @total,
                    received = @received,change = @change where MainID =@ID )";
                //this line will get recent  add id value
            }



           
            SqlCommand cmd = new SqlCommand(qry1, MainClass.con);
            cmd.Parameters.AddWithValue("@ID", MainID);
            cmd.Parameters.AddWithValue("@aDate",Convert.ToDateTime(DateTime.Now.Date));
            cmd.Parameters.AddWithValue("@aTime", DateTime.Now.ToShortTimeString());
            cmd.Parameters.AddWithValue("@TableName", lblTable.Text);
            cmd.Parameters.AddWithValue("@WaiterName", lblWaiter.Text);
            cmd.Parameters.AddWithValue("@status", "Pending");
            cmd.Parameters.AddWithValue("@orderType", OrderType);
            cmd.Parameters.AddWithValue("@total", Convert.ToDouble(lblTotal.Text));//As we are saving kitchen value will upload
            cmd.Parameters.AddWithValue("@received", Convert.ToDouble(0));
            cmd.Parameters.AddWithValue("@change", Convert.ToDouble(0));
            cmd.Parameters.AddWithValue("@driverID", driverID);
            cmd.Parameters.AddWithValue("@CustName", customerName);
            cmd.Parameters.AddWithValue("@CustPhone", customerPhone);


            if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
            if (MainID == 0) { MainID = Convert.ToInt32(cmd.ExecuteScalar()); }
            else { cmd.ExecuteNonQuery(); }
            if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }


            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                //detailID = Convert.ToInt32(row.Cells["dgvid"].Value);

                if (detailID == 0)//insert
                {
                    qry2 = @"INSERT INTO tblDetails VALUES (@MainID, @proID, @qty, @price, @amount)";
                }
                else//update
                {
                    qry2 = @"UPDATE tblDetails SET proID = @proID, qty = @qty, price = @price, amount = @amount 
                         WHERE DetailID = @ID";
                }
                SqlCommand cmd2 = new SqlCommand(qry2, MainClass.con);
                cmd2.Parameters.AddWithValue("@ID", detailID);
                cmd2.Parameters.AddWithValue("@MainID", MainID);
                cmd2.Parameters.AddWithValue("@proID", Convert.ToInt32(row.Cells["dgvproID"].Value));
                cmd2.Parameters.AddWithValue("@qty", Convert.ToInt32(row.Cells["dvgQty"].Value));
                cmd2.Parameters.AddWithValue("@price", Convert.ToDouble(row.Cells["dvgPrice"].Value));
                cmd2.Parameters.AddWithValue("@amount", Convert.ToDouble(row.Cells["dgvAmount"].Value));

                if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                cmd2.ExecuteNonQuery();
                if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }
            }

                guna2MessageDialog1.Show("Saved successfully");
                MainID = 0;
                detailID = 0;
                guna2DataGridView1.Rows.Clear();
                lblTable.Text = "";
                lblWaiter.Text = "";
                lblTable.Visible = false;
                lblWaiter.Visible = false;
                lblTotal.Text = "00";
                lblDriverName.Text = "";



        }
        public int id = 0;

        private void btnBill_Click(object sender, EventArgs e)
        {
            frmBillList frm= new frmBillList();
            MainClass.BlurBackground(frm);

            if (frm.MainID >0)
            {   
                id=frm.MainID;
                MainID = frm.MainID;
                LoadEntries();
            }
        }

      private void   LoadEntries()
        {
            string qry = @"Select orderType,tables.tname as TableName,staff.sName as WaiterName,DetailID,pName as proName,
            proID,qty,price,amount from tblMain m
        inner join tblDetails d on m.MainID=d.MainID
        inner join products p on p.pID=d.proID
		join tables on tables.tid=m.tableid
		join staff on  staff.staffID=m.Waiterid
                             where m.MainID=" + id  ;

            SqlCommand cmd2 = new SqlCommand(qry, MainClass.con);
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            da2.Fill(dt2);

            if (dt2.Rows[0]["orderType"].ToString()=="Delivery")
            {
                btnDelivery.Checked = true;
                lblWaiter.Visible=false;
                lblTable.Visible=false;
            }
            else if (dt2.Rows[0]["orderType"].ToString() == "TAke away")
            {
                btnTake.Checked = true;
                lblWaiter.Visible = false;
                lblTable.Visible = false;
            }
            else
            {
                btnDin.Checked = true;
                lblWaiter.Visible = true;
                lblTable.Visible = true;
                
            }


            guna2DataGridView1.Rows.Clear();

            foreach (DataRow item in dt2.Rows)
            {
                lblTable.Text = item["TableName"].ToString();
                lblWaiter.Text =item["WaiterName"].ToString();


                string detailid = item["DetailID"].ToString();
                string proName = item["proName"].ToString();
                string proid = item["proID"].ToString();
                string qty = item["qty"].ToString();
                string price = item["price"].ToString();
                string amount = item["amount"].ToString();
               

                object[] obj = {0,detailid,proid,proName,qty,price,amount };
                guna2DataGridView1.Rows.Add(obj);
            }
            GetTotal();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {

            frmCheckout frm = new frmCheckout();
            frm.MainID = id;
            frm.amt = Convert.ToDouble(lblTotal.Text);
            MainClass.BlurBackground( frm);

            MainID = 0;
            guna2DataGridView1.Rows.Clear();
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            lblTotal.Text = "00";

        }

        private void btnHold_Click(object sender, EventArgs e)
        {
            string qry1 = "";//main table
            string qry2 = "";//Detail table


            int detailID = 0;
            if (OrderType=="")
            {
                guna2MessageDialog1.Show("please select order type");
                return;
            }

            if (MainID == 0)//insert
            {
                qry1 = @"Insert into tblMain(aDate,Time,tableid,waiterid,status,orderType,total,received,change,driverID,CustName,CustPhone) Values(@aDate,@aTime,(select top 1 tid from tables where tname=@TableName),(select top 1 staffID from staff where sname=@WaiterName),@status,@orderType,@total,@received,@change,@driverID,@CustName,@CustPhone);
                    Select SCOPE_IDENTITY()";
                //this line will get recent add id value
            }
            else//update
            {
                qry1 = @"Update tblMain Set status= @status,total = @total,
                    received = @received,change = @change where MainID =@ID )";
                //this line will get recent  add id value
            }




            SqlCommand cmd = new SqlCommand(qry1, MainClass.con);
            cmd.Parameters.AddWithValue("@ID", MainID);
            cmd.Parameters.AddWithValue("@aDate", Convert.ToDateTime(DateTime.Now.Date));
            cmd.Parameters.AddWithValue("@aTime", DateTime.Now.ToShortTimeString());
            cmd.Parameters.AddWithValue("@TableName", lblTable.Text);
            cmd.Parameters.AddWithValue("@WaiterName", lblWaiter.Text);
            cmd.Parameters.AddWithValue("@status", "Hold");
            cmd.Parameters.AddWithValue("@orderType", OrderType);
            cmd.Parameters.AddWithValue("@total", Convert.ToDouble(lblTotal.Text));//As we are saving kitchen value will upload
            cmd.Parameters.AddWithValue("@received", Convert.ToDouble(0));
            cmd.Parameters.AddWithValue("@change", Convert.ToDouble(0));
            cmd.Parameters.AddWithValue("@driverID", driverID);
            cmd.Parameters.AddWithValue("@CustName", customerName);
            cmd.Parameters.AddWithValue("@CustPhone", customerPhone);

            if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
            if (MainID == 0) { MainID = Convert.ToInt32(cmd.ExecuteScalar()); }
            else { cmd.ExecuteNonQuery(); }
            if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }


            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                //detailID = Convert.ToInt32(row.Cells["dgvid"].Value);

                if (detailID == 0)//insert
                {
                    qry2 = @"INSERT INTO tblDetails VALUES (@MainID, @proID, @qty, @price, @amount)";
                }
                else//update
                {
                    qry2 = @"UPDATE tblDetails SET proID = @proID, qty = @qty, price = @price, amount = @amount 
                         WHERE DetailID = @ID";
                }
                SqlCommand cmd2 = new SqlCommand(qry2, MainClass.con);
                cmd2.Parameters.AddWithValue("@ID", detailID);
                cmd2.Parameters.AddWithValue("@MainID", MainID);
                cmd2.Parameters.AddWithValue("@proID", Convert.ToInt32(row.Cells["dgvproID"].Value));
                cmd2.Parameters.AddWithValue("@qty", Convert.ToInt32(row.Cells["dvgQty"].Value));
                cmd2.Parameters.AddWithValue("@price", Convert.ToDouble(row.Cells["dvgPrice"].Value));
                cmd2.Parameters.AddWithValue("@amount", Convert.ToDouble(row.Cells["dgvAmount"].Value));

                if (MainClass.con.State == ConnectionState.Closed) { MainClass.con.Open(); }
                cmd2.ExecuteNonQuery();
                if (MainClass.con.State == ConnectionState.Open) { MainClass.con.Close(); }
            }

            guna2MessageDialog1.Show("Saved successfully");
            MainID = 0;
            detailID = 0;
            guna2DataGridView1.Rows.Clear();
            lblTable.Text = "";
            lblWaiter.Text = "";
            lblTable.Visible = false;
            lblWaiter.Visible = false;
            lblTotal.Text = "00";
            lblDriverName.Text = "";
        }
    }
}

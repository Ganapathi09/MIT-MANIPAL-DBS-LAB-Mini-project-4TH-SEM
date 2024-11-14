using Microsoft.Reporting.WebForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class MainClass
    {

        public static readonly string con_string = @"Data source=DESKTOP-KTDQSKA\SQLEXPRESS;initial catalog=RM;User ID=sa; Password=gana;";
        public static SqlConnection con = new SqlConnection(con_string);

        //method to check user validation

        public static bool IsValidUser(string user,string pass)

        {
            bool isValid = false;



            string qry = @"Select * from users where username = @user  and upass = @pass";
            SqlCommand cmd = new SqlCommand(qry,con);
            SqlParameter usersqlParam = new SqlParameter() { DbType = DbType.String, Value = user,ParameterName="user" };
            SqlParameter PasssqlParam = new SqlParameter() { DbType = DbType.String, Value = pass,ParameterName="pass" };
            cmd.Parameters.Add(usersqlParam);
            cmd.Parameters.Add(PasssqlParam);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if(dt.Rows.Count > 0 )
            {
                isValid = true;

                USER = dt.Rows[0]["uName"].ToString();
            }


            return isValid;

        }
        //create property for username

        public static string user;
        public static string USER
        {
            get { return user; }
            private set { user = value; }
        }

        //Method for curd operation

        public static int SQl(string qry,Hashtable ht)
        {
            int res = 0;



            try
            {
                SqlCommand cmd= new SqlCommand(qry,con);
                cmd.CommandType = CommandType.Text;

                foreach (DictionaryEntry item in ht)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                    
                }
                if (con.State == ConnectionState.Closed) { con.Open(); }
                res = cmd.ExecuteNonQuery();

                if (con.State == ConnectionState.Open) { con.Close(); }
            }
            catch(Exception ex ) 
            {
              //  MessageBox.Show(ex.ToString());
                con.Close();
                throw ex;

            }


            return res;


        }

        // for loading data from db

        public static void LoadData(string qry,DataGridView gv,ListBox lb)
        {
            // serial no in grideview

            gv.CellFormatting += new DataGridViewCellFormattingEventHandler(gv_CellFormatting);
            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for(int i=0;i< lb.Items.Count;i++)
                {
                    string colNam1= ((DataGridViewColumn)lb.Items[i]).Name;
                    gv.Columns[colNam1].DataPropertyName = dt.Columns[i].ToString();

                }
                gv.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();

            }

        }

        public static DataTable LoadDataUsingProcedure(string ProcedureName,List<SqlParameter> sqlparameters)
        {
            // serial no in grideview

            
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(ProcedureName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(sqlparameters.ToArray());
               
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();
                return dt;

               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();

            }
            return null;


        }

        private static void gv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Guna.UI2.WinForms.Guna2DataGridView gv = (Guna.UI2.WinForms.Guna2DataGridView)sender;
            int count = 0;

            foreach (DataGridViewRow row in gv.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }

        public static void BlurBackground(Form Model)
        {
            Form Background = new Form();
            using (Model)
            {
                Background.StartPosition = FormStartPosition.Manual;
                Background.FormBorderStyle = FormBorderStyle.None;
                Background.Opacity = 0.5d;
                Background.BackColor = Color.Black;
                Background.Size = frmMain.Instance.Size;
                Background.Location = frmMain.Instance.Location;
                Background.ShowInTaskbar=false;
                Background.Show();
                Model.Owner = Background;
                Model.ShowDialog(Background);
                Background.Dispose();
            }
        }
        // for  cb fill

        public static void CBFill(string qry,ComboBox cb)
        {
            SqlCommand cmd = new SqlCommand(qry,con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            da.Fill(dt);

            cb.DisplayMember= "name";

            cb.ValueMember = "id";
            cb.DataSource = dt;
            cb.SelectedIndex = -1;
        }


        public static void GenerateReport(string reportPath, List<ReportParameter> reportParameters,string reportdatasourcename, string ProcedureName, List<SqlParameter> sqlparameters)
        {
            string FileName = DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf";
            //The .net code is pretty simple.  First load the RDL file.
            Microsoft.Reporting.WebForms.LocalReport report = new Microsoft.Reporting.WebForms.LocalReport();
            //Point the saved RDL report NOTE: if your rdl file isn't here point to where your file is located
            report.ReportPath = reportPath;
            //Next set the datasource with the data you want to print.
           DataTable scheduleData= LoadDataUsingProcedure(ProcedureName, sqlparameters);

            //create the dataset that we will attach to the report
            Microsoft.Reporting.WebForms.ReportDataSource rds = new ReportDataSource();
            //Set the datasource so the report has data
            rds.Name = reportdatasourcename; //This refers to the dataset name in the RDL file
            rds.Value = scheduleData;
            report.DataSources.Add(rds);
            //You may need to set some default values for report parameters if they exist.
            //Set dummy values for report parameters so the report doesn't blow up
            //NOTE even if hidden parameters you need to have a prompt in the report file so that they can be set here
            report.SetParameters(reportParameters);
            //Next render the report as a PDF.
            //Create the PDF of the report
            var deviceInfo = @"<DeviceInfo>
                    <EmbedFonts>None</EmbedFonts>
                   </DeviceInfo>";

            Byte[] mybytes = report.Render("PDF", deviceInfo);

            //Finally write out the PDF file and display it.
            if (mybytes != null && mybytes.Length > 0)
            {
                //You may need to pick a different folder to write to if c:\temp doesn't exist
                using (FileStream fs = File.Create($"D:\\DBMS PROJECT\\RM\\GeneratedReports\\{FileName}"))
                {
                    fs.Write(mybytes, 0, mybytes.Length);
                }
                //Now we open the pdf file we just created
                System.Diagnostics.Process.Start($"D:\\DBMS PROJECT\\RM\\GeneratedReports\\{FileName}");
            }
        }


    }
}

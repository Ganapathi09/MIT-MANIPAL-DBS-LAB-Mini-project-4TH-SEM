﻿using System;
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
    public partial class frmCheckout : SampleAdd
    {
        public frmCheckout()
        {
            InitializeComponent();
        }

        public double amt;
        public int MainID = 0;

        private void txtRecived_TextChanged(object sender, EventArgs e)
        {
            double amt = 0;
            double receipt = 0;
            double change = 0;

            double.TryParse(txtBillAmount.Text, out amt);
            double.TryParse(txtReceived.Text, out receipt);

            change = Math.Abs(amt - receipt);//convert postive or negative to always positive

            txtChange.Text=change.ToString();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string qry = @"Update tblMain set  total=@total,received=@rec,change=@change,
                           status='paid' where MainID=@id";


            Hashtable ht =new Hashtable();
            ht.Add("@id", MainID);
            ht.Add("@total", txtBillAmount.Text);
            ht.Add("@rec", txtReceived.Text);
            ht.Add("@change", txtChange.Text);

            if (MainClass.SQl(qry,ht)>0)
            {
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Show("Saved Successfull");
                this.Close();
            }

        }

        private void frmCheckout_Load(object sender, EventArgs e)
        {
            txtBillAmount.Text=amt.ToString();
        }
    }
}

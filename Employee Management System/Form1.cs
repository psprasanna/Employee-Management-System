﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CrossBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Admin.Text = "";
            Password.Text="";
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (Admin.Text == " " && Password.Text == " ")
            {
                MessageBox.Show("Info Missing");
            }
            else if (Admin.Text == "Admin" && Password.Text == "Password")
            {
                Home H = new Home();
                H.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please enter correct username and password");
            }
        }
    }
}

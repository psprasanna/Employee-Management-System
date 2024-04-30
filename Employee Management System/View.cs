using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Employee_Management_System
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }

        readonly SqlConnection con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PRASANNA\Documents\EMS.mdf;Integrated Security=True;Connect Timeout=30");

        private void FetchEmp() 
        {
            try
            {
                con.Open();
                string query = "select * from ETBL where EmpId='" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows) 
                {
                    label3.Text = dr["EmpId"].ToString();
                    label4.Text = dr["EmpName"].ToString();
                    label5.Text = dr["EmpGen"].ToString();
                    label10.Text = dr["EmpAdd"].ToString();
                    label15.Text = dr["EmpPos"].ToString();
                    label16.Text = dr["EmpDob"].ToString();
                    label17.Text = dr["EmpPhone"].ToString();
                    label18.Text = dr["EmpEdu"].ToString();

                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    label10.Visible = true;
                    label15.Visible = true;
                    label16.Visible = true;
                    label17.Visible = true;
                    label18.Visible = true;

                }
                con.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void CrossBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            FetchEmp();
        }
    }
}

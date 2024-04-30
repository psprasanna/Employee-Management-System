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
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
        }

        readonly SqlConnection con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PRASANNA\Documents\EMS.mdf;Integrated Security=True;Connect Timeout=30");


        private void FetchEmp()
        {
            try
            {
                if (Eid.Text == " ")
                {
                    MessageBox.Show("Enter Employee Id");
                }
                else
                {
                    con.Open();
                    string query = "select * from ETBL where EmpId='" + Eid.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        En.Text = dr["EmpName"].ToString();
                        Ep.Text = dr["EmpPos"].ToString();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                con.Close();
            }

        }


        private void CrossBtn_Click(object sender, EventArgs e)
        {
            FormUtils.CloseApplication();
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        int DailyBase;
        int Total;

        private void ViewBtn_Click(object sender, EventArgs e)
        {
            if (Ep.Text == "")
            {
                MessageBox.Show("Select an Employee");
            }
            else if (Wd.Text == " " || Convert.ToInt32(Wd.Text) > 28)
            {
                MessageBox.Show("Enter valid Number of days");
            }
            else 
            {
                switch (Ep.Text) 
                {
                    case "Manager":
                        DailyBase = 1200;
                        break;
                    case "Senior Developer":
                        DailyBase = 1000;
                        break;
                    case "Junior Developer":
                        DailyBase = 800;
                        break;
                    case "Accountant":
                        DailyBase = 780;
                        break;
                    case "Receptionist":
                        DailyBase = 600;
                        break;
                    default:
                        DailyBase = 750;
                        break;
                }
                Total = DailyBase * Convert.ToInt32(Wd.Text);
                SalaryBox.Text = "Employee Id : " + Eid.Text + "\n" + "Employee Name : " + En.Text + "\n" + "Employee Position : " + Ep.Text + "\n" + "Daily Base : " + DailyBase + "\n" + "Total Amount : " + Total;

            }
        }

        private void FetchBtn_Click(object sender, EventArgs e)
        {
            FetchEmp();
        }
    }
}

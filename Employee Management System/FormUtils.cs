using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Management_System
{
    class FormUtils
    {
        public static void CloseApplication()
        {
            DialogResult result = MessageBox.Show("Do you want to close the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
         
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}

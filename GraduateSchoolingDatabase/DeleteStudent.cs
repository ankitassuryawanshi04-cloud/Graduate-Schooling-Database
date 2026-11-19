using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;

namespace GraduateSchoolingDatabase
{
    public partial class DeleteStudent : Form
    {
        public DeleteStudent()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter student registertion number");
            }
            else
            {
                String str = "DSN=GSDB";
                OdbcConnection conn = new OdbcConnection(str);
                String strComm = "Delete from CustomerDetails where reg_no='" + textBox1.Text + "'";
                OdbcCommand cmd = new OdbcCommand(strComm, conn);
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Details Deleted Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminDashboard ad = new AdminDashboard();
            ad.Show();
            this.Hide();
        }
    }
}

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
    public partial class SearchStudentDetails : Form
    {
        public SearchStudentDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String str = "DSN=GSDB";
            OdbcConnection conn = new OdbcConnection(str);
            String strComm = "select * from customerdetails where Reg_no='" + textBox1.Text + "'";
            OdbcCommand cmd = new OdbcCommand(strComm, conn);
            OdbcDataReader dr;
            conn.Open();
            try
            {

                int i;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    textBox2.Text = dr.GetString(1);
                    textBox3.Text = dr.GetString(2);
                    textBox4.Text = dr.GetString(3);
                    textBox5.Text = dr.GetString(4);
                    textBox6.Text = dr.GetString(5);
                }
                else
                {
                    MessageBox.Show("Invalid User Name an");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminDashboard ad = new AdminDashboard();
            ad.Show();
            this.Hide();
        }
    }
}

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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String str = "DSN=GSDB";
            OdbcConnection conn = new OdbcConnection(str);
            String strComm = "select * from Login where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
            OdbcCommand cmd = new OdbcCommand(strComm, conn);
            OdbcDataReader dr;
            conn.Open();
            try
            {

                int i;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("Success");
                    AdminDashboard ad = new AdminDashboard();
                    ad.Show();
                    this.Hide();

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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

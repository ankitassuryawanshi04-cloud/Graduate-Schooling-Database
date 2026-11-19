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
    public partial class EmployeeReport : Form
    {
        public EmployeeReport()
        {
            InitializeComponent();
        }

        private void EmployeeReport_Load(object sender, EventArgs e)
        {
           
            String str = "DSN=GSDB";
            OdbcConnection conn = new OdbcConnection(str);
            String strComm = "select * from EmployeeDetails ";
            OdbcCommand cmd = new OdbcCommand(strComm, conn);
            OdbcDataReader dr;
            conn.Open();
            try
            {

                int i;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("Please Enter Year");
            }
            else
            {
                String str = "DSN=GSDB";
                OdbcConnection conn = new OdbcConnection(str);
                String strComm = "select * from EmployeeDetails where joinyear='" + textBox1.Text + "'";
                OdbcCommand cmd = new OdbcCommand(strComm, conn);
                OdbcDataReader dr;
                conn.Open();
                try
                {

                    int i;
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        dataGridView1.DataSource = dt;
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminDashboard ad = new AdminDashboard();
            ad.Show();
            this.Hide();
        }
    }
}

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
    public partial class SearchProduct : Form
    {
        public SearchProduct()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            String str = "DSN=GSDB";
            OdbcConnection conn = new OdbcConnection(str);
            String strComm = "select * from ProductDetails where product_name='"+comboBox1 .SelectedItem .ToString ()+"'";
            OdbcCommand cmd = new OdbcCommand(strComm, conn);
            OdbcDataReader dr;
            conn.Open();
            try
            {


                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    textBox1.Text = dr.GetString(0);
                    textBox2.Text = dr.GetString(1);
                    textBox3.Text = dr.GetString(2);
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

        private void comboBox1_Click(object sender, EventArgs e)
        {
            String str = "DSN=GSDB";
            OdbcConnection conn = new OdbcConnection(str);
            String strComm = "select product_name from ProductDetails ";
            OdbcCommand cmd = new OdbcCommand(strComm, conn);
            OdbcDataReader dr;
            conn.Open();
            try
            {


                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    comboBox1.Items.Add(dr.GetString(0));
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

        private void button4_Click(object sender, EventArgs e)
        {
            AdminDashboard ad = new AdminDashboard();
            ad.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

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
    public partial class DeleteProduct : Form
    {
        public DeleteProduct()
        {
            InitializeComponent();
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

        private void Search_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("Please Enter Year");
            }
            else
            {

                String str = "DSN=GSDB";
                OdbcConnection conn = new OdbcConnection(str);
                String strComm = "Delete from ProductDetails where purchase_year='" + textBox1.Text + "' and product_name='" + comboBox1.SelectedItem.ToString() + "'";
                OdbcCommand cmd = new OdbcCommand(strComm, conn);
                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Details Deleted Successfully");
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

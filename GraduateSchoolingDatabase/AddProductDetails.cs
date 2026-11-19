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
    public partial class AddProductDetails : Form
    {
        public AddProductDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || txtQuantity.Text == "" || txtYear.Text == "")
            {
                MessageBox.Show("Please fill all the field");
            }
            else
            {
                if (IsDigitNumber(txtQuantity.Text.Trim()))
                {
                    if (IsFourDigitNumber(txtYear.Text.Trim()))
                    {

                        String str = "DSN=GSDB";
                        OdbcConnection conn = new OdbcConnection(str);
                        String strComm = "insert into ProductDetails values('" + textBox1.Text + "','" + txtQuantity.Text + "','" + txtYear.Text + "')";
                        OdbcCommand cmd = new OdbcCommand(strComm, conn);
                        conn.Open();
                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Product Details Inserted Successfully");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("please enter four digit year");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter Quantity in digits");
                }
                

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminDashboard ad = new AdminDashboard();
            ad.Show();
            this.Hide();
        }

        private bool IsDigitNumber(string input)
        {
            return input.All(char.IsDigit);
        }
        private bool IsFourDigitNumber(string input)
        {
            return input.Length == 4 && input.All(char.IsDigit);
        }
    }
}

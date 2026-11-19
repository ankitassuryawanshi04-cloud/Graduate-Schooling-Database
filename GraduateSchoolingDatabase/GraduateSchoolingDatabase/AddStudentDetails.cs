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
    public partial class AddStudentDetails : Form
    {
        string gender = "";
        public AddStudentDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1 .Checked )
            {
                gender ="Male";
            }
            else 
            {
                gender ="Female";
            }
            if (textBox1.Text == "" || textBox2.Text == "" || txtphone.Text == "" || txtAdmissionYear.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Please fill all the field");
            }
            else
            {
                if (IsTenDigitNumber(txtphone.Text.Trim()))
                {
                    if (IsFourDigitNumber(txtAdmissionYear.Text.Trim()))
                    {
                        String str = "DSN=GSDB";
                        OdbcConnection conn = new OdbcConnection(str);
                        String strComm = "insert into CustomerDetails values('" + textBox1.Text + "','" + textBox2.Text + "','" + gender + "','" + txtphone.Text + "','" + textBox4.Text + "','" + txtAdmissionYear.Text + "')";
                        OdbcCommand cmd = new OdbcCommand(strComm, conn);
                        conn.Open();
                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Registerd succ");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter four digit year");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter 10 digits phone number");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminDashboard ad = new AdminDashboard();
            ad.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool IsTenDigitNumber(string input)
        {
            return input.Length == 10 && input.All(char.IsDigit);
        }
        private bool IsFourDigitNumber(string input)
        {
            return input.Length == 4 && input.All(char.IsDigit);
        }
    }
}

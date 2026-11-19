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
    public partial class AddEmployeeDetaild : Form
        
    {
        string gender = "";
        public AddEmployeeDetaild()
        {
            InitializeComponent();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }

            if (textBox1.Text == "" || textBox2.Text == "" || txtPhone.Text == "" || txtSalary.Text == "" || txtYear.Text == "")
            {
                MessageBox.Show("Please fill all the field");
            }
            else
            {
                if (IsTenDigitNumber(txtPhone.Text.Trim()))
                {

                    if (IsFourDigitNumber(txtYear.Text.Trim()))
                    {
                        if (IsSalryDigitNumber(txtSalary.Text.Trim()))
                        {
                            String str = "DSN=GSDB";
                            OdbcConnection conn = new OdbcConnection(str);
                            String strComm = "insert into EmployeeDetails values('" + textBox1.Text + "','" + textBox2.Text + "','" + gender + "','" + txtPhone.Text + "','" + comboBox1.Text + "','" + txtSalary.Text + "','" + txtYear.Text + "')";
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
                            MessageBox.Show("Please enter salary in number form");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter four digit phone number");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter 10 digits phone number");
                }

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1 .Text ="";
            textBox2 .Text ="";
            txtPhone.Text = "";
            txtSalary.Text = "";
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
        private bool IsTenDigitNumber(string input)
        {
            return input.Length == 10 && input.All(char.IsDigit);
        }
        private bool IsFourDigitNumber(string input)
        {
            return input.Length == 4 && input.All(char.IsDigit);
        }
        private bool IsSalryDigitNumber(string input)
        {
            return input.All(char.IsDigit);
        }
        public int generateID()
        {

            Random ran = new Random();
            int a = ran.Next(1000, 9999);
            return a;
        }

        private void AddEmployeeDetaild_Load(object sender, EventArgs e)
        {
            textBox1.Text = generateID().ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = generateID().ToString();
        }
    }
}

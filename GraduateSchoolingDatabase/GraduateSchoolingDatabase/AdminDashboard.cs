using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraduateSchoolingDatabase
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEmployeeDetaild ae = new AddEmployeeDetaild();
            ae.Show();
            this.Hide();

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchEmployeeDetails se = new SearchEmployeeDetails();
            se.Show();
            this.Hide();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteEmployee de = new DeleteEmployee();
            de.Show();
            this.Hide();
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudentDetails asd = new AddStudentDetails();
            asd.Show();
            this.Hide();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchStudentDetails ss = new SearchStudentDetails();
            ss.Show();
            this.Hide();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteStudent ds = new DeleteStudent();
            ds.Show();
            this.Hide();
        }

        private void addProductDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProductDetails ap = new AddProductDetails();
            ap.Show();
            this.Hide();
        }

        private void searchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SearchProduct sp = new SearchProduct();
            sp.Show();
            this.Hide();
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DeleteProduct dp = new DeleteProduct();
            dp.Show();
            this.Hide();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeReport er = new EmployeeReport();
            er.Show();
            this.Hide();
        }

        private void customerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            StudentReport sr = new StudentReport();
            sr.Show();
            this.Hide();
        }

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductReport pr = new ProductReport();
            pr.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}

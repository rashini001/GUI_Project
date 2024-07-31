using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Sure Want To Exit","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                Application.Exit();
            }
            

        }

        private void addNewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddBooks abs = new frmAddBooks();    
            abs.Show();
        }

        private void viewBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewBook viewBook = new frmViewBook();
            viewBook.Show();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddStudent ast = new frmAddStudent();
            ast.Show();
        }

        private void viewStudentInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViewStudentInformation vis = new frmViewStudentInformation();
            vis.Show();
        }

        private void issueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueBook ib = new frmIssueBook();
            ib.Show();
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReturnBook rb = new frmReturnBook();
            rb.Show();  
        }

        private void completeBookDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCompleteBook cbd = new frmCompleteBook();
            cbd.Show();

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CourseWork
{
    public partial class frmAddStudent : Form
    {
        public frmAddStudent()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtEnNo.Clear();
            txtDepartment.Clear();
            txtSemester.Clear();
            txtContact.Clear();

            txtEmail.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text != "" && txtEnNo.Text != "" && txtDepartment.Text != "" && txtSemester.Text != "" && txtContact.Text != "" && txtEmail.Text != "")
                {
                    string name = txtName.Text;
                    string enroll = txtEnNo.Text;
                    string department = txtDepartment.Text;
                    string sem = txtSemester.Text;
                    Int64 mobile = Int64.Parse(txtContact.Text);
                    string email = txtEmail.Text;

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = @"data source = DESKTOP-M8MHIQS\SQLEXPRESS;" +
                        "initial catalog = Library;  User Id = Rashini; password = rash";
                    SqlCommand cmd = con.CreateCommand();
                    cmd.Connection = con;

                    con.Open();
                    cmd.CommandText = "insert into NewStudent (sname,enroll,dep,sem,contact,email) values ('" + name + "','" + enroll + "','" + department + "','" + sem + "','" + mobile + "','" + email + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please Fill Empty Fields", "Suggest", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Somethinig Went Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text == string.Empty)
            {
                e.Cancel = true;
               errorProviderStName.SetError(txtName, "Please Enter Student Name");
            }
            else
            {
                e.Cancel = false;
                errorProviderStName.Clear();
            }
        }

        private void txtEnNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtEnNo.Text == string.Empty)
            {
                e.Cancel = true;
                errorProviderEnNo.SetError(txtEnNo, "Please Enter Enrolment No");
            }
            else
            {
                e.Cancel = false;
               errorProviderEnNo.Clear();
            }
        }

        private void txtDepartment_Validating(object sender, CancelEventArgs e)
        {
            if (txtDepartment.Text == string.Empty)
            {
                e.Cancel = true;
                errorProviderDep.SetError(txtDepartment, "Please Enter Department");
            }
            else
            {
                e.Cancel = false;
                errorProviderDep.Clear();
            }
        }

        private void txtSemester_Validating(object sender, CancelEventArgs e)
        {
            if (txtSemester.Text == string.Empty)
            {
                e.Cancel = true;
               errorProviderSemester.SetError(txtSemester, "Please Enter Semester");
            }
            else
            {
                e.Cancel = false;
               errorProviderSemester.Clear();
            }
        }

        private void txtContact_Validating(object sender, CancelEventArgs e)
        {
            if (txtContact.Text == string.Empty)
            {
                e.Cancel = true;
                errorProviderContact.SetError(txtContact, "Please Enter Contact No");
            }
            else
            {
                e.Cancel = false;
               errorProviderContact.Clear();
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text == string.Empty)
            {
                e.Cancel = true;
                errorProviderEmail.SetError(txtEmail, "Please Enter Email");
            }
            else
            {
                e.Cancel = false;
                errorProviderEmail.Clear();
            }
        }
    }
}

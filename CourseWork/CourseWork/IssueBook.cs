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
    public partial class frmIssueBook : Form
    {
        public frmIssueBook()
        {
            InitializeComponent();
        }

        private void frmIssueBook_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"data source = DESKTOP-M8MHIQS\SQLEXPRESS;" +
                    "initial catalog = Library;  User Id = Rashini; password = rash";
                SqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;
                con.Open();

                cmd = new SqlCommand("select bName from NewBook", con);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        cmbName.Items.Add(sdr.GetString(i));
                    }
                }
                sdr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Somethinig Went Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int count;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtEnroll.Text != "")
                {
                    String eid = txtEnroll.Text;

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = @"data source = DESKTOP-M8MHIQS\SQLEXPRESS;" +
                        "initial catalog = Library;  User Id = Rashini; password = rash";
                    SqlCommand cmd = con.CreateCommand();
                    cmd.Connection = con;

                    cmd.CommandText = "select * from NewStudent where enroll='" + eid + "'";
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    //Code to Count how many book has been issued on this enrollement no
                    cmd.CommandText = "select count(std_enroll) from IssueBook where std_enroll='" + eid + "'and book_return_date is null";
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    DataSet ds1 = new DataSet();
                    da.Fill(ds1);

                    count = int.Parse(ds1.Tables[0].Rows[0][0].ToString());


                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        txtStName.Text = ds.Tables[0].Rows[0][1].ToString();
                        txtDep.Text = ds.Tables[0].Rows[0][3].ToString();
                        txtSem.Text = ds.Tables[0].Rows[0][4].ToString();
                        txtContact.Text = ds.Tables[0].Rows[0][5].ToString();
                        txtEmail.Text = ds.Tables[0].Rows[0][6].ToString();
                    }
                    else
                    {
                        txtStName.Clear();
                        txtDep.Clear();
                        txtSem.Clear();
                        txtContact.Clear();
                        txtEmail.Clear();
                        MessageBox.Show("Invalid Enrollement No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Somethinig Went Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStName.Text != "")
                {
                    if (cmbName.SelectedIndex != -1 && count <= 2)
                    {
                        string enroll = txtEnroll.Text;
                        string sname = txtStName.Text;
                        string sdep = txtDep.Text;
                        string sem = txtSem.Text;
                        Int64 contact = Convert.ToInt64(txtContact.Text);
                        string email = txtEmail.Text;
                        string bookname = cmbName.Text;
                        string bookIssueDate = dtmIssueDate.Text;

                        String eid = txtEnroll.Text;

                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = @"data source = DESKTOP-M8MHIQS\SQLEXPRESS;" +
                            "initial catalog = Library;  User Id = Rashini; password = rash";
                        SqlCommand cmd = con.CreateCommand();
                        cmd.Connection = con;
                        con.Open();

                        cmd.CommandText = "insert into IssueBook (std_enroll,std_name,std_dep,std_sem,std_contact,std_email,book_name,book_issue_date) values ('" + enroll + "','" + sname + "','" + sdep + "','" + sem + "','" + contact + "','" + email + "','" + bookname + "','" + bookIssueDate + "')";
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Book Issued", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Select Book OR Maximum number of Book Has been ISSUED", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Enter Valid Enrollement No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Somethinig Went Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEnroll_TextChanged(object sender, EventArgs e)
        {
            if(txtEnroll.Text == "")
            {
                txtStName.Clear();
                txtDep.Clear();
                txtSem.Clear();
                txtContact.Clear();
                txtEmail.Clear();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnroll.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Sure?","Confirmation",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
           
        }
    }
}

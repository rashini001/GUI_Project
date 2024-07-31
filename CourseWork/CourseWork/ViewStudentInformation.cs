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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Security.Cryptography;

namespace CourseWork
{
    public partial class frmViewStudentInformation : Form
    {
        public frmViewStudentInformation()
        {
            InitializeComponent();
        }

        private void txtSearchEnroll_TextChanged(object sender, EventArgs e)
        {
            if(txtSearchEnroll.Text != "")
            {
                label1.Visible = false;
                Image image = Image.FromFile("C:\\Users\\user\\Desktop\\Liberay Management System Icon and Images\\Liberay Management System/search1.gif");
                pictureBox1.Image = image;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"data source = DESKTOP-M8MHIQS\SQLEXPRESS;" +
                    "initial catalog = Library;  User Id = Rashini; password = rash";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudent where enroll LIKE '"+txtSearchEnroll.Text+"%'";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dgvViewStudentInfo.DataSource = ds.Tables[0];
            }
            else
            {
                label1.Visible = true;
                Image image = Image.FromFile("C:\\Users\\user\\Desktop\\Liberay Management System Icon and Images\\Liberay Management System/search.gif");
                pictureBox1.Image = image;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"data source = DESKTOP-M8MHIQS\SQLEXPRESS;" +
                    "initial catalog = Library;  User Id = Rashini; password = rash";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudent";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                dgvViewStudentInfo.DataSource = ds.Tables[0];
            }
        }

        private void frmViewStudentInformation_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"data source = DESKTOP-M8MHIQS\SQLEXPRESS;" +
                "initial catalog = Library;  User Id = Rashini; password = rash";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewStudent";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            dgvViewStudentInfo.DataSource = ds.Tables[0];


        }

        int bid;
        Int64 rowid;
        private void dgvViewStudentInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvViewStudentInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dgvViewStudentInfo.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"data source = DESKTOP-M8MHIQS\SQLEXPRESS;" +
                "initial catalog = Library;  User Id = Rashini; password = rash";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewStudent where stuid = "+bid+"";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            txtName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtEnNo.Text = ds.Tables[0].Rows[0][2].ToString();
            txtDep.Text = ds.Tables[0].Rows[0][3].ToString();
            txtSemester.Text = ds.Tables[0].Rows[0][4].ToString();
            txtContact.Text = ds.Tables[0].Rows[0][5].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sname = txtName.Text;
            string enroll = txtEnNo.Text;
            string dep = txtDep.Text;
            string sem = txtSemester.Text;
            Int64 contact = Int64.Parse(txtContact.Text);
            string email = txtEmail.Text;

            if (MessageBox.Show("Data will be Updated . Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"data source = DESKTOP-M8MHIQS\SQLEXPRESS;" +
                    "initial catalog = Library;  User Id = Rashini; password = rash";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update NewStudent set sname = '" + sname + "', enroll = '" + enroll + "', dep = '" + dep + "', sem = '" + sem + "', contact = '" + contact + "',email = '" + email + "'where stuid = '" + rowid + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                frmViewStudentInformation_Load(this, null);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchEnroll.Clear();
            frmViewStudentInformation_Load(this, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Deleted . Confirm?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"data source = DESKTOP-M8MHIQS\SQLEXPRESS;" +
                    "initial catalog = Library;  User Id = Rashini; password = rash";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from NewStudent where stuid = '"+rowid+"'";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                frmViewStudentInformation_Load(this, null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Unsaved Data Will be Lost", "Are You Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}

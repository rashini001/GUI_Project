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
    public partial class frmViewBook : Form
    {
        public frmViewBook()
        {
            InitializeComponent();
        }

        private void frmViewBook_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"data source = DESKTOP-M8MHIQS\SQLEXPRESS;" +
            "initial catalog = Library;  User Id = Rashini; password = rash";
            SqlCommand cmb = new SqlCommand();
            cmb.Connection = con;

            cmb.CommandText = "select * from NewBook";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmb);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);

            dgvViewBooks.DataSource = ds.Tables[0];

        }
        int bid;
        Int64 rowid;
        private void dgvViewBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvViewBooks.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dgvViewBooks.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show((dgvViewBooks.Rows[e.RowIndex].Cells[0].Value.ToString()));
            }
            panel2.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"data source = DESKTOP-M8MHIQS\SQLEXPRESS;" +
            "initial catalog = Library;  User Id = Rashini; password = rash";
            SqlCommand cmb = new SqlCommand();
            cmb.Connection = con;

            cmb.CommandText = "select * from NewBook where bid = '" + bid + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmb);
            DataSet dataSet = new DataSet();
            da.Fill(dataSet);

            rowid = Int64.Parse(dataSet.Tables[0].Rows[0][0].ToString());

            txtName.Text = dataSet.Tables[0].Rows[0][1].ToString();
            txtAuthor.Text = dataSet.Tables[0].Rows[0][2].ToString();
            txtPublication.Text = dataSet.Tables[0].Rows[0][3].ToString();
            txtDate.Text = dataSet.Tables[0].Rows[0][4].ToString();
            txtPrice.Text = dataSet.Tables[0].Rows[0][5].ToString();
            txtQuantity.Text = dataSet.Tables[0].Rows[0][6].ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible=false;
        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            if(txtBookName.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"data source = DESKTOP-M8MHIQS\SQLEXPRESS;" +
                "initial catalog = Library;  User Id = Rashini; password = rash";
                SqlCommand cmb = new SqlCommand();
                cmb.Connection = con;

                cmb.CommandText = "select * from NewBook where bName LIKE '"+txtBookName.Text+"%'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmb);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);

                dgvViewBooks.DataSource = ds.Tables[0]; 
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"data source = DESKTOP-M8MHIQS\SQLEXPRESS;" +
                "initial catalog = Library;  User Id = Rashini; password = rash";
                SqlCommand cmb = new SqlCommand();
                cmb.Connection = con;

                cmb.CommandText = "select * from NewBook";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmb);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);

                dgvViewBooks.DataSource = ds.Tables[0];
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtBookName.Clear();
            panel2.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string bname = txtName.Text;
                string bauthor = txtAuthor.Text;
                string bpublication = txtPublication.Text;
                string bdate = txtDate.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                Int64 quan = Int64.Parse(txtQuantity.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"data source = DESKTOP-M8MHIQS\SQLEXPRESS;" +
                "initial catalog = Library;  User Id = Rashini; password = rash";
                SqlCommand cmb = new SqlCommand();
                cmb.Connection = con;

                cmb.CommandText = "update NewBook set bName = '" + bname + "', bAuother = '" + bauthor + "' ,bPubl = '" + bpublication + "', bPDate = '" + bdate + "', bPrice = '" + price + "', bQuan = '" + quan + "' where bid = '" + rowid + "'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmb);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be Deleted. Confirm?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"data source = DESKTOP-M8MHIQS\SQLEXPRESS;" +
                "initial catalog = Library;  User Id = Rashini; password = rash";
                SqlCommand cmb = new SqlCommand();
                cmb.Connection = con;

                cmb.CommandText = "delete from NewBook where bid = '"+rowid+"'";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmb);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
            }
        }
    }
}

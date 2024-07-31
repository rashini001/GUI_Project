using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class frmCompleteBook : Form
    {
        public frmCompleteBook()
        {
            InitializeComponent();
        }

        private void frmCompleteBook_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"data source = DESKTOP-M8MHIQS\SQLEXPRESS;" +
                        "initial catalog = Library;  User Id = Rashini; password = rash";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from IssueBook where book_return_date is null";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dgvIssuedBook.DataSource = ds.Tables[0];

                cmd.CommandText = "select * from IssueBook where book_return_date is not null";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                dgvReturnedBook.DataSource = ds1.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Somethinig Went Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

      
    }
}

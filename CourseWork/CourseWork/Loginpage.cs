using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class frmLoginPage : Form
    {
        private readonly string connectionString = @"data source = DESKTOP-M8MHIQS\SQLEXPRESS;" +
                        "initial catalog = Library;  User Id = Rashini; password = rash"; // Replace with your actual connection string

        public frmLoginPage()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("ValidateUser", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                    SqlParameter isValidParam = new SqlParameter("@IsValid", SqlDbType.Int);
                    isValidParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(isValidParam);

                    cmd.ExecuteNonQuery();

                    int isValid = Convert.ToInt32(isValidParam.Value);

                    if (isValid == 1)
                    {
                        this.Hide();
                        frmDashboard dsa = new frmDashboard();
                        dsa.Show();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Went Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

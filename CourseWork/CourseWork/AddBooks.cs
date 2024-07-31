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
using System.Data.SqlClient;

namespace CourseWork
{
    public partial class frmAddBooks : Form
    {
        public frmAddBooks()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBookName.Text != "" && txtAuother.Text != "" && txtPublication.Text != "" && txtPrice.Text != "" && txtQuanity.Text != "")
                {
                    string bname = txtBookName.Text;
                    string bauthor = txtAuother.Text;
                    string publication = txtPublication.Text;
                    string pdate = dtpPurchaseDate.Text;
                    Int64 price = Int64.Parse(txtPrice.Text);
                    Int64 quan = Int64.Parse(txtQuanity.Text);

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = @"data source = DESKTOP-M8MHIQS\SQLEXPRESS;" +
                   "initial catalog = Library;  User Id = Rashini; password = rash";
                    SqlCommand cmb = new SqlCommand();
                    cmb.Connection = con;

                    con.Open();
                    cmb.CommandText = "insert into NewBook(bName,bAuother,bPubl,bPDate,bPrice,bQuan) values('" + bname + "' , '" + bauthor + "' , '" + publication + "' , '" + pdate + "','" + price + "','" + quan + "')";
                    cmb.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Data Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBookName.Clear();
                    txtAuother.Clear();
                    txtPublication.Clear();
                    txtPrice.Clear();
                    txtQuanity.Clear();
                }
                else
                {
                    MessageBox.Show("Empty Fields NOT Allowed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Somethinig Went Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("This will DELETE your Unsaved DATA","Are You Sure?",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK);
            {
                this.Close();
            }
          
        }

        private void txtBookName_Validating(object sender, CancelEventArgs e)
        {
            if (txtBookName.Text == string.Empty)
            {
                e.Cancel = true;
                errorProviderBookName.SetError(txtBookName, "Please Enter Book Name");
            }
            else
            {
                e.Cancel = false;
                errorProviderBookName.Clear();
            }
        }

        private void txtAuother_Validating(object sender, CancelEventArgs e)
        {
            if (txtAuother.Text == string.Empty)
            {
                e.Cancel = true;
               errorProviderAuotherName.SetError(txtAuother, "Please Enter Auother Name");
            }
            else
            {
                e.Cancel = false;
                errorProviderAuotherName.Clear();
            }
        }

        private void txtPublication_Validating(object sender, CancelEventArgs e)
        {
            if (txtPublication.Text == string.Empty)
            {
                e.Cancel = true;
                errorProviderPublication.SetError(txtPublication, "Please Enter Book Publication");
            }
            else
            {
                e.Cancel = false;
                errorProviderPublication.Clear();
            }
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            if (txtPrice.Text == string.Empty)
            {
                e.Cancel = true;
                errorProviderPrice.SetError(txtPrice, "Please Enter Book Price");
            }
            else
            {
                e.Cancel = false;
               errorProviderPrice.Clear();
            }
        }

        private void txtQuanity_Validating(object sender, CancelEventArgs e)
        {
            if (txtQuanity.Text == string.Empty)
            {
                e.Cancel = true;
               errorProviderQuantity.SetError(txtQuanity, "Please Enter Book Quantity");
            }
            else
            {
                e.Cancel = false;
               errorProviderQuantity.Clear();
            }
        }
    }
}

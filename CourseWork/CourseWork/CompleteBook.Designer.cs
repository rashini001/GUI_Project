namespace CourseWork
{
    partial class frmCompleteBook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblIssuedBook = new System.Windows.Forms.Label();
            this.lblReturnedBook = new System.Windows.Forms.Label();
            this.dgvReturnedBook = new System.Windows.Forms.DataGridView();
            this.dgvIssuedBook = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnedBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssuedBook)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIssuedBook
            // 
            this.lblIssuedBook.AutoSize = true;
            this.lblIssuedBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssuedBook.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblIssuedBook.Location = new System.Drawing.Point(413, 9);
            this.lblIssuedBook.Name = "lblIssuedBook";
            this.lblIssuedBook.Size = new System.Drawing.Size(157, 29);
            this.lblIssuedBook.TabIndex = 0;
            this.lblIssuedBook.Text = "Issued Book";
            // 
            // lblReturnedBook
            // 
            this.lblReturnedBook.AutoSize = true;
            this.lblReturnedBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnedBook.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblReturnedBook.Location = new System.Drawing.Point(400, 279);
            this.lblReturnedBook.Name = "lblReturnedBook";
            this.lblReturnedBook.Size = new System.Drawing.Size(193, 29);
            this.lblReturnedBook.TabIndex = 2;
            this.lblReturnedBook.Text = "ReturnedBooks";
            // 
            // dgvReturnedBook
            // 
            this.dgvReturnedBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReturnedBook.Location = new System.Drawing.Point(12, 319);
            this.dgvReturnedBook.Name = "dgvReturnedBook";
            this.dgvReturnedBook.RowHeadersWidth = 51;
            this.dgvReturnedBook.RowTemplate.Height = 24;
            this.dgvReturnedBook.Size = new System.Drawing.Size(1036, 208);
            this.dgvReturnedBook.TabIndex = 3;
            // 
            // dgvIssuedBook
            // 
            this.dgvIssuedBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIssuedBook.Location = new System.Drawing.Point(10, 55);
            this.dgvIssuedBook.Name = "dgvIssuedBook";
            this.dgvIssuedBook.RowHeadersWidth = 51;
            this.dgvIssuedBook.RowTemplate.Height = 24;
            this.dgvIssuedBook.Size = new System.Drawing.Size(1036, 208);
            this.dgvIssuedBook.TabIndex = 4;
            // 
            // frmCompleteBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1058, 540);
            this.Controls.Add(this.dgvIssuedBook);
            this.Controls.Add(this.dgvReturnedBook);
            this.Controls.Add(this.lblReturnedBook);
            this.Controls.Add(this.lblIssuedBook);
            this.Name = "frmCompleteBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " CompleteBookDetails";
            this.Load += new System.EventHandler(this.frmCompleteBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnedBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssuedBook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIssuedBook;
        private System.Windows.Forms.Label lblReturnedBook;
        private System.Windows.Forms.DataGridView dgvReturnedBook;
        private System.Windows.Forms.DataGridView dgvIssuedBook;
    }
}
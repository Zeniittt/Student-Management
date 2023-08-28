namespace _20110016_NguyenQuocDucTin_QLSV
{
    partial class fListContact
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
            this.dataGridViewListContact = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListContact)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewListContact
            // 
            this.dataGridViewListContact.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewListContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListContact.Location = new System.Drawing.Point(13, 13);
            this.dataGridViewListContact.Name = "dataGridViewListContact";
            this.dataGridViewListContact.RowHeadersWidth = 51;
            this.dataGridViewListContact.RowTemplate.Height = 24;
            this.dataGridViewListContact.Size = new System.Drawing.Size(631, 425);
            this.dataGridViewListContact.TabIndex = 0;
            this.dataGridViewListContact.Click += new System.EventHandler(this.dataGridViewListContact_Click);
            // 
            // fListContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 450);
            this.Controls.Add(this.dataGridViewListContact);
            this.Name = "fListContact";
            this.Text = "fListContact";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fListContact_FormClosed);
            this.Load += new System.EventHandler(this.fListContact_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListContact)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewListContact;
    }
}
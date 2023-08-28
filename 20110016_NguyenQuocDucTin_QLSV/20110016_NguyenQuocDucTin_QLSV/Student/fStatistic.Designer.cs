namespace _20110016_NguyenQuocDucTin_QLSV
{
    partial class fStatistic
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
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.pnlMale = new System.Windows.Forms.Panel();
            this.pnlFemale = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblMale = new System.Windows.Forms.Label();
            this.lblFemale = new System.Windows.Forms.Label();
            this.pnlTotal.SuspendLayout();
            this.pnlMale.SuspendLayout();
            this.pnlFemale.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTotal
            // 
            this.pnlTotal.BackColor = System.Drawing.Color.Moccasin;
            this.pnlTotal.Controls.Add(this.lblTotal);
            this.pnlTotal.Location = new System.Drawing.Point(2, 3);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(320, 191);
            this.pnlTotal.TabIndex = 0;
            // 
            // pnlMale
            // 
            this.pnlMale.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlMale.Controls.Add(this.lblMale);
            this.pnlMale.Location = new System.Drawing.Point(2, 200);
            this.pnlMale.Name = "pnlMale";
            this.pnlMale.Size = new System.Drawing.Size(153, 94);
            this.pnlMale.TabIndex = 1;
            // 
            // pnlFemale
            // 
            this.pnlFemale.BackColor = System.Drawing.Color.HotPink;
            this.pnlFemale.Controls.Add(this.lblFemale);
            this.pnlFemale.Location = new System.Drawing.Point(161, 200);
            this.pnlFemale.Name = "pnlFemale";
            this.pnlFemale.Size = new System.Drawing.Size(161, 94);
            this.pnlFemale.TabIndex = 2;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(3, 6);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(314, 185);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total Student: 100%";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotal.MouseEnter += new System.EventHandler(this.lblTotal_MouseEnter);
            this.lblTotal.MouseLeave += new System.EventHandler(this.lblTotal_MouseLeave);
            // 
            // lblMale
            // 
            this.lblMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMale.Location = new System.Drawing.Point(3, 0);
            this.lblMale.Name = "lblMale";
            this.lblMale.Size = new System.Drawing.Size(147, 89);
            this.lblMale.TabIndex = 0;
            this.lblMale.Text = "Male: 50%";
            this.lblMale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMale.MouseEnter += new System.EventHandler(this.lblMale_MouseEnter);
            this.lblMale.MouseLeave += new System.EventHandler(this.lblMale_MouseLeave);
            // 
            // lblFemale
            // 
            this.lblFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFemale.Location = new System.Drawing.Point(3, 5);
            this.lblFemale.Name = "lblFemale";
            this.lblFemale.Size = new System.Drawing.Size(155, 84);
            this.lblFemale.TabIndex = 1;
            this.lblFemale.Text = "Female: 50%";
            this.lblFemale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFemale.MouseEnter += new System.EventHandler(this.lblFemale_MouseEnter);
            this.lblFemale.MouseLeave += new System.EventHandler(this.lblFemale_MouseLeave);
            // 
            // fStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 298);
            this.Controls.Add(this.pnlFemale);
            this.Controls.Add(this.pnlMale);
            this.Controls.Add(this.pnlTotal);
            this.Name = "fStatistic";
            this.Text = "fStatistic";
            this.Load += new System.EventHandler(this.fStatistic_Load);
            this.pnlTotal.ResumeLayout(false);
            this.pnlMale.ResumeLayout(false);
            this.pnlFemale.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel pnlMale;
        private System.Windows.Forms.Panel pnlFemale;
        private System.Windows.Forms.Label lblMale;
        private System.Windows.Forms.Label lblFemale;
    }
}
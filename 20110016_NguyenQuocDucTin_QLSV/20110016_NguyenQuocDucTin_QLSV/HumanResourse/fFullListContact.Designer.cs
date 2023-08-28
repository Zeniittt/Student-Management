namespace _20110016_NguyenQuocDucTin_QLSV
{
    partial class fFullListContact
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstBoxGroup = new System.Windows.Forms.ListBox();
            this.qLSVDataSetListContactByGroup = new _20110016_NguyenQuocDucTin_QLSV.QLSVDataSetListContactByGroup();
            this.qLSVDataSetListContactByGroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facultyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facultyTableAdapter = new _20110016_NguyenQuocDucTin_QLSV.QLSVDataSetListContactByGroupTableAdapters.FacultyTableAdapter();
            this.teacherBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.teacherTableAdapter = new _20110016_NguyenQuocDucTin_QLSV.QLSVDataSetListContactByGroupTableAdapters.TeacherTableAdapter();
            this.teacherBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.teacherBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.teacherBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.teacherBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewListContact = new System.Windows.Forms.DataGridView();
            this.teacherBindingSource5 = new System.Windows.Forms.BindingSource(this.components);
            this.btnShowAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDataSetListContactByGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDataSetListContactByGroupBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facultyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teacherBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teacherBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teacherBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teacherBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teacherBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teacherBindingSource5)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(284, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contact";
            // 
            // lstBoxGroup
            // 
            this.lstBoxGroup.FormattingEnabled = true;
            this.lstBoxGroup.ItemHeight = 16;
            this.lstBoxGroup.Location = new System.Drawing.Point(12, 65);
            this.lstBoxGroup.Name = "lstBoxGroup";
            this.lstBoxGroup.Size = new System.Drawing.Size(177, 372);
            this.lstBoxGroup.TabIndex = 2;
            this.lstBoxGroup.Click += new System.EventHandler(this.lstBoxGroup_Click);
            // 
            // qLSVDataSetListContactByGroup
            // 
            this.qLSVDataSetListContactByGroup.DataSetName = "QLSVDataSetListContactByGroup";
            this.qLSVDataSetListContactByGroup.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // qLSVDataSetListContactByGroupBindingSource
            // 
            this.qLSVDataSetListContactByGroupBindingSource.DataSource = this.qLSVDataSetListContactByGroup;
            this.qLSVDataSetListContactByGroupBindingSource.Position = 0;
            // 
            // facultyBindingSource
            // 
            this.facultyBindingSource.DataMember = "Faculty";
            this.facultyBindingSource.DataSource = this.qLSVDataSetListContactByGroupBindingSource;
            // 
            // facultyTableAdapter
            // 
            this.facultyTableAdapter.ClearBeforeFill = true;
            // 
            // teacherBindingSource
            // 
            this.teacherBindingSource.DataMember = "Teacher";
            this.teacherBindingSource.DataSource = this.qLSVDataSetListContactByGroupBindingSource;
            // 
            // teacherTableAdapter
            // 
            this.teacherTableAdapter.ClearBeforeFill = true;
            // 
            // teacherBindingSource1
            // 
            this.teacherBindingSource1.DataMember = "Teacher";
            this.teacherBindingSource1.DataSource = this.qLSVDataSetListContactByGroupBindingSource;
            // 
            // teacherBindingSource2
            // 
            this.teacherBindingSource2.DataMember = "Teacher";
            this.teacherBindingSource2.DataSource = this.qLSVDataSetListContactByGroupBindingSource;
            // 
            // teacherBindingSource3
            // 
            this.teacherBindingSource3.DataMember = "Teacher";
            this.teacherBindingSource3.DataSource = this.qLSVDataSetListContactByGroupBindingSource;
            // 
            // teacherBindingSource4
            // 
            this.teacherBindingSource4.DataMember = "Teacher";
            this.teacherBindingSource4.DataSource = this.qLSVDataSetListContactByGroupBindingSource;
            // 
            // dataGridViewListContact
            // 
            this.dataGridViewListContact.AllowUserToResizeRows = false;
            this.dataGridViewListContact.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewListContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListContact.Location = new System.Drawing.Point(226, 65);
            this.dataGridViewListContact.Name = "dataGridViewListContact";
            this.dataGridViewListContact.RowHeadersWidth = 51;
            this.dataGridViewListContact.RowTemplate.Height = 24;
            this.dataGridViewListContact.Size = new System.Drawing.Size(1219, 372);
            this.dataGridViewListContact.TabIndex = 3;
            this.dataGridViewListContact.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewListContact_CellDoubleClick);
            // 
            // teacherBindingSource5
            // 
            this.teacherBindingSource5.DataMember = "Teacher";
            this.teacherBindingSource5.DataSource = this.qLSVDataSetListContactByGroupBindingSource;
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(226, 457);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(159, 39);
            this.btnShowAll.TabIndex = 4;
            this.btnShowAll.Text = "Show All Contact";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // fFullListContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1457, 526);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.dataGridViewListContact);
            this.Controls.Add(this.lstBoxGroup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "fFullListContact";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fFullListContact";
            this.Load += new System.EventHandler(this.fFullListContact_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDataSetListContactByGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDataSetListContactByGroupBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facultyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teacherBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teacherBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teacherBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teacherBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teacherBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teacherBindingSource5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstBoxGroup;
        private System.Windows.Forms.BindingSource qLSVDataSetListContactByGroupBindingSource;
        private QLSVDataSetListContactByGroup qLSVDataSetListContactByGroup;
        private System.Windows.Forms.BindingSource facultyBindingSource;
        private QLSVDataSetListContactByGroupTableAdapters.FacultyTableAdapter facultyTableAdapter;
        private System.Windows.Forms.BindingSource teacherBindingSource;
        private QLSVDataSetListContactByGroupTableAdapters.TeacherTableAdapter teacherTableAdapter;
        private System.Windows.Forms.BindingSource teacherBindingSource4;
        private System.Windows.Forms.BindingSource teacherBindingSource1;
        private System.Windows.Forms.BindingSource teacherBindingSource2;
        private System.Windows.Forms.BindingSource teacherBindingSource3;
        private System.Windows.Forms.DataGridView dataGridViewListContact;
        private System.Windows.Forms.BindingSource teacherBindingSource5;
        private System.Windows.Forms.Button btnShowAll;
    }
}
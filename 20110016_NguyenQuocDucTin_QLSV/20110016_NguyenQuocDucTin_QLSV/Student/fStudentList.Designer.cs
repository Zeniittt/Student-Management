namespace _20110016_NguyenQuocDucTin_QLSV
{
    partial class fStudentList
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.majorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.facultyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hometownDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.studentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.qLSVDataSet1 = new _20110016_NguyenQuocDucTin_QLSV.QLSVDataSet1();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLSVDataSet3 = new _20110016_NguyenQuocDucTin_QLSV.QLSVDataSet3();
            this.studentTableAdapter = new _20110016_NguyenQuocDucTin_QLSV.QLSVDataSet3TableAdapters.StudentTableAdapter();
            this.studentTableAdapter1 = new _20110016_NguyenQuocDucTin_QLSV.QLSVDataSet1TableAdapters.StudentTableAdapter();
            this.qLSVDataSet = new _20110016_NguyenQuocDucTin_QLSV.QLSVDataSet();
            this.qLSVDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLSVDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chkBoxFirstName = new System.Windows.Forms.CheckBox();
            this.chkBoxLastName = new System.Windows.Forms.CheckBox();
            this.chkBoxEmail = new System.Windows.Forms.CheckBox();
            this.chkBoxMajor = new System.Windows.Forms.CheckBox();
            this.chkBoxFaculty = new System.Windows.Forms.CheckBox();
            this.chkBoxHometown = new System.Windows.Forms.CheckBox();
            this.chkBoxAddress = new System.Windows.Forms.CheckBox();
            this.grpBoxSearch1 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.cbBoxMajor = new System.Windows.Forms.ComboBox();
            this.cbBoxFaculty = new System.Windows.Forms.ComboBox();
            this.cbBoxGender = new System.Windows.Forms.ComboBox();
            this.cbBoxHometown = new System.Windows.Forms.ComboBox();
            this.btnSuperSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDataSet1BindingSource)).BeginInit();
            this.grpBoxSearch1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(642, 692);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(97, 50);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(417, 39);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(209, 22);
            this.txtSearch.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(647, 31);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 38);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.fnameDataGridViewTextBoxColumn,
            this.lnameDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.majorDataGridViewTextBoxColumn,
            this.facultyDataGridViewTextBoxColumn,
            this.bdateDataGridViewTextBoxColumn,
            this.genderDataGridViewTextBoxColumn,
            this.phoneDataGridViewTextBoxColumn,
            this.hometownDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.pictureDataGridViewImageColumn});
            this.dataGridView1.DataSource = this.studentBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(22, 388);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1341, 271);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Student ID";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // fnameDataGridViewTextBoxColumn
            // 
            this.fnameDataGridViewTextBoxColumn.DataPropertyName = "fname";
            this.fnameDataGridViewTextBoxColumn.HeaderText = "First Name";
            this.fnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fnameDataGridViewTextBoxColumn.Name = "fnameDataGridViewTextBoxColumn";
            // 
            // lnameDataGridViewTextBoxColumn
            // 
            this.lnameDataGridViewTextBoxColumn.DataPropertyName = "lname";
            this.lnameDataGridViewTextBoxColumn.HeaderText = "Last Name";
            this.lnameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lnameDataGridViewTextBoxColumn.Name = "lnameDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // majorDataGridViewTextBoxColumn
            // 
            this.majorDataGridViewTextBoxColumn.DataPropertyName = "major";
            this.majorDataGridViewTextBoxColumn.HeaderText = "Major";
            this.majorDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.majorDataGridViewTextBoxColumn.Name = "majorDataGridViewTextBoxColumn";
            // 
            // facultyDataGridViewTextBoxColumn
            // 
            this.facultyDataGridViewTextBoxColumn.DataPropertyName = "faculty";
            this.facultyDataGridViewTextBoxColumn.HeaderText = "Faculty";
            this.facultyDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.facultyDataGridViewTextBoxColumn.Name = "facultyDataGridViewTextBoxColumn";
            // 
            // bdateDataGridViewTextBoxColumn
            // 
            this.bdateDataGridViewTextBoxColumn.DataPropertyName = "bdate";
            this.bdateDataGridViewTextBoxColumn.HeaderText = "Birthday";
            this.bdateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.bdateDataGridViewTextBoxColumn.Name = "bdateDataGridViewTextBoxColumn";
            // 
            // genderDataGridViewTextBoxColumn
            // 
            this.genderDataGridViewTextBoxColumn.DataPropertyName = "gender";
            this.genderDataGridViewTextBoxColumn.HeaderText = "Gender";
            this.genderDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.genderDataGridViewTextBoxColumn.Name = "genderDataGridViewTextBoxColumn";
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "phone";
            this.phoneDataGridViewTextBoxColumn.HeaderText = "Phone";
            this.phoneDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            // 
            // hometownDataGridViewTextBoxColumn
            // 
            this.hometownDataGridViewTextBoxColumn.DataPropertyName = "hometown";
            this.hometownDataGridViewTextBoxColumn.HeaderText = "Hometown";
            this.hometownDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.hometownDataGridViewTextBoxColumn.Name = "hometownDataGridViewTextBoxColumn";
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Address";
            this.addressDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            // 
            // pictureDataGridViewImageColumn
            // 
            this.pictureDataGridViewImageColumn.DataPropertyName = "picture";
            this.pictureDataGridViewImageColumn.HeaderText = "Picture";
            this.pictureDataGridViewImageColumn.MinimumWidth = 6;
            this.pictureDataGridViewImageColumn.Name = "pictureDataGridViewImageColumn";
            // 
            // studentBindingSource1
            // 
            this.studentBindingSource1.DataMember = "Student";
            this.studentBindingSource1.DataSource = this.qLSVDataSet1;
            // 
            // qLSVDataSet1
            // 
            this.qLSVDataSet1.DataSetName = "QLSVDataSet1";
            this.qLSVDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataMember = "Student";
            this.studentBindingSource.DataSource = this.qLSVDataSet3;
            // 
            // qLSVDataSet3
            // 
            this.qLSVDataSet3.DataSetName = "QLSVDataSet3";
            this.qLSVDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // studentTableAdapter
            // 
            this.studentTableAdapter.ClearBeforeFill = true;
            // 
            // studentTableAdapter1
            // 
            this.studentTableAdapter1.ClearBeforeFill = true;
            // 
            // qLSVDataSet
            // 
            this.qLSVDataSet.DataSetName = "QLSVDataSet";
            this.qLSVDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // qLSVDataSetBindingSource
            // 
            this.qLSVDataSetBindingSource.DataSource = this.qLSVDataSet;
            this.qLSVDataSetBindingSource.Position = 0;
            // 
            // qLSVDataSet1BindingSource
            // 
            this.qLSVDataSet1BindingSource.DataSource = this.qLSVDataSet1;
            this.qLSVDataSet1BindingSource.Position = 0;
            // 
            // chkBoxFirstName
            // 
            this.chkBoxFirstName.AutoSize = true;
            this.chkBoxFirstName.Location = new System.Drawing.Point(139, 83);
            this.chkBoxFirstName.Name = "chkBoxFirstName";
            this.chkBoxFirstName.Size = new System.Drawing.Size(94, 20);
            this.chkBoxFirstName.TabIndex = 5;
            this.chkBoxFirstName.Text = "First Name";
            this.chkBoxFirstName.UseVisualStyleBackColor = true;
            // 
            // chkBoxLastName
            // 
            this.chkBoxLastName.AutoSize = true;
            this.chkBoxLastName.Location = new System.Drawing.Point(270, 83);
            this.chkBoxLastName.Name = "chkBoxLastName";
            this.chkBoxLastName.Size = new System.Drawing.Size(94, 20);
            this.chkBoxLastName.TabIndex = 6;
            this.chkBoxLastName.Text = "Last Name";
            this.chkBoxLastName.UseVisualStyleBackColor = true;
            // 
            // chkBoxEmail
            // 
            this.chkBoxEmail.AutoSize = true;
            this.chkBoxEmail.Location = new System.Drawing.Point(402, 83);
            this.chkBoxEmail.Name = "chkBoxEmail";
            this.chkBoxEmail.Size = new System.Drawing.Size(63, 20);
            this.chkBoxEmail.TabIndex = 7;
            this.chkBoxEmail.Text = "Email";
            this.chkBoxEmail.UseVisualStyleBackColor = true;
            // 
            // chkBoxMajor
            // 
            this.chkBoxMajor.AutoSize = true;
            this.chkBoxMajor.Location = new System.Drawing.Point(509, 83);
            this.chkBoxMajor.Name = "chkBoxMajor";
            this.chkBoxMajor.Size = new System.Drawing.Size(63, 20);
            this.chkBoxMajor.TabIndex = 8;
            this.chkBoxMajor.Text = "Major";
            this.chkBoxMajor.UseVisualStyleBackColor = true;
            // 
            // chkBoxFaculty
            // 
            this.chkBoxFaculty.AutoSize = true;
            this.chkBoxFaculty.Location = new System.Drawing.Point(607, 83);
            this.chkBoxFaculty.Name = "chkBoxFaculty";
            this.chkBoxFaculty.Size = new System.Drawing.Size(72, 20);
            this.chkBoxFaculty.TabIndex = 9;
            this.chkBoxFaculty.Text = "Faculty";
            this.chkBoxFaculty.UseVisualStyleBackColor = true;
            // 
            // chkBoxHometown
            // 
            this.chkBoxHometown.AutoSize = true;
            this.chkBoxHometown.Location = new System.Drawing.Point(722, 83);
            this.chkBoxHometown.Name = "chkBoxHometown";
            this.chkBoxHometown.Size = new System.Drawing.Size(93, 20);
            this.chkBoxHometown.TabIndex = 10;
            this.chkBoxHometown.Text = "Hometown";
            this.chkBoxHometown.UseVisualStyleBackColor = true;
            // 
            // chkBoxAddress
            // 
            this.chkBoxAddress.AutoSize = true;
            this.chkBoxAddress.Location = new System.Drawing.Point(854, 83);
            this.chkBoxAddress.Name = "chkBoxAddress";
            this.chkBoxAddress.Size = new System.Drawing.Size(80, 20);
            this.chkBoxAddress.TabIndex = 11;
            this.chkBoxAddress.Text = "Address";
            this.chkBoxAddress.UseVisualStyleBackColor = true;
            // 
            // grpBoxSearch1
            // 
            this.grpBoxSearch1.Controls.Add(this.btnSearch);
            this.grpBoxSearch1.Controls.Add(this.chkBoxAddress);
            this.grpBoxSearch1.Controls.Add(this.txtSearch);
            this.grpBoxSearch1.Controls.Add(this.chkBoxHometown);
            this.grpBoxSearch1.Controls.Add(this.chkBoxFirstName);
            this.grpBoxSearch1.Controls.Add(this.chkBoxFaculty);
            this.grpBoxSearch1.Controls.Add(this.chkBoxLastName);
            this.grpBoxSearch1.Controls.Add(this.chkBoxMajor);
            this.grpBoxSearch1.Controls.Add(this.chkBoxEmail);
            this.grpBoxSearch1.Location = new System.Drawing.Point(133, 12);
            this.grpBoxSearch1.Name = "grpBoxSearch1";
            this.grpBoxSearch1.Size = new System.Drawing.Size(1108, 120);
            this.grpBoxSearch1.TabIndex = 12;
            this.grpBoxSearch1.TabStop = false;
            this.grpBoxSearch1.Text = "Search";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSuperSearch);
            this.groupBox1.Controls.Add(this.cbBoxHometown);
            this.groupBox1.Controls.Add(this.cbBoxGender);
            this.groupBox1.Controls.Add(this.cbBoxFaculty);
            this.groupBox1.Controls.Add(this.cbBoxMajor);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtLastName);
            this.groupBox1.Controls.Add(this.txtFirstName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtStudentID);
            this.groupBox1.Location = new System.Drawing.Point(133, 166);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1108, 179);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(105, 34);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(128, 22);
            this.txtStudentID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "StudentID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "FirstName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "LastName";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Major";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(300, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Faculty";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(555, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Gender";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(555, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "Hometown";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(555, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 16);
            this.label9.TabIndex = 9;
            this.label9.Text = "Address";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(105, 91);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(128, 22);
            this.txtFirstName.TabIndex = 12;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(105, 144);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(128, 22);
            this.txtLastName.TabIndex = 13;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(374, 34);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(128, 22);
            this.txtEmail.TabIndex = 14;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(657, 147);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(128, 22);
            this.txtAddress.TabIndex = 17;
            // 
            // cbBoxMajor
            // 
            this.cbBoxMajor.FormattingEnabled = true;
            this.cbBoxMajor.Location = new System.Drawing.Point(374, 89);
            this.cbBoxMajor.Name = "cbBoxMajor";
            this.cbBoxMajor.Size = new System.Drawing.Size(128, 24);
            this.cbBoxMajor.TabIndex = 18;
            // 
            // cbBoxFaculty
            // 
            this.cbBoxFaculty.FormattingEnabled = true;
            this.cbBoxFaculty.Location = new System.Drawing.Point(374, 142);
            this.cbBoxFaculty.Name = "cbBoxFaculty";
            this.cbBoxFaculty.Size = new System.Drawing.Size(128, 24);
            this.cbBoxFaculty.TabIndex = 19;
            // 
            // cbBoxGender
            // 
            this.cbBoxGender.FormattingEnabled = true;
            this.cbBoxGender.Location = new System.Drawing.Point(657, 32);
            this.cbBoxGender.Name = "cbBoxGender";
            this.cbBoxGender.Size = new System.Drawing.Size(128, 24);
            this.cbBoxGender.TabIndex = 20;
            // 
            // cbBoxHometown
            // 
            this.cbBoxHometown.FormattingEnabled = true;
            this.cbBoxHometown.Location = new System.Drawing.Point(657, 89);
            this.cbBoxHometown.Name = "cbBoxHometown";
            this.cbBoxHometown.Size = new System.Drawing.Size(128, 24);
            this.cbBoxHometown.TabIndex = 21;
            // 
            // btnSuperSearch
            // 
            this.btnSuperSearch.Location = new System.Drawing.Point(854, 81);
            this.btnSuperSearch.Name = "btnSuperSearch";
            this.btnSuperSearch.Size = new System.Drawing.Size(100, 38);
            this.btnSuperSearch.TabIndex = 12;
            this.btnSuperSearch.Text = "Search";
            this.btnSuperSearch.UseVisualStyleBackColor = true;
            this.btnSuperSearch.Click += new System.EventHandler(this.btnSuperSearch_Click);
            // 
            // fStudentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 766);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpBoxSearch1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dataGridView1);
            this.Name = "fStudentList";
            this.Text = "fStudentList";
            this.Load += new System.EventHandler(this.fStudentList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLSVDataSet1BindingSource)).EndInit();
            this.grpBoxSearch1.ResumeLayout(false);
            this.grpBoxSearch1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private QLSVDataSet3 qLSVDataSet3;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private QLSVDataSet3TableAdapters.StudentTableAdapter studentTableAdapter;
        private QLSVDataSet1 qLSVDataSet1;
        private System.Windows.Forms.BindingSource studentBindingSource1;
        private QLSVDataSet1TableAdapters.StudentTableAdapter studentTableAdapter1;
        private QLSVDataSet qLSVDataSet;
        private System.Windows.Forms.BindingSource qLSVDataSetBindingSource;
        private System.Windows.Forms.BindingSource qLSVDataSet1BindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn majorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn facultyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bdateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hometownDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn pictureDataGridViewImageColumn;
        private System.Windows.Forms.CheckBox chkBoxFirstName;
        private System.Windows.Forms.CheckBox chkBoxLastName;
        private System.Windows.Forms.CheckBox chkBoxEmail;
        private System.Windows.Forms.CheckBox chkBoxMajor;
        private System.Windows.Forms.CheckBox chkBoxFaculty;
        private System.Windows.Forms.CheckBox chkBoxHometown;
        private System.Windows.Forms.CheckBox chkBoxAddress;
        private System.Windows.Forms.GroupBox grpBoxSearch1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.ComboBox cbBoxHometown;
        private System.Windows.Forms.ComboBox cbBoxGender;
        private System.Windows.Forms.ComboBox cbBoxFaculty;
        private System.Windows.Forms.ComboBox cbBoxMajor;
        private System.Windows.Forms.Button btnSuperSearch;
    }
}
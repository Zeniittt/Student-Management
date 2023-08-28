namespace _20110016_NguyenQuocDucTin_QLSV
{
    partial class fListCourseOfStudentRegistration
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
            this.lstViewCourse = new System.Windows.Forms.ListView();
            this.courseName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.semester = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lstViewCourse
            // 
            this.lstViewCourse.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.courseName,
            this.semester});
            this.lstViewCourse.HideSelection = false;
            this.lstViewCourse.Location = new System.Drawing.Point(12, 12);
            this.lstViewCourse.Name = "lstViewCourse";
            this.lstViewCourse.Size = new System.Drawing.Size(404, 312);
            this.lstViewCourse.TabIndex = 1;
            this.lstViewCourse.UseCompatibleStateImageBehavior = false;
            // 
            // courseName
            // 
            this.courseName.Text = "Course Name";
            this.courseName.Width = 200;
            // 
            // semester
            // 
            this.semester.Text = "Semester";
            this.semester.Width = 50;
            // 
            // fListCourseOfStudentRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 336);
            this.Controls.Add(this.lstViewCourse);
            this.Name = "fListCourseOfStudentRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fListCourseOfStudentRegistration";
            this.Load += new System.EventHandler(this.fListCourseOfStudentRegistration_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstViewCourse;
        private System.Windows.Forms.ColumnHeader courseName;
        private System.Windows.Forms.ColumnHeader semester;
    }
}
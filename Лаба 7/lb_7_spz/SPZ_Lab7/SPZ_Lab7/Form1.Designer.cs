namespace SPZ_Lab7
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.dataGridViewStudents = new System.Windows.Forms.DataGridView();
			this.dataGridViewSubjects = new System.Windows.Forms.DataGridView();
			this.btAddStudent = new System.Windows.Forms.Button();
			this.btDeleteStudent = new System.Windows.Forms.Button();
			this.btDeleteSubject = new System.Windows.Forms.Button();
			this.btAddSubject = new System.Windows.Forms.Button();
			this.btEditSubject = new System.Windows.Forms.Button();
			this.btEditStudent = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubjects)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridViewStudents
			// 
			this.dataGridViewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewStudents.Location = new System.Drawing.Point(12, 12);
			this.dataGridViewStudents.Name = "dataGridViewStudents";
			this.dataGridViewStudents.ReadOnly = true;
			this.dataGridViewStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewStudents.Size = new System.Drawing.Size(151, 213);
			this.dataGridViewStudents.TabIndex = 0;
			this.dataGridViewStudents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStudents_CellClick);
			// 
			// dataGridViewSubjects
			// 
			this.dataGridViewSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewSubjects.Location = new System.Drawing.Point(180, 12);
			this.dataGridViewSubjects.Name = "dataGridViewSubjects";
			this.dataGridViewSubjects.ReadOnly = true;
			this.dataGridViewSubjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewSubjects.Size = new System.Drawing.Size(245, 213);
			this.dataGridViewSubjects.TabIndex = 1;
			// 
			// btAddStudent
			// 
			this.btAddStudent.Location = new System.Drawing.Point(93, 237);
			this.btAddStudent.Name = "btAddStudent";
			this.btAddStudent.Size = new System.Drawing.Size(70, 51);
			this.btAddStudent.TabIndex = 2;
			this.btAddStudent.Text = "Add Student";
			this.btAddStudent.UseVisualStyleBackColor = true;
			this.btAddStudent.Click += new System.EventHandler(this.btAddStudent_Click);
			// 
			// btDeleteStudent
			// 
			this.btDeleteStudent.Location = new System.Drawing.Point(12, 294);
			this.btDeleteStudent.Name = "btDeleteStudent";
			this.btDeleteStudent.Size = new System.Drawing.Size(151, 32);
			this.btDeleteStudent.TabIndex = 3;
			this.btDeleteStudent.Text = "Delete Student";
			this.btDeleteStudent.UseVisualStyleBackColor = true;
			this.btDeleteStudent.Click += new System.EventHandler(this.btDeleteStudent_Click);
			// 
			// btDeleteSubject
			// 
			this.btDeleteSubject.Location = new System.Drawing.Point(350, 237);
			this.btDeleteSubject.Name = "btDeleteSubject";
			this.btDeleteSubject.Size = new System.Drawing.Size(75, 51);
			this.btDeleteSubject.TabIndex = 5;
			this.btDeleteSubject.Text = "Delete Subject";
			this.btDeleteSubject.UseVisualStyleBackColor = true;
			this.btDeleteSubject.Click += new System.EventHandler(this.btDeleteSubject_Click);
			// 
			// btAddSubject
			// 
			this.btAddSubject.Location = new System.Drawing.Point(265, 237);
			this.btAddSubject.Name = "btAddSubject";
			this.btAddSubject.Size = new System.Drawing.Size(75, 51);
			this.btAddSubject.TabIndex = 4;
			this.btAddSubject.Text = "Add Subject";
			this.btAddSubject.UseVisualStyleBackColor = true;
			this.btAddSubject.Click += new System.EventHandler(this.btAddSubject_Click);
			// 
			// btEditSubject
			// 
			this.btEditSubject.Location = new System.Drawing.Point(180, 237);
			this.btEditSubject.Name = "btEditSubject";
			this.btEditSubject.Size = new System.Drawing.Size(75, 51);
			this.btEditSubject.TabIndex = 7;
			this.btEditSubject.Text = "Edit Subject";
			this.btEditSubject.UseVisualStyleBackColor = true;
			this.btEditSubject.Click += new System.EventHandler(this.btEditSubject_Click);
			// 
			// btEditStudent
			// 
			this.btEditStudent.Location = new System.Drawing.Point(12, 237);
			this.btEditStudent.Name = "btEditStudent";
			this.btEditStudent.Size = new System.Drawing.Size(71, 51);
			this.btEditStudent.TabIndex = 6;
			this.btEditStudent.Text = "Edit Student";
			this.btEditStudent.UseVisualStyleBackColor = true;
			this.btEditStudent.Click += new System.EventHandler(this.btEditStudent_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(467, 336);
			this.Controls.Add(this.btEditSubject);
			this.Controls.Add(this.btEditStudent);
			this.Controls.Add(this.btDeleteSubject);
			this.Controls.Add(this.btAddSubject);
			this.Controls.Add(this.btDeleteStudent);
			this.Controls.Add(this.btAddStudent);
			this.Controls.Add(this.dataGridViewSubjects);
			this.Controls.Add(this.dataGridViewStudents);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudents)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubjects)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridViewStudents;
		private System.Windows.Forms.DataGridView dataGridViewSubjects;
		private System.Windows.Forms.Button btAddStudent;
		private System.Windows.Forms.Button btDeleteStudent;
		private System.Windows.Forms.Button btDeleteSubject;
		private System.Windows.Forms.Button btAddSubject;
		private System.Windows.Forms.Button btEditSubject;
		private System.Windows.Forms.Button btEditStudent;
	}
}


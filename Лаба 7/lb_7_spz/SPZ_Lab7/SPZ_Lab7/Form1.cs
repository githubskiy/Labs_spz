using System;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SPZ_Lab7
{
	public partial class Form1 : Form
	{
		private SqlConnection conn;
		private BindingSource bsStudents;
		private BindingSource bsSubjects;
		private DataTable studentsTable;
		private DataTable subjectsTable;
		private SqlParameter param;
		private SqlCommand cmd;
		private AddStudentForm studentForm;
		private AddSubjectForm subjectForm;

		public Form1()
		{
			InitializeComponent();
			bsStudents = new BindingSource();
			bsSubjects = new BindingSource();
			dataGridViewStudents.DataSource = bsStudents;
			dataGridViewSubjects.DataSource = bsSubjects;
			studentsTable = new DataTable();
			subjectsTable = new DataTable();

			string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\unkno\db.xlsx;Integrated Security=True;";
			conn = new SqlConnection(connStr);
			try
			{
				conn.Open();
			}
			catch (SqlException se)
			{
				MessageBox.Show("Connection error:{0}", se.Message);
				return;
			}

			bsStudents.DataSource = studentsTable;
			bsSubjects.DataSource = subjectsTable;
			UpdateStudentsList();
			UpdateSubjectsList();
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			conn.Close();
			conn.Dispose();
		}

		private void UpdateStudentsList()
		{
			studentsTable.Clear();
			cmd = new SqlCommand("Select Name From Students", conn);
			using (SqlDataReader dr = cmd.ExecuteReader())
			{
				studentsTable.Load(dr);
			}
			bsStudents.ResetBindings(true);
		}

		private void UpdateSubjectsList()
		{
			subjectsTable.Clear();

			if (studentsTable.Rows.Count != 0)
			{
				cmd = new SqlCommand("Select g.Subject, g.Grade From Students a join [Groups] g ON g.StudentID = a.ID where a.Name = @StudentName", conn);

				param = new SqlParameter
				{
					ParameterName = "@StudentName",
					Value = dataGridViewStudents.CurrentCell.Value.ToString(),
					SqlDbType = SqlDbType.NVarChar
				};
				cmd.Parameters.Add(param);
				using (SqlDataReader dr = cmd.ExecuteReader())
				{
					subjectsTable.Load(dr);
				}
				bsStudents.ResetBindings(true);
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void btAddStudent_Click(object sender, EventArgs e)
		{
			studentForm = new AddStudentForm();
			studentForm.ShowDialog();

			if(studentForm.DialogResult == DialogResult.OK)
			{
				cmd = new SqlCommand("Insert into Students" +
				"(Name) Values (@StudentName)", conn);
				param = new SqlParameter
				{
					ParameterName = "@StudentName",
					Value = studentForm.StudentName,
					SqlDbType = SqlDbType.Text
				};
				cmd.Parameters.Add(param);

				try
				{
					cmd.ExecuteNonQuery();
				}
				catch
				{
					MessageBox.Show("Inserting error");
					return;
				}

				UpdateStudentsList();
				UpdateSubjectsList();
			}
		}

		private void dataGridViewStudents_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			UpdateSubjectsList();
		}

		private void btDeleteStudent_Click(object sender, EventArgs e)
		{
			if (studentsTable.Rows.Count == 0)
				return;
			
			cmd = new SqlCommand("Delete From [Groups] where StudentID = (select ID from Students where [Name] = @StudentName); Delete from Students where [Name] = @StudentName", conn);
			param = new SqlParameter
			{
				ParameterName = "@StudentName",
				Value = dataGridViewStudents.CurrentCell.Value.ToString(),
				SqlDbType = SqlDbType.NVarChar
			};
			cmd.Parameters.Add(param);

			try
			{
				cmd.ExecuteNonQuery();
			}
			catch
			{
				MessageBox.Show("Delete error");
				return;
			}

			UpdateStudentsList();
			UpdateSubjectsList();
		}

		private void btAddSubject_Click(object sender, EventArgs e)
		{
			subjectForm = new AddSubjectForm();
			subjectForm.ShowDialog();

			if (subjectForm.DialogResult == DialogResult.OK)
			{
				cmd = new SqlCommand("Insert into Groups (StudentID, [Subject], Grade) Values ((select ID from Students where [Name] = @StudentName), @Subject, @Grade)", conn);

				param = new SqlParameter
				{
					ParameterName = "@StudentName",
					Value = dataGridViewStudents.CurrentCell.Value.ToString(),
					SqlDbType = SqlDbType.NVarChar
				};
				cmd.Parameters.Add(param);


				param = new SqlParameter
				{
					ParameterName = "@Subject",
					Value = subjectForm.SubjectName,
					SqlDbType = SqlDbType.NVarChar
				};
				cmd.Parameters.Add(param);

				param = new SqlParameter
				{
					ParameterName = "@Grade",
					Value = subjectForm.Grade,
					SqlDbType = SqlDbType.Int
				};
				cmd.Parameters.Add(param);

				try
				{
					cmd.ExecuteNonQuery();
				}
				catch
				{
					MessageBox.Show("Inserting error");
					return;
				}

				UpdateSubjectsList();
			}
		}

		private void btDeleteSubject_Click(object sender, EventArgs e)
		{
			if (subjectsTable.Rows.Count == 0)
				return;
			
			cmd = new SqlCommand("Delete From [Groups] where Subject = @Subject and StudentID = (select ID from Students where [Name] = @StudentName)", conn);
			param = new SqlParameter
			{
				ParameterName = "@Subject",
				Value = dataGridViewSubjects.CurrentRow.Cells[0].Value.ToString(),
				SqlDbType = SqlDbType.NVarChar
			};
			cmd.Parameters.Add(param);

			param = new SqlParameter
			{
				ParameterName = "@StudentName",
				Value = dataGridViewStudents.CurrentCell.Value.ToString(),
				SqlDbType = SqlDbType.NVarChar
			};
			cmd.Parameters.Add(param);

			try
			{
				cmd.ExecuteNonQuery();
			}
			catch
			{
				MessageBox.Show("Delete error");
				return;
			}

			UpdateSubjectsList();
		}

		private void btEditStudent_Click(object sender, EventArgs e)
		{
			if (studentsTable.Rows.Count == 0)
				return;

			AddStudentForm studentForm = new AddStudentForm();
			studentForm.ShowDialog();

			if (studentForm.DialogResult == DialogResult.OK)
			{
				//cmd = new SqlCommand("alter table Groups Drop Constraint FK_Group_ToStudents;" +
				//	"Update Students Set Name = @StudentName where Name = @OldStudentName;" +
				//	"Update Groups Set StudentName = @StudentName where StudentName = @OldStudentName;" +
				//	"alter table Groups add Constraint FK_Group_ToStudents FOREIGN KEY(StudentName) REFERENCES Students(Name)", conn);
				cmd = new SqlCommand("Update Students Set Name = @StudentName where Name = @OldStudentName", conn);

				param = new SqlParameter
				{
					ParameterName = "@OldStudentName",
					Value = dataGridViewStudents.CurrentCell.Value.ToString(),
					SqlDbType = SqlDbType.NVarChar
				};
				cmd.Parameters.Add(param);

				param = new SqlParameter
				{
					ParameterName = "@StudentName",
					Value = studentForm.StudentName,
					SqlDbType = SqlDbType.Text
				};
				cmd.Parameters.Add(param);

				try
				{
					cmd.ExecuteNonQuery();
				}
				catch
				{
					MessageBox.Show("Updating error");
					return;
				}

				UpdateStudentsList();
				UpdateSubjectsList();
			}
		}

		private void btEditSubject_Click(object sender, EventArgs e)
		{
			if (subjectsTable.Rows.Count == 0)
				return;

			AddSubjectForm subjectForm = new AddSubjectForm();
			subjectForm.ShowDialog();

			if (subjectForm.DialogResult == DialogResult.OK)
			{
				cmd = new SqlCommand("Update Groups Set Subject = @Subject, Grade = @Grade where StudentID = (select ID from Students where [Name] = @StudentName) and Subject = @OldSubject", conn);
				param = new SqlParameter
				{
					ParameterName = "@StudentName",
					Value = dataGridViewStudents.CurrentCell.Value.ToString(),
					SqlDbType = SqlDbType.NVarChar
				};
				cmd.Parameters.Add(param);

				param = new SqlParameter
				{
					ParameterName = "@OldSubject",
					Value = dataGridViewSubjects.CurrentRow.Cells[0].Value.ToString(),
					SqlDbType = SqlDbType.NVarChar
				};
				cmd.Parameters.Add(param);

				param = new SqlParameter
				{
					ParameterName = "@Subject",
					Value = subjectForm.SubjectName,
					SqlDbType = SqlDbType.NVarChar
				};
				cmd.Parameters.Add(param);

				param = new SqlParameter
				{
					ParameterName = "@Grade",
					Value = subjectForm.Grade,
					SqlDbType = SqlDbType.Int
				};
				cmd.Parameters.Add(param);

				try
				{
					cmd.ExecuteNonQuery();
				}
				catch
				{
					MessageBox.Show("Updating error");
					return;
				}

				UpdateSubjectsList();
			}
		}
	}
}

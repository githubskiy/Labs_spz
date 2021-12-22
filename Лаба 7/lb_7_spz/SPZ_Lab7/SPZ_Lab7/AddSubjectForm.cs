using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPZ_Lab7
{
	public partial class AddSubjectForm : Form
	{
		public string SubjectName { get; set; }
		public int Grade { get; set; }


		public AddSubjectForm()
		{
			InitializeComponent();
		}

		private void btOK_Click(object sender, EventArgs e)
		{
			SubjectName = textBoxName.Text;
			Grade = Convert.ToInt32(numericUpDownGrade.Value);
			DialogResult = DialogResult.OK;
			Hide();
		}
	}
}

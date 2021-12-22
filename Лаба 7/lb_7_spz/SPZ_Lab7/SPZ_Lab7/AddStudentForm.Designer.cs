namespace SPZ_Lab7
{
	partial class AddStudentForm
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
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(33, 55);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(100, 20);
			this.textBoxName.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(34, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Input student name";
			// 
			// btOK
			// 
			this.btOK.Location = new System.Drawing.Point(48, 97);
			this.btOK.Name = "btOK";
			this.btOK.Size = new System.Drawing.Size(75, 23);
			this.btOK.TabIndex = 2;
			this.btOK.Text = "OK";
			this.btOK.UseVisualStyleBackColor = true;
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			// 
			// AddStudentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(167, 137);
			this.Controls.Add(this.btOK);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxName);
			this.Name = "AddStudentForm";
			this.Text = "AddStudentForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btOK;
	}
}
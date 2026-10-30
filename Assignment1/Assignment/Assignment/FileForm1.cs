using System;
using System.IO;
using System.Windows.Forms;

namespace Assignment
{
    public partial class FileForm1 : Form
    {
        public FileForm1()
        {
            InitializeComponent();
        }

        // 1. CREATE - Create
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string path = txtFileName.Text.Trim();

                if (path == "")
                {
                    MessageBox.Show("Please Enter File Name!");
                    return;
                }

                using (StreamWriter sw = File.CreateText(path))
                {
                    // the file is created here
                }

                MessageBox.Show("File Created Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 2. WRITE - Write
        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                string path = txtFileName.Text.Trim();

                if (path == "")
                {
                    MessageBox.Show("Please Enter File Name!");
                    return;
                }

                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(txtInput.Text);
                }

                MessageBox.Show("Data Written Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 3. READ - Read
        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                string path = txtFileName.Text.Trim();

                if (File.Exists(path))
                {
                    using (StreamReader sr = File.OpenText(path))
                    {
                        txtOutput.Text = sr.ReadToEnd();
                    }
                }
                else
                {
                    MessageBox.Show("File Not Found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 4. APPEND - Append
        private void btnAppend_Click(object sender, EventArgs e)
        {
            try
            {
                string path = txtFileName.Text.Trim();

                if (path == "")
                {
                    MessageBox.Show("Please Enter File Name!");
                    return;
                }

                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(txtInput.Text);
                }

                MessageBox.Show("Data Appended Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 5. DELETE - Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string path = txtFileName.Text.Trim();

                if (File.Exists(path))
                {
                    DialogResult answer = MessageBox.Show(
                        "Are you sure you want to delete this file?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (answer == DialogResult.Yes)
                    {
                        File.Delete(path);
                        txtOutput.Clear();
                        MessageBox.Show("File Deleted Successfully!");
                    }
                }
                else
                {
                    MessageBox.Show("File Not Found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 6. CLEAR - Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFileName.Clear();
            txtInput.Clear();
            txtOutput.Clear();
        }
    }
}

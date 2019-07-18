using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace guiClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            GetForm getForm = new GetForm();
            getForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool success = false;
            string firstname, lastname, address, phone_number;
            InsertUserForm insertUserForm = new InsertUserForm();
            if (insertUserForm.ShowDialog() == DialogResult.OK)
            {
                success = true;
                firstname = insertUserForm.GetFirstName();
                lastname = insertUserForm.GetLastName();
                address = insertUserForm.GetAddress();
                phone_number = insertUserForm.GetPhoneNumber();
            }
            else
            {
                success = false;
            }
            insertUserForm.Dispose();

            if (success)
            {
                //Process data
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetForm getForm = new GetForm();
            getForm.SetFormHeader("Delete Form");
            getForm.SetHeader("Enter Index:");
            if (getForm.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = "Success";
            }
            else
            {
                richTextBox1.Text = "Failure";
            }
            getForm.Dispose();
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void getAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void getNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetForm getForm = new GetForm();
            getForm.SetHeader("Enter Name:");
            if (getForm.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = "Success";
            }
            else
            {
                richTextBox1.Text = "Failure";
            }
            getForm.Dispose();
        }

        private void getNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetForm getForm = new GetForm();
            getForm.SetHeader("Enter Number:");
            if (getForm.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = "Success";
            }
            else
            {
                richTextBox1.Text = "Failure";
            }
            getForm.Dispose();
        }
    }
}

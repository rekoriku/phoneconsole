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
        private Connection conn;
 
        public MainForm(Connection new_conn)
        {
            InitializeComponent();
            conn = new_conn;
            if(conn.GetConnectionStatus())
            {
                richTextBox1.Text = "Connection successful!";
            }
            else
            {
                richTextBox1.Text = "Failed to connect, restart!";
            }
        }
        private void MainForm_FormClosing(Object sender, FormClosedEventArgs e)
        {
            Networking.SendMessage(conn.GetNetworkStream(), "end");
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
            firstname = lastname = address = phone_number = "";
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
                string finalRequest = "add_rows";
                if (firstname != "" && lastname != "" && address != "" && phone_number != "")
                {
                    finalRequest += "," + lastname + "," + firstname + "," + address + "," + phone_number;
                    Networking.SendMessage(conn.GetNetworkStream(), finalRequest.ToString());
                    richTextBox1.Text = Networking.ReadMessage(conn.GetNetworkStream());
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetForm getForm = new GetForm();
            getForm.SetFormHeader("Delete");
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
            Networking.SendMessage(conn.GetNetworkStream(), "search_all_rows");
            string result = Networking.ReadMessage(conn.GetNetworkStream());
            result = result.Replace(",id:", ";id:");
            string[] result_arr = result.Split(';');
            richTextBox1.Text = "Fetch result:";
            foreach (string val in result_arr)
            {
                richTextBox1.Text += Environment.NewLine + val;
            }
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

        private void Button1_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}

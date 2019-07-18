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
    public partial class InsertUserForm : Form
    {
        public InsertUserForm()
        {
            InitializeComponent();
        }

        public string GetFirstName()
        {
            return firstnameBox.Text;
        }

        public string GetLastName()
        {
            return lastnameBox.Text;
        }

        public string GetAddress()
        {
            return addressBox.Text;
        }

        public string GetPhoneNumber()
        {
            return numberBox.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}

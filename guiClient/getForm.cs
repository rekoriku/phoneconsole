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
    public partial class GetForm : Form
    {
        private bool accept_only_numbers = false;

        public void SetAcceptOnlyNumbers(bool val)
        {
            accept_only_numbers = val;
        }

        public GetForm()
        {
            InitializeComponent();
        }

        public void SetHeader(string value)
        {
            headerBox.Text = value;
        }

        public void SetFormHeader(string value)
        {
            this.Text = value;
        }

        public string GetValue()
        {
            return valueBox.Text;
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void valueBox_TextChanged(object sender, EventArgs e)
        {
            if(accept_only_numbers)
            {
                long a;
                if (!long.TryParse(valueBox.Text, out a))
                {
                    // If not int clear textbox text or Undo() last operation
                    valueBox.Clear();
                }
            }
        }
    }
}

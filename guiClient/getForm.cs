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
        public GetForm()
        {
            InitializeComponent();
        }

        public void SetHeader(string value)
        {
            headerBox.Text = value;
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}

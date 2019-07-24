namespace guiClient
{
    partial class GetForm
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
            this.headerBox = new System.Windows.Forms.GroupBox();
            this.submitBtn = new System.Windows.Forms.Button();
            this.valueLabel = new System.Windows.Forms.Label();
            this.valueBox = new System.Windows.Forms.TextBox();
            this.headerBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerBox
            // 
            this.headerBox.Controls.Add(this.submitBtn);
            this.headerBox.Controls.Add(this.valueLabel);
            this.headerBox.Controls.Add(this.valueBox);
            this.headerBox.Location = new System.Drawing.Point(12, 12);
            this.headerBox.Name = "headerBox";
            this.headerBox.Size = new System.Drawing.Size(277, 76);
            this.headerBox.TabIndex = 1;
            this.headerBox.TabStop = false;
            this.headerBox.Text = "Specify Value";
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(44, 45);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(193, 23);
            this.submitBtn.TabIndex = 8;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // valueLabel
            // 
            this.valueLabel.AutoSize = true;
            this.valueLabel.Location = new System.Drawing.Point(9, 22);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(34, 13);
            this.valueLabel.TabIndex = 1;
            this.valueLabel.Text = "Value";
            // 
            // valueBox
            // 
            this.valueBox.Location = new System.Drawing.Point(44, 19);
            this.valueBox.Name = "valueBox";
            this.valueBox.Size = new System.Drawing.Size(193, 20);
            this.valueBox.TabIndex = 0;
            this.valueBox.TextChanged += new System.EventHandler(this.valueBox_TextChanged);
            // 
            // GetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 105);
            this.Controls.Add(this.headerBox);
            this.Name = "GetForm";
            this.Text = "Get";
            this.headerBox.ResumeLayout(false);
            this.headerBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox headerBox;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.TextBox valueBox;
    }
}
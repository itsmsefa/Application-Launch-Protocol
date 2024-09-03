namespace App2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelInfo = new Label();
            listBoxParams = new ListBox();
            SuspendLayout();
            // 
            // labelInfo
            // 
            labelInfo.AutoSize = true;
            labelInfo.Location = new Point(12, 64);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(67, 15);
            labelInfo.TabIndex = 0;
            labelInfo.Text = "Arguments";
            labelInfo.Click += labelInfo_Click;
            // 
            // listBoxParams
            // 
            listBoxParams.FormattingEnabled = true;
            listBoxParams.ItemHeight = 15;
            listBoxParams.Location = new Point(12, 92);
            listBoxParams.Name = "listBoxParams";
            listBoxParams.Size = new Size(251, 184);
            listBoxParams.TabIndex = 1;
            listBoxParams.SelectedIndexChanged += listBoxParams_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBoxParams);
            Controls.Add(labelInfo);
            Name = "Form1";
            Text = "App2";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelInfo;
        private ListBox listBoxParams;
    }
}

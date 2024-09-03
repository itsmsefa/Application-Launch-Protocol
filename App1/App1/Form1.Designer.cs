namespace App1
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
            ListBox listBoxParams;
            labelInfo = new Label();
            listBoxParams = new ListBox();
            SuspendLayout();
            // 
            // listBoxParams
            // 
            listBoxParams.FormattingEnabled = true;
            listBoxParams.ItemHeight = 15;
            listBoxParams.Location = new Point(525, 286);
            listBoxParams.Name = "listBoxParams";
            listBoxParams.Size = new Size(250, 139);
            listBoxParams.TabIndex = 0;
            listBoxParams.SelectedIndexChanged += listBoxParams_SelectedIndexChanged;
            // 
            // labelInfo
            // 
            labelInfo.AutoSize = true;
            labelInfo.Location = new Point(525, 268);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(67, 15);
            labelInfo.TabIndex = 1;
            labelInfo.Text = "Arguments";
            labelInfo.Click += labelInfo_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelInfo);
            Controls.Add(listBoxParams);
            Name = "Form1";
            Text = "App1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxParams;
        private Label labelInfo;
    }
}

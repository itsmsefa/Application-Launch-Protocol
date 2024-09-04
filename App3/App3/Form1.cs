using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;
using System.Web;

namespace App3
{
    public partial class Form1 : Form
    {
        private const string AppProtocol = "myapp://";

        public Form1(string[] args)
        {
            InitializeComponent();
            SetupCustomControls();
            ListParams(args);
        }

        private void SetupCustomControls()
        {
            this.listBoxParams = new ListBox
            {
                Dock = DockStyle.Fill
            };
            this.labelInfo = new Label
            {
                Dock = DockStyle.Top,
                Height = 30
            };

            this.Controls.Add(this.listBoxParams);
            this.Controls.Add(this.labelInfo);

            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Text = "App3";
        }

        private void ListParams(string[] args)
        {
            if (args.Length == 0)
            {
                MessageBox.Show("No arguments provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string paramString = args[0];
            var keyValuePairs = paramString.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            int pairs = keyValuePairs.Length;

            labelInfo.Text = $"Received {pairs} parameter(s)";

            listBoxParams.Items.Clear();

            foreach (var pair in keyValuePairs)
            {
                listBoxParams.Items.Add(pair);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBoxParams_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelInfo_Click(object sender, EventArgs e)
        {

        }
    }
}

using System.Collections.Specialized;
using System.Security.Policy;
using System.Web;

namespace App1
{
    public partial class Form1 : Form
    {

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
            this.Text = "App1";
        }

        private void ListParams(string[] args)
        {
            if (args.Length > 0)
            {
                string parameters = args[0];

                NameValueCollection collection = ConvertStringArgsToNameValueCollection(parameters);

                foreach (string? key in collection.AllKeys)
                {
                    listBoxParams.Items.Add($"{key}: {collection[key]}");
                }
                labelInfo.Text = $"Received {collection.Count} parameter(s)";
            }
            else
            {
                labelInfo.Text = "No arguments received";
            }
        }


        public static NameValueCollection ConvertStringArgsToNameValueCollection(string argsString)
        {
            var collection = new NameValueCollection();
            string[] args = argsString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < args.Length; i += 2)
            {
                string key = args[i];
                string value = (i + 1 < args.Length) ? args[i + 1] : string.Empty;

                // Remove any leading dashes from the key if present
                key = key.TrimStart('-');

                collection.Add(key, value);
            }

            return collection;
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

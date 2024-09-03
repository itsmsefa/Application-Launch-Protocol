using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;
using System.Web;

namespace App2
{
    public partial class Form1 : Form
    {
        private const string AppProtocol = "myapp://";

        public Form1(string[] args)
        {
            InitializeComponent();
            SetupCustomControls();
            ParseAndDisplayArgs(args);
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
            this.Text = "App2";
        }

        private void ParseAndDisplayArgs(string[] args)
        {
            if (args.Length > 0)
            {
                string url = args[0];
                if (url.StartsWith(AppProtocol))
                {
                    Uri uri = new Uri(url);
                    string query = uri.Query;

                    if (!string.IsNullOrEmpty(query))
                    {
                        var parameters = HttpUtility.ParseQueryString(query);
                        foreach (string key in parameters.AllKeys)
                        {
                            listBoxParams.Items.Add($"{key}: {parameters[key]}");
                        }
                        labelInfo.Text = $"Received {parameters.Count} parameter(s)";
                    }
                    else
                    {
                        labelInfo.Text = "No parameters received";
                    }
                }
                else
                {
                    labelInfo.Text = "Invalid URL format";
                }
            }
            else
            {
                labelInfo.Text = "No arguments received";
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

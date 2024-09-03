using static System.Runtime.InteropServices.Marshalling.IIUnknownCacheStrategy;
using System.Web;

namespace App1
{
    public partial class Form1 : Form
    {
        private string AppProtocol = "myapp://";

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
            this.Text = "App1";
        }

        private void ParseAndDisplayArgs(string[] args)
        {
            if (args.Length > 0)
            {
                string url = args[0];


                // Split the URL by the "?" character to separate the base URL and the query string
                var parts = url.Split('?');

                if (parts.Length > 1)
                {
                    string baseUrl = parts[0];
                    string query = parts[1];



                    // Check if the base URL matches the expected protocol and path
                    if (baseUrl.StartsWith(AppProtocol, StringComparison.OrdinalIgnoreCase))
                    {
                        var parameters = HttpUtility.ParseQueryString(query);
                        foreach (string? key in parameters.AllKeys)
                        {
                            listBoxParams.Items.Add($"{key}: {parameters[key]}");
                        }
                        labelInfo.Text = $"Received {parameters.Count} parameter(s)" + " " + url;
                    }
                    else
                    {
                        labelInfo.Text = "Invalid URL format";
                    }
                }
                else
                {
                    labelInfo.Text = "No parameters received";
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

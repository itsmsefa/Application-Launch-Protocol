using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Web;

namespace AppController
{
    class Program()
    {
        private static readonly string baseDirectory = "D:\\MyApps\\";

        static void Main(string[] args)
        {
            string appProtocol = "myapp://";

            if (args.Length > 0)
            {
                string url = args[0];

                // Print the raw URL for debugging
                Console.WriteLine($"Raw URL: {url}");

                if (string.IsNullOrEmpty(url))
                {
                    Console.WriteLine("URL is missing");
                    return;
                }

                string appToRun;
                //Split the URL by the '?' char to seperate the base and query parts 
                url = url.Replace(appProtocol, "");
                var urlParts = url.Split('?');
                if (urlParts.Length == 0)
                {
                    Console.WriteLine("App name missing in the URL");
                    return;
                }
                else if (urlParts.Length >= 1)
                {
                    appToRun = urlParts[0];
                    // Print the extracted app name for debugging
                    Console.WriteLine($"Extracted App Name: {appToRun}");

                    string params_str = "";
                    if (urlParts.Length > 1)
                    {
                        string query = urlParts[1];
                        var paramsCollection = HttpUtility.ParseQueryString(query);
                        var keyValuePairs = paramsCollection.AllKeys.Select(k => $"{k} => {paramsCollection[k]}");
                        params_str = string.Join(", ", keyValuePairs);


                        Console.WriteLine($"Recieved {paramsCollection.Count} parameters(s)");

                        // The foreach loop will iterate over the params collection and print the key and value for each param
                        foreach (var key in paramsCollection.AllKeys)
                        {
                            Console.WriteLine($"Key: {key} => Value: {paramsCollection[key]}");
                        }
                    }

                    try
                    {
                        // Launch the appropriate app with parameters
                        RunApp(appToRun, params_str);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No parameters received!");
                }

            }
            else
            {
                Console.WriteLine("No arguments recieved!");
            }
        }



        static void RunApp(string app, string parameter)
        {

            if (string.IsNullOrWhiteSpace(app))
                throw new ArgumentException("App identifier cannot be empty!", nameof(app));


            app = app.Trim('/');

            var match = Regex.Match(app, @"^App(\d+)$");
            if (!match.Success)
                throw new ArgumentException($"Invalid app identifier format: {app}", nameof(app));

            string appNumber = match.Groups[1].Value;
            string appName = $"App{appNumber}";
            string exePath = Path.Combine(baseDirectory, appName, appName, "bin", "Debug", "net8.0-windows", $"{appName}.exe");

            if (!File.Exists(exePath))
                throw new FileNotFoundException($"Executable not found for {app}", exePath);

            // Start the process with the command-line parameters
            ProcessStartInfo startInfo = new ProcessStartInfo(exePath)
            {
                ArgumentList = { parameter }
            };
            Process.Start(startInfo);
        }
    }
}

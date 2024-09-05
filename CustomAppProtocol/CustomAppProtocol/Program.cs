using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Web;

namespace AppController
{
    class Program()
    {
        private readonly string baseDirectory = "D:\\MyApps\\";

        static void Main(string[] args)
        {
            string AppProtocol = "myapp://";

            if (args.Length > 0)
            {
                string url = args[0];

                // Print the raw URL for debugging
                Console.WriteLine($"Raw URL: {url}");

                // Extract the app identifier from the URL
                string appToRun = url.Replace("myapp://", "").ToLower();
                

                int index = appToRun.IndexOf("?");
                if (index >= 0)
                {
                    appToRun = appToRun.Substring(0, index);
                }

                //Split the URL by the '?' char to seperate the base and query parts 
                var parts = url.Split('?');

                if (parts.Length > 1)
                {
                    string baseUrl = parts[0];
                    string query = parts[1];

                    //Check if the base URL match the protocol 
                    if (baseUrl.StartsWith(AppProtocol, StringComparison.OrdinalIgnoreCase))
                    {
                        var paramsCollection = HttpUtility.ParseQueryString(query);
                        var keyValuePairs = paramsCollection.AllKeys.Select(k => $"{k} => {paramsCollection[k]}");
                        var params_str = string.Join(", ", keyValuePairs);


                        Console.WriteLine($"Recieved {paramsCollection.Count} parameters(s)");

                        // The foreach loop will iterate over the params collection and print the key and value for each param
                        foreach (var key in paramsCollection.AllKeys)
                        {
                            Console.WriteLine($"Key: {key} => Value: {paramsCollection[key]}");
                        }

                        // Launch the appropriate app with parameters
                        try
                        {
                            RunApp(appToRun, params_str);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid URL format!");
                    }

                }
                else
                {
                    Console.WriteLine("No parameters received!");
                }

                // Print the extracted app name for debugging
                Console.WriteLine($"Extracted App Name: {appToRun}");

            }
            else
            {
                Console.WriteLine("No arguments recieved!");
            }
        }

        

        static void RunApp(string app, string parameter)
        {
            var bD = new Program();

            if (string.IsNullOrWhiteSpace(app))
                throw new ArgumentException("App identifier cannot be empty!", nameof(app));

            app = app.Trim('/');

            var match = Regex.Match(app, @"^app(\d+)$");
            if (!match.Success)
                throw new ArgumentException($"Invalid app identifier format: {app}", nameof(app));

            string appNumber = match.Groups[1].Value;
            string appName = $"App{appNumber}";
            string exePath = Path.Combine(bD.baseDirectory, appName, appName, "bin", "Debug", "net8.0-windows", $"{appName}.exe");

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

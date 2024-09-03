using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Web;

namespace AppController
{
    class Program
    {
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
                appToRun.Replace("/", "");

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

                        var values = paramsCollection.Cast<string>().Select(e => paramsCollection[e]);

                        var params_str = string.Join(",", values);


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

            // Keep the console open for debugging
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }

        


        static void RunApp(string app, string parameter)
        {
            string appPath = app switch
            {
                "app1/" => @"D:\MyApps\App1\App1\bin\Debug\net8.0-windows\App1.exe",
                "app2/" => @"D:\MyApps\App2\App2\bin\Debug\net8.0-windows\App2.exe",
                "app3/" => @"D:\MyApps\App3\App3\bin\Debug\net8.0-windows\App3.exe",
                _ => throw new ArgumentException("Unknown app."),
            };

            // Start the process with the command-line parameters
            ProcessStartInfo startInfo = new ProcessStartInfo(appPath)
            {
                ArgumentList = {parameter}
            };
            Process.Start(startInfo);
        }
    }
}

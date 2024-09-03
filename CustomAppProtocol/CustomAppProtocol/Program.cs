using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Web;

namespace AppController
{
    class Program
    {
        static void Main(string[] args)
        {
            Debugger.Launch();
            try
            {
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

                    // Print the extracted app name for debugging
                    Console.WriteLine($"Extracted App Name: {appToRun}");
                    appToRun.Replace("/", "");

                    // Extract the query parameters
                    //Uri uri = new Uri(url);
                    //NameValueCollection queryParameters = HttpUtility.ParseQueryString(uri.Query);

                    // Convert the parameters to a command-line string
                    //string parameters = ConvertParametersToCommandLine(queryParameters);
                    string parameter = url;

                    // Launch the appropriate app with parameters
                    try
                    {
                        RunApp(appToRun, parameter);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No arguments provided.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            // Keep the console open for debugging
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }

        /*static string ConvertParametersToCommandLine(NameValueCollection queryParameters)
        {
            string parameters = string.Empty;

            if (queryParameters?.AllKeys != null)
            {
                foreach (string? key in queryParameters.AllKeys)
                {
                    if (key != null)
                    {
                        parameters += $"{key}={queryParameters[key]} ";
                    }
                }
            }

            return parameters.Trim(); // Trim to remove the trailing space
        }*/


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
                //Arguments = parameters
                //Arguments = "customerID=12345 screenNumber=1"
                //Arguments = "myapp://app1/?customerID=12345&scrnNmbr=1"
                Arguments = parameter
            };
            Console.WriteLine("parameter: " + parameter);
            Process.Start(startInfo);
        }
    }
}

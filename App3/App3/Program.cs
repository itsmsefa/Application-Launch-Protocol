namespace App3
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            const string appName = "App3";
            string mutexName = $"Global\\{appName}Mutex";

            using var mutex = new Mutex(true, mutexName, out bool createdNew);
            if (!createdNew)
            {
                // The app is already running
                MessageBox.Show($"{appName} is already running.", "Instance Check",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // Exit the application
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(args));
        }
    }
}
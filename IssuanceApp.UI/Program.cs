// Program.cs
using IssuanceApp.Data;
using System;
using System.Configuration;
using System.Windows.Forms;

// --- THIS IS THE CORRECT NAMESPACE TO MATCH YOUR PROJECT SETTINGS ---
namespace IssuanceApp.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // 1. Check if the connection string section exists and is valid
                ConnectionStringSettings connSettings = ConfigurationManager.ConnectionStrings["IssuanceAppDB"];
                if (connSettings == null || string.IsNullOrEmpty(connSettings.ConnectionString))
                {
                    throw new ConfigurationErrorsException("The connection string 'IssuanceAppDB' is missing or empty in the application configuration file.");
                }

                string connStr = connSettings.ConnectionString;

                // 2. Instantiate repository and run the application
                var repository = new IssuanceRepository(connStr);

                Application.Run(new MainForm(repository));
            }
            catch (Exception ex)
            {
                // Log the critical startup error
                string errorMessage = $"A fatal error occurred during application startup and it must close:\n\n{ex.Message}";

                MessageBox.Show(errorMessage, "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
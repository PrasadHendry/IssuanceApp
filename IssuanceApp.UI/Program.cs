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
                string connStr = ConfigurationManager.ConnectionStrings["IssuanceAppDB"].ConnectionString;
                var repository = new IssuanceRepository(connStr);

                Application.Run(new MainForm(repository));
            }
            catch (Exception ex)
            {
                MessageBox.Show("A fatal error occurred during application startup and it must close:\n\n" + ex.Message,
                                "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
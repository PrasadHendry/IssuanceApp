// Program.cs

// --- UPDATE THE USING STATEMENTS TO MATCH THE NEW NAMESPACE ---
using DocumentIssuanceApp;
using IssuanceApp.Data;
using IssuanceApp.UI.Controls; // Assuming your controls are in this namespace now
using System;
using System.Configuration;
using System.Windows.Forms;

// --- THIS IS THE FIX ---
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

                // The 'new MainForm(repository)' call will now work because
                // MainForm will also be in the 'IssuanceApp.UI' namespace.
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
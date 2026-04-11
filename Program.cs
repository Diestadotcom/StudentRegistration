using System;
using System.Windows.Forms;

namespace StudentRegistration
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread] // <--- This is the attribute
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // This starts your specific form
            Application.Run(new StudentRegistration());
        }
    }
}

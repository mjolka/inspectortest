using System;
using System.Windows.Forms;

namespace InspectorTest
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
            var inspector = new Inspector();
            var inspectorService = new InspectorService(inspector);
            Application.Run(new Form1(inspectorService));
        }
    }
}

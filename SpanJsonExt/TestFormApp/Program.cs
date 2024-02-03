using System;
using System.Windows.Forms;

namespace TestFormApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Data.Actions.Polygon.PolygonMinuteScan.Start();
            PolygonDayTests.Start();
            // PolygonSymbolsTests.Start();

            Application.Run(new Form1());
        }
    }
}

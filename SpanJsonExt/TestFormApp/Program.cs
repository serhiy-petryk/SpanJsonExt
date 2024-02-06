using System;
using System.Diagnostics;
using System.Windows.Forms;
using TestFormApp.Tests;

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

            /*// SpanJsonExt.Tests.ReadFile.TraceTest();
            SpanJsonExt.Tests.ReadFile.TestFileToByte2();
            SpanJsonExt.Tests.ReadFile.TestFileToByte3();
            SpanJsonExt.Tests.ReadFile.TestFileToByte4();
            SpanJsonExt.Tests.ReadFile.TestFileToByte1();
            SpanJsonExt.Tests.ReadFile.TestFileToByte11();

            StreamTests.TestFileToByte2();
            StreamTests.TestFileToByte3();
            StreamTests.TestFileToByte4();
            StreamTests.TestFileToByte1();
            StreamTests.TestFileToByte11();

            StreamTests.TestZipContent();
            StreamTests.TestZipBytes();
            // StreamTests.TestZipStream();*/


            // Data.Actions.Polygon.PolygonMinuteScan.Start();
            PolygonDayTests.Start();
            // PolygonSymbolsTests.Start();

            Application.Run(new Form1());
        }
    }
}

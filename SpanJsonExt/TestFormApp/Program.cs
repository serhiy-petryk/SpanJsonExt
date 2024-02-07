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

            // Performance.PerfomanceTest.Start_OnlyReadZipFile();
            // Performance.PerfomanceTest.Start_ReadZipFileAndDeserialize();

            // Data.Actions.Polygon.PolygonMinuteScan.Start();

            // PolygonDayTests.Start();
            // PolygonSymbolsTests.Start();

            Tests.Resolvers.RunTest();

            // UnquotedName.Tests.StartUtf8();
            // UnquotedName.Tests.StartUtf16();

            Application.Run(new Form1());
        }
    }
}

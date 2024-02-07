using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Data.Actions.Polygon;

namespace TestFormApp.Performance
{
    public static class PerfomanceTest
    {
        private const string ZipFileName = @"E:\Temp\Exchange\MP2003_20231230.zip";

        public static void Start_OnlyReadZipFile()
        {
            var sw = new Stopwatch();
            sw.Start();
            var a1 = Environment.TickCount;

            var itemCount = 0;
            var byteCount = 0;
            foreach (var item in GetData_OnlyReadZipFile())
            {
                if (itemCount % 500 == 0)
                    Debug.Print($"Items: {itemCount}. {sw.ElapsedMilliseconds / 1000}");

                itemCount++;
                byteCount += item.Item2.Length;
            }

            sw.Stop();
            var a2 = Environment.TickCount;

            Debug.Print($"ReadZipFile Finished!!! {sw.Elapsed.TotalMilliseconds:N0} seconds. Items: {itemCount:N0}. Bytes: {byteCount:N0}. Ticks: {(a2 - a1):N0}");
        }

        public static void Start_ReadZipFileAndDeserialize()
        {
            var sw = new Stopwatch();
            sw.Start();
            var a1 = Environment.TickCount;

            var itemCount = 0;
            var byteCount = 0;
            foreach (var item in GetData_ReadZipFileAndDeserialize())
            {
                if (itemCount % 500 == 0)
                    Debug.Print($"Items: {itemCount}. {sw.ElapsedMilliseconds / 1000}");

                itemCount++;
                byteCount += item.Item2.Length;
            }

            sw.Stop();
            var a2 = Environment.TickCount;

            Debug.Print($"ReadZipFileAndDeserialize Finished!!! {sw.Elapsed.TotalMilliseconds:N0} seconds. Items: {itemCount:N0}. Bytes: {byteCount:N0}. Ticks: {(a2 - a1):N0}.");
            // 500 files: x2=25 294 863. 10 212 millisecs.
        }

        private static IEnumerable<(string, byte[])> GetData_OnlyReadZipFile()
        {
            using (var zip = ZipFile.Open(ZipFileName, ZipArchiveMode.Read))
                foreach (var entry in zip.Entries.Where(a => a.Length != 0).Take(500))
                    using (var stream = entry.Open())
                    using (var ms = new MemoryStream())
                    {
                        stream.CopyTo(ms);
                        yield return (entry.Name, ms.ToArray());
                    }
        }
        private static IEnumerable<(string, PolygonCommon.cMinuteItem[])> GetData_ReadZipFileAndDeserialize()
        {
            using (var zip = ZipFile.Open(ZipFileName, ZipArchiveMode.Read))
                foreach (var entry in zip.Entries.Where(a => a.Length != 0).Take(500))
                    using (var stream = entry.Open())
                    using (var ms = new MemoryStream())
                    {
                        stream.CopyTo(ms);
                        // var bytes = ms.ToArray();
                        // var s = System.Text.Encoding.UTF8.GetString(bytes);
                        var jsonData = SpanJson.JsonSerializer.Generic.Utf8.Deserialize<PolygonCommon.cMinuteRoot>(ms.ToArray());
                        if (jsonData.count != 0)
                            yield return (entry.Name, jsonData.results);
                    }
        }
    }
}

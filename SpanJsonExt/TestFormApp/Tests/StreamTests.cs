using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFormApp.Tests
{
    public static class StreamTests
    {
        private const string zipFileName = @"E:\Temp\Exchange\MP2003_20221105.zip";

        public static void TestFileToByte4()
        {
            var sw = new Stopwatch();
            sw.Start();

            byte[] bytes = new byte[new FileInfo(zipFileName).Length];
            using (StreamReader reader = new StreamReader(zipFileName))
            {
                var i = reader.BaseStream.Read(bytes);
            }

            // var bytes = File.ReadAllBytes(zipFileName);
            sw.Stop();

            Debug.Print($"TestFileToByte4: {sw.ElapsedMilliseconds} milliseconds. Length: {bytes.Length:N0}");
        }

        public static void TestFileToByte3()
        {
            var sw = new Stopwatch();
            sw.Start();

            byte[] bytes;
            using (StreamReader reader = new StreamReader(zipFileName))
            using (var memstream = new MemoryStream())
            {
                reader.BaseStream.CopyTo(memstream);
                bytes = memstream.ToArray();
            }

            sw.Stop();

            Debug.Print($"TestFileToByte3: {sw.ElapsedMilliseconds} milliseconds. Length: {bytes.Length:N0}");
        }

        public static void TestFileToByte1()
        {
            var sw = new Stopwatch();
            sw.Start();

            var bytes = File.ReadAllBytes(zipFileName);
            sw.Stop();

            Debug.Print($"TestFileToByte1: {sw.ElapsedMilliseconds} milliseconds. Length: {bytes.Length:N0}");
        }

        public static void TestFileToByte11()
        {
            var sw = new Stopwatch();
            sw.Start();

            var cnt = 0;
            var bytes = File.ReadAllBytes(zipFileName);
            foreach (var b in bytes)
                cnt++;

            sw.Stop();

            Debug.Print($"TestFileToByte11: {sw.ElapsedMilliseconds} milliseconds. Length: {cnt}");
        }

        public static void TestFileToByte2()
        {
            var sw = new Stopwatch();
            sw.Start();

            var bytes = FileToByteArray(zipFileName);
            sw.Stop();

            Debug.Print($"TestFileToByte2: {sw.ElapsedMilliseconds} milliseconds. Length: {bytes.Length:N0}");
        }


        public static void TestZipStream()
        {
            var sw = new Stopwatch();
            sw.Start();
            var cnt = 0;
            using (var zip = ZipFile.Open(zipFileName, ZipArchiveMode.Read))
            {
                foreach (var entry in zip.Entries)
                {
                    using (var stream = entry.Open())
                    {
                        foreach (var b in StreamAsIEnumerable(stream))
                        {
                            cnt++;
                        }
                    }
                }
            }
            sw.Stop();

            Debug.Print($"TestZipStream: {sw.ElapsedMilliseconds} milliseconds. Length: {cnt:N0}");
        }

        public static void TestZipContent()
        {
            var sw = new Stopwatch();
            sw.Start();
            var cnt = 0;
            using (var zip = ZipFile.Open(zipFileName, ZipArchiveMode.Read))
            {
                foreach (var entry in zip.Entries)
                {
                    var s = GetContentOfZipEntry(entry);
                    cnt += s.Length;

                }
            }
            sw.Stop();

            Debug.Print($"TestZipContent: {sw.ElapsedMilliseconds} milliseconds. Length: {cnt:N0}");
        }

        public static void TestZipBytes()
        {
            var sw = new Stopwatch();
            sw.Start();
            var cnt = 0;
            using (var zip = ZipFile.Open(zipFileName, ZipArchiveMode.Read))
            {
                foreach (var entry in zip.Entries)
                {
                    var bytes = GetBytesOfZipEntry(entry);
                    cnt += bytes.Length;

                }
            }
            sw.Stop();

            Debug.Print($"TestZipContent: {sw.ElapsedMilliseconds} milliseconds. Length: {cnt:N0}");
        }

        public static IEnumerable<byte> StreamAsIEnumerable(Stream stream)
        {
            if (stream != null)
                for (int i = stream.ReadByte(); i != -1; i = stream.ReadByte())
                    yield return (byte)i;
        }

        public static string GetContentOfZipEntry(this ZipArchiveEntry entry)
        {
            using (var entryStream = entry.Open())
            using (var reader = new StreamReader(entryStream, System.Text.Encoding.UTF8, true))
                return reader.ReadToEnd();
        }
        public static byte[] GetBytesOfZipEntry(this ZipArchiveEntry entry)
        {
            using (var entryStream = entry.Open())
            using (var memstream = new MemoryStream())
            {
                entryStream.CopyTo(memstream);
                return memstream.ToArray();
            }
        }

        public static byte[] FileToByteArray(string fileName)
        {
            byte[] fileData = null;

            using (FileStream fs = File.OpenRead(fileName))
            {
                using (BinaryReader binaryReader = new BinaryReader(fs))
                {
                    fileData = binaryReader.ReadBytes((int)fs.Length);
                }
            }
            return fileData;
        }

    }
}

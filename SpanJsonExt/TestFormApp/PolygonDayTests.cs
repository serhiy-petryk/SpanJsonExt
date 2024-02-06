using System;
using System.IO;

namespace TestFormApp
{
    class PolygonDayTests
    {
        public static void Start()
        {
            var content = File.ReadAllText(@"E:\Quote\WebData\Daily\Polygon2003\DayPolygon_20240110.json");
            var oo = SpanJson.JsonSerializer.Generic.Utf16.Deserialize<cRoot>(content);
        }

        #region ===========  Json SubClasses  ===========
        private class cRoot
        {
            public int queryCount;
            public int resultsCount;
            public bool adjusted;
            public cItem[] results;
            public string status;
            public string request_id;
            public int count;
        }

        private class cItem
        {
            public string T;
            public float v;
            public float vw;
            public float o;
            public float h;
            public float l;
            public float c;
            public long t;
            public int n;

            public string Symbol => T;
            public DateTime Date => DateTime.Today; // CsUtils.GetEstDateTimeFromUnixMilliseconds(t);
            public float Open => o;
            public float High => h;
            public float Low => l;
            public float Close => c;
            public float Volume => v;
            public float WeightedVolume => vw;
            public int TradeCount => n;
        }
        #endregion

    }
}

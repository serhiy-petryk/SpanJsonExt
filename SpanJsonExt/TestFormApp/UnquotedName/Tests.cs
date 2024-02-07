using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpanJson;
using SpanJson.Resolvers;

namespace TestFormApp.UnquotedName
{
    public static class Tests
    {
        private const string Json1 = "{\"type\":\"xxxx\",\"data\":{\"action\":\"all\",\"number\":123}}";
        private const string Json2 = "{\"type\":\"xxxx\",\"data\":{action:\"all\",\"number\":123}}";
        private static readonly string LiveContent = File.ReadAllText(@"E:\Quote\WebData\Symbols\Polygon2003\PropertiesWithoutQuotes.json");
        private static readonly SpanJsonOptions Options = new SpanJsonOptions() { AllowUnquotedStrings = true };


        public static void StartUtf16()
        {
            // var oo = SpanJson.JsonSerializer.Generic.Utf16.Deserialize<cRoot>(Json2);
            var content1 = File.ReadAllText(@"E:\Quote\WebData\Symbols\Polygon2003\SymbolsPolygon.Original.json");
            var content = File.ReadAllText(@"E:\Quote\WebData\Symbols\Polygon2003\SymbolsPolygon.json");
            // var oo1 = SpanJson.JsonSerializer.NonGeneric.Utf16.Deserialize(content, typeof(cRootSymbols));
         /*   var oo = SpanJson.JsonSerializer.Generic.Utf16.Deserialize<cRootSymbols>(content, Options);
            var oo2 = SpanJson.JsonSerializer.Generic.Utf16.Deserialize<cRoot>(LiveContent, Options);
            var oo3 = SpanJson.JsonSerializer.Generic.Utf16.Deserialize<cRoot>(LiveContent, Options);*/
        }

        public static void StartUtf8()
        {
            // var oo = SpanJson.JsonSerializer.Generic.Utf16.Deserialize<cRoot>(Json2);
            var content1 = File.ReadAllText(@"E:\Quote\WebData\Symbols\Polygon2003\SymbolsPolygon.Original.json");
            var content = File.ReadAllText(@"E:\Quote\WebData\Symbols\Polygon2003\SymbolsPolygon.json");
/*            var oo1 = SpanJson.JsonSerializer.Generic.Utf8.Deserialize<object>(ToBytes(content), Options);
            var oo = SpanJson.JsonSerializer.Generic.Utf8.Deserialize<cRootSymbols>(ToBytes(content), Options);
            var oo2 = SpanJson.JsonSerializer.Generic.Utf8.Deserialize<cRoot>(ToBytes(LiveContent), Options);
            var oo3 = SpanJson.JsonSerializer.Generic.Utf8.Deserialize<cRoot>(ToBytes(LiveContent), Options);*/

            byte[] ToBytes(string s) => System.Text.Encoding.UTF8.GetBytes(s);
        }


        #region =======  Json subclasses  =============
        public class cRoot
        {
            public string type;
            public cData data;
        }
        public class cData
        {
            public string action;
            public string type;
            public object props;
            public cItem[] data;
            public int fullCount;
        }
        public class cItem
        {
            public string date;
            public string type;
            public string symbol;
            public string name;
            public string other;
            public string text;

            public DateTime Date => DateTime.Parse(date, CultureInfo.InvariantCulture);
            public string Symbol => symbol.StartsWith("$") ? symbol.Substring(1) : symbol;
            public string Other => other == "N/A" || string.IsNullOrEmpty(other) ? null : other;
            public string Name => string.IsNullOrEmpty(name) ? null : name;

            public override string ToString() => $"{Date:yyyy-MM-dd}, {Symbol}, {type}, {Other}, {text}";
        }
        #endregion


        #region ===========  Json SubClasses  ===========

        private class cRootSymbols
        {
            public int count;
            private int privateField;
            private int privateProperty { get; set; }
            public int Count { get; set; } //=> count;
            public string next_url;
            public string request_id;
            public cItemSymbols[] results;
            public string status;
        }
        private class cItemSymbols
        {
            public string ticker;
            public string xticker;
            public string name;
            public string market; // stocks, otc, indices, fx, crypto
            public string locale;
            public string primary_exchange;
            public string type;
            public bool active;
            public string currency_name;
            public string cik;
            public string composite_figi;
            public string share_class_figi;
            public DateTime last_updated_utc;
            public DateTime delisted_utc;

            // public string pSymbol => PolygonCommon.GetMyTicker(ticker);
            /*public string Ticker
            {
                get { return ticker; }
                set { ticker = value; }
            }

            public string pSymbol => ticker;
            public DateTime pDate;
            public string pName => string.IsNullOrEmpty(name) ? null : name;
            public string pExchange => string.IsNullOrEmpty(primary_exchange) ? "No" : primary_exchange;

            public DateTime pTimeStamp;*/
        }
        #endregion

        public class cJson
        {
            public string type;
            public cJsonData data;
        }

        public class cJsonData
        {
            public string action;
            public int number;
        }
    }
}

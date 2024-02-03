using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFormApp
{
    class Tests
    {
        public static void Start()
        {
            var content = File.ReadAllText(@"E:\Quote\WebData\Symbols\Polygon2003\SymbolsPolygon_04_20240118.json");
            var oo = SpanJson.JsonSerializer.Generic.Utf16.Deserialize<cRoot>(content);

        }

        #region ===========  Json SubClasses  ===========

        private class cRoot
        {
            public int count;
            public string next_url;
            public string request_id;
            public cItem[] results;
            public string status;
        }
        private class cItem
        {
            public string ticker;
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
            public string pSymbol => ticker;
            public DateTime pDate;
            public string pName => string.IsNullOrEmpty(name) ? null : name;
            public string pExchange => string.IsNullOrEmpty(primary_exchange) ? "No" : primary_exchange;

            public DateTime pTimeStamp;
        }
        #endregion

    }
}

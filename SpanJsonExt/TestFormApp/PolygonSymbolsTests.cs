using System;
using System.IO;
using SpanJson.Resolvers;

namespace TestFormApp
{
    class PolygonSymbolsTests
    {
        /*public sealed class CustomResolver<TSymbol> : ResolverBase<TSymbol, CustomResolver<TSymbol>> where TSymbol : struct
        {
            public CustomResolver() : base(new SpanJsonOptions
            {
                NullOption = NullOptions.ExcludeNulls,
                NamingConvention = NamingConventions.CamelCase,
                EnumOption = EnumOptions.Integer,
                ByteArrayOptions = ByteArrayOptions.Base64
            })
            {
            }
        }*/
        public static void Start()
        {
/*            return Expression.Assign(Expression.PropertyOrField(returnValue, memberInfo.MemberName),
                Expression.Call(Expression.Field(null, fieldInfo),
                    FindPublicInstanceMethod(formatterType, "Deserialize", readerParameter.Type.MakeByRefType()),
                    readerParameter));*/

            // var fi = typeof(cRoot).GetField("count");

            var a1 = new SpanJsonOptions()
                {NamingConvention = NamingConventions.CamelCase};

            var content = File.ReadAllText(@"E:\Quote\WebData\Symbols\Polygon2003\SymbolsPolygon_04_20240118.json");
            var content1 = File.ReadAllText(@"E:\Quote\WebData\Symbols\Polygon2003\SymbolsPolygon_04_20240118.Original.json");
            var bytes = System.Text.Encoding.UTF8.GetBytes(content);
            var oo2 = SpanJson.JsonSerializer.Generic.Utf16.Deserialize<cRoot>(content);
            // var oo1 = SpanJson.JsonSerializer.Generic.Utf8.Deserialize<cRoot, ExcludeNullsCamelCaseResolver<byte>>(bytes);
            // var oo = SpanJson.JsonSerializer.Generic.Utf16.Deserialize<cRoot>(content);
        }

        #region ===========  Json SubClasses  ===========

        private class cRoot
        {
            public int count;
            private int privateField;
            private int privateProperty { get; set; }
            public int Count { get; set; } //=> count;
            public string Next_url;
            public string request_id;
            public cItem[] Results;
            public string Status;
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

    }
}

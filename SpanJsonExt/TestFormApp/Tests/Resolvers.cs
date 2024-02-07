using System.IO;
using SpanJson;
using SpanJson.Resolvers;

namespace TestFormApp.Tests
{
    public static class Resolvers
    {
        private static readonly string LiveContent = File.ReadAllText(@"E:\Quote\WebData\Symbols\Polygon2003\PropertiesWithoutQuotes.json");
        private static readonly string SpContent = File.ReadAllText(@"E:\Quote\WebData\Symbols\Polygon2003\SymbolsPolygon_04_20240118.Original.json");

        public sealed class CustomResolver<TSymbol> : ResolverBase<TSymbol, CustomResolver<TSymbol>> where TSymbol : struct
        {
            public CustomResolver() : base(new SpanJsonOptions
            {
                NullOption = NullOptions.ExcludeNulls,
                NamingConvention = NamingConventions.CamelCase,
                EnumOption = EnumOptions.Integer,
                AllowUnquotedStrings = true
                // ByteArrayOptions = ByteArrayOptions.Base64
            })
            {
            }
        }
        public static void Start()
        {
            var oo2 = SpanJson.JsonSerializer.Generic.Utf16.Deserialize<UnquotedName.Tests.cRoot, CustomResolver<char>>(LiveContent);
            var oo21 = SpanJson.JsonSerializer.NonGeneric.Utf16.Serialize(oo2.data.data);
            var pretty21 = JsonSerializer.PrettyPrinter.Print(oo21);
            var minified21 = JsonSerializer.Minifier.Minify(oo21);
            var oo3 = SpanJson.JsonSerializer.Generic.Utf8.Deserialize<UnquotedName.Tests.cRoot, CustomResolver<byte>>(ToBytes(LiveContent));

            byte[] ToBytes(string s) => System.Text.Encoding.UTF8.GetBytes(s);
        }

        public static void RunTest()
        {
            var options = new SpanJsonOptions {AllowUnquotedStrings = true};
            var oo1 = SpanJson.JsonSerializer.Generic.Utf8.Deserialize<UnquotedName.Tests.cRoot>(ToBytes(LiveContent), options);
            var oo2 = SpanJson.JsonSerializer.Generic.Utf8.Deserialize<PolygonSymbolsTests.cRoot>(ToBytes(SpContent));

            byte[] ToBytes(string s) => System.Text.Encoding.UTF8.GetBytes(s);
        }
    }
}

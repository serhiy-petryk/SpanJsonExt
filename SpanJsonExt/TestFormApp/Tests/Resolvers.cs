using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using SpanJson.Resolvers;

namespace TestFormApp.Tests
{
    public static class Resolvers
    {
        private static readonly string LiveContent = File.ReadAllText(@"E:\Quote\WebData\Symbols\Polygon2003\PropertiesWithoutQuotes.json");

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
            var oo3 = SpanJson.JsonSerializer.Generic.Utf8.Deserialize<UnquotedName.Tests.cRoot, CustomResolver<byte>>(ToBytes(LiveContent));

            byte[] ToBytes(string s) => System.Text.Encoding.UTF8.GetBytes(s);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpanJson;

namespace TestFormApp.UnquotedName
{
    public static class Tests
    {
        private const string Json1 = "{\"type\":\"data\",\"data\":{\"action\":\"all\",\"number\":123}}";
        private const string Json2 = "{\"type\":\"data\",\"data\":{action:\"all\",\"number\":123}}";

        public static void Start()
        {
            var oo = SpanJson.JsonSerializer.Generic.Utf16.Deserialize<cRoot>(Json2);
        }


        public class cRoot
        {
            public string type;
            public cElement data;
        }

        public class cElement
        {
            public string action;
            public int number;
        }
    }
}

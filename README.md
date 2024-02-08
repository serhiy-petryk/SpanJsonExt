This is the https://github.com/Tornhoof/SpanJson project with some changes for deserialization.

### Changes list (all changes have 'Changed by SP' comments in code): ###
1. Fixed case of property names. Replaced case-insensitive ``Expression.PropertyOrField`` calls with case-sensitive ``GetMemberExpressionForPropertyOrField`` method.
2. Added ``AllowUnquotedStrings`` property in SpanJsonOptions. It allows deserializing JSON with unquoted property names. https://stockanalysis.com/actions/ is a live example of such JSON.
3. Fixed read-only field in ``SpanJson.Resolvers.ResolverBase<TSymbol, TResolver>.BuildMembers``.
4. Added ``0xA0`` symbol in ``SkipWhitespaceUtf8/16`` methods.

### Code example for AllowUnquotedStrings property ###
```
// Define custom resolver class    
public sealed class CustomResolver<TSymbol> : ResolverBase<TSymbol, CustomResolver<TSymbol>> where TSymbol : struct
{
    public CustomResolver() : base(new SpanJsonOptions
    {
        NullOption = NullOptions.ExcludeNulls,
        NamingConvention = NamingConventions.CamelCase,
        EnumOption = EnumOptions.Integer,
        AllowUnquotedStrings = true,
        ByteArrayOption =  ByteArrayOptions.Array
    })
    {
    }
}

// Deserialization example
public static void Start()
{
    var o = SpanJson.JsonSerializer.Generic.Utf8.Deserialize<UnquotedName.Tests.cRoot, CustomResolver<byte>>(byteArray);
}
```

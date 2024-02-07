This is the https://github.com/Tornhoof/SpanJson project with some changes for deserialization.

Changes list (all changes have 'Changed by SP' comments in code):
1. Fixed case of property names. Replaced case-insensitive Expression.PropertyOrField with case-sensitive GetMemberExpressionForPropertyOrField
2. Added AllowUnquotedStrings property in SpanJsonOptions. It allows deserializing JSON with unquoted property names. https://stockanalysis.com/actions/ is a live example of such json.
3. Fixed read-only field in SpanJson.Resolvers.ResolverBase<TSymbol, TResolver>.BuildMembers.
4. Added 0xA0 symbol in SkipWhitespaceUtf8/16 methods.

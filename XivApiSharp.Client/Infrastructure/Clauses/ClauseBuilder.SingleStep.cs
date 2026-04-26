using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Infrastructure.Clauses;

internal sealed partial class ClauseBuilder
{
    public IClauseBuilder WithSpecifier(string specifier)
    {
        _specifier = specifier;
        return this;
    }

    IClauseBuilder IClauseBuilder.WithLanguage(SchemaLanguage language)
    {
        _language = language;
        return this;
    }

    public IClauseBuilder WithOperator(ClauseOperators @operator)
    {
        _operator = @operator;
        return this;
    }

    public IClause<T> WithValue<T>(T value) =>
        BuildClause(_operator, value);

    public IClause<string> WithValue(string value) =>
        BuildClause(_operator, value);

    public IClause<bool> WithValue(bool value) =>
        BuildClause(_operator, value);
}
using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Infrastructure.Clauses;

internal sealed partial class ClauseBuilder<T>
{
    public IClauseBuilder<T> WithSpecifier(string specifier)
    {
        _specifier = specifier;
        return this;
    }

    IClauseBuilder<T> IClauseBuilder<T>.WithLanguage(SchemaLanguage language)
    {
        _language = language;
        return this;
    }

    public IClauseBuilder<T> WithOperator(ClauseOperators @operator)
    {
        _operator = @operator;
        return this;
    }

    public IClauseBuilder<T> WithValue(T value)
    {
        _value = value;
        return this;
    }

    public IClause<T> Build()
    {
        return BuildClause((T)_value);
    }
}
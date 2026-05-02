using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Client.Core.Clauses.Builders;

namespace XivApiSharp.Client.Infrastructure.Clauses.Builders;

internal sealed partial class ClauseBuilder<T>
{
    /// <inheritdoc />
    public IClauseBuilder<T> WithSpecifier(string specifier)
    {
        _specifier = specifier;
        return this;
    }

    /// <inheritdoc />
    IClauseBuilder<T> IClauseBuilder<T>.WithLanguage(SchemaLanguage language)
    {
        _language = language;
        return this;
    }

    /// <inheritdoc />
    public IClauseBuilder<T> WithOperator(ClauseOperators @operator)
    {
        _operator = @operator;
        return this;
    }

    /// <inheritdoc />
    public IClauseBuilder<T> WithValue(T value)
    {
        _value = value;
        return this;
    }

    /// <inheritdoc />
    public IClause<T> Build() => BuildClause((T)_value);
}
using System.Numerics;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Infrastructure.Clauses;

internal sealed partial class ClauseBuilder<T>
{
    /// <inheritdoc/>
    public IClause<string> PartiallyEqual(string value)
    {
        _operator = ClauseOperators.PartiallyEqual;
        return BuildClause(value);
    }

    /// <inheritdoc/>
    public IClause<string> Equal(string value)
    {
        _operator = ClauseOperators.Equal;
        return BuildClause(value);
    }

    /// <inheritdoc/>
    public IClause<bool> Equal(bool value)
    {
        _operator = ClauseOperators.Equal;
        return BuildClause(value);
    }

    /// <inheritdoc/>
    public IClause<TValue> Equal<TValue>(TValue value) where TValue : INumber<TValue>
    {
        _operator = ClauseOperators.Equal;
        return BuildClause(value);
    }

    /// <inheritdoc/>
    public IClause<TValue> GreaterThan<TValue>(TValue value) where TValue : INumber<TValue>
    {
        _operator = ClauseOperators.GreaterThan;
        return BuildClause(value);
    }

    /// <inheritdoc/>
    public IClause<TValue> GreaterThanOrEqual<TValue>(TValue value) where TValue : INumber<TValue>
    {
        _operator = ClauseOperators.GreaterThanOrEqual;
        return BuildClause(value);
    }

    /// <inheritdoc/>
    public IClause<TValue> LessThan<TValue>(TValue value) where TValue : INumber<TValue>
    {
        _operator = ClauseOperators.LessThan;
        return BuildClause(value);
    }

    /// <inheritdoc/>
    public IClause<TValue> LessThanOrEqual<TValue>(TValue value) where TValue : INumber<TValue>
    {
        _operator = ClauseOperators.LessThanOrEqual;
        return BuildClause(value);
    }

    /// <summary>
    /// Builds a clause by assigning the specified operator and
    /// <paramref name="value"/> to the clause.
    /// </summary>
    /// <param name="value">The value to compare against.</param>
    /// <typeparam name="TValue">The type of the clause value.</typeparam>
    /// <returns>A fully constructed clause.</returns>
    /// <seealso cref="ClauseOperators"/>
    /// <seealso cref="IClause{T}"/>
    private IClause<TValue> BuildClause<TValue>(TValue value)
    {
        return _factory.CreateClause(
            decorator: _decorator,
            specifier: _specifier,
            language: _language,
            op: _operator,
            value: value);
    }
}
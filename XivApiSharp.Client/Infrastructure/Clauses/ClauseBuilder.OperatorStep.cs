using System.Numerics;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Infrastructure.Clauses;

internal sealed partial class ClauseBuilder
{
    /// <inheritdoc/>
    public IClause PartiallyEqual(string value) =>
        BuildClause(ClauseOperators.PartiallyEqual, value);

    /// <inheritdoc/>
    public IClause Equal(string value) =>
        BuildClause(ClauseOperators.Equal, value);

    /// <inheritdoc/>
    public IClause Equal(bool value) =>
        BuildClause(ClauseOperators.Equal, value);

    /// <inheritdoc/>
    public IClause Equal<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.Equal, value);

    /// <inheritdoc/>
    public IClause GreaterThan<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.GreaterThan, value);

    /// <inheritdoc/>
    public IClause GreaterThanOrEqual<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.GreaterThanOrEqual, value);

    /// <inheritdoc/>
    public IClause LessThan<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.LessThan, value);

    /// <inheritdoc/>
    public IClause LessThanOrEqual<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.LessThanOrEqual, value);
    
    /// <summary>
    /// Builds a clause by assigning the specified operator and
    /// <paramref name="value"/> to the clause.
    /// </summary>
    /// <param name="op">The comparison operator to use for the clause.</param>
    /// <param name="value">The value to compare against.</param>
    /// <typeparam name="T">The type of the clause value.</typeparam>
    /// <returns>A fully constructed clause.</returns>
    /// <seealso cref="ClauseOperators"/>
    /// <seealso cref="IClause"/>
    private IClause BuildClause<T>(ClauseOperators op, T value) where T : notnull
    {
        IClause newClause = _factory.CreateClause(
            decorator: _decorator, 
            specifier: _specifier, 
            language: _language, 
            op: op, 
            value: value);

        return newClause;
    }
}
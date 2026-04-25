using System.Numerics;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Infrastructure.Clauses;

internal sealed partial class ClauseBuilder
{
    /// <inheritdoc/>
    public IClause<string> PartiallyEqual(string value) =>
        BuildClause(ClauseOperators.PartiallyEqual, value);

    /// <inheritdoc/>
    public IClause<string> Equal(string value) =>
        BuildClause(ClauseOperators.Equal, value);

    /// <inheritdoc/>
    public IClause<bool> Equal(bool value) =>
        BuildClause(ClauseOperators.Equal, value);

    /// <inheritdoc/>
    public IClause<T> Equal<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.Equal, value);

    /// <inheritdoc/>
    public IClause<T> GreaterThan<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.GreaterThan, value);

    /// <inheritdoc/>
    public IClause<T> GreaterThanOrEqual<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.GreaterThanOrEqual, value);

    /// <inheritdoc/>
    public IClause<T> LessThan<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.LessThan, value);

    /// <inheritdoc/>
    public IClause<T> LessThanOrEqual<T>(T value) where T : INumber<T> =>
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
    /// <seealso cref="IClause{T}"/>
    private IClause<T> BuildClause<T>(ClauseOperators op, T value) where T : notnull
    {
        
        return _factory.CreateClause(
            decorator: _decorator, 
            specifier: _specifier, 
            language: _language, 
            op: op, 
            value: value);
    }
}
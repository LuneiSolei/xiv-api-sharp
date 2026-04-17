using System.Numerics;
using System.Web;
using XivApiSharp.Client.Application.Clauses;
using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Client.Core.Extensions;

namespace XivApiSharp.Client.Infrastructure.Clauses;

internal sealed class WithConditional(string specifier, ClauseConditionals condition) : IWithConditional
{
    private readonly string _specifier = specifier;
    private readonly ClauseConditionals _condition = condition;
    private ClauseOperators _operator;

    /// <inheritdoc/>
    public IClause PartiallyEqualTo(string value) =>
        BuildClause(ClauseOperators.PartiallyEqualTo, value);

    /// <inheritdoc/>
    public IClause EqualTo(string value) =>
        BuildClause(ClauseOperators.EqualTo, value);

    /// <inheritdoc/>
    public IClause EqualTo(bool value) =>
        BuildClause(ClauseOperators.EqualTo, value);

    /// <inheritdoc/>
    public IClause EqualTo<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.EqualTo, value);

    /// <inheritdoc/>
    public IClause GreaterThan<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.GreaterThan, value);

    /// <inheritdoc/>
    public IClause GreaterThanOrEqualTo<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.GreaterThanOrEqualTo, value);

    /// <inheritdoc/>
    public IClause LessThan<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.LessThan, value);

    /// <inheritdoc/>
    public IClause LessThanOrEqualTo<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.LessThanOrEqualTo, value);
    
    /// <summary>
    /// Builds a <see cref="Clause{T}">Clause&lt;T&gt;</see> by assigning the specified operator and <paramref name="value"/> to the clause.
    /// </summary>
    /// <param name="op">The comparison operator to use for the clause.</param>
    /// <param name="value">The value to compare against.</param>
    /// <typeparam name="T">The type of the clause value.</typeparam>
    /// <returns>A fully constructed <see cref="Clause{T}">Clause&lt;T&gt;</see>.</returns>
    private Clause<T> BuildClause<T>(ClauseOperators op, T value) where T : notnull
    {
        Clause<T> clause = BuildCommon<T>(op);
        clause.Value = value;

        return clause;
    }

    /// <summary>
    /// Builds a <see cref="Clause{T}">Clause&lt;T&gt;</see> by assigning the specified operator and <paramref name="value"/> to the clause.
    /// </summary>
    /// <param name="op">The comparison operator to use for the clause.</param>
    /// <param name="value">The value to compare against.</param>
    /// <returns>A fully constructed <see cref="Clause{T}">Clause&lt;T&gt;</see>.</returns>
    private Clause<string> BuildClause(ClauseOperators op, string value)
    {
        Clause<string> clause = BuildCommon<string>(op);
        clause.Value = $"\"{HttpUtility.UrlEncode(value)}\"";

        return clause;
    }

    /// <summary>
    /// Assigns the provided operator and the builder's stored specifier to the clause.
    /// </summary>
    /// <param name="op">The comparison operator to use for the clause.</param>
    /// <typeparam name="T">The type of the clause value.</typeparam>
    /// <returns>A partially constructed <see cref="Clause{T}">Clause&lt;T&gt;</see>.</returns>
    private Clause<T> BuildCommon<T>(ClauseOperators op) where T : notnull
    {
        _operator = op;
        Clause<T> baseClause = new();
        
        AddClauseSpecifier(baseClause);
        AddClauseOperator(baseClause);

        return baseClause;
    }
    
    /// <summary>
    /// Adds the builder's stored specifier to the <see cref="Clause{T}">Clause&lt;T&gt;</see>.
    /// </summary>
    /// <param name="clause">The <see cref="Clause{T}">Clause&lt;T&gt;</see> to add the specifier to.</param>
    /// <typeparam name="T">The type of the clause value.</typeparam>
    private void AddClauseSpecifier<T>(Clause<T> clause) where T : notnull
    {
        string specifier = _condition == ClauseConditionals.MustBe
            ? string.Empty
            : "-";

        specifier += $"{_specifier}";
        clause.Specifier = specifier;
    }

    /// <summary>
    /// Adds the builder's stored operator to the <see cref="Clause{T}">Clause&lt;T&gt;</see>.
    /// </summary>
    /// <param name="clause">The <see cref="Clause{T}">Clause&lt;T&gt;</see> to add the operator to.</param>
    /// <typeparam name="T">The type of the clause value.</typeparam>
    private void AddClauseOperator<T>(Clause<T> clause) where T : notnull =>
        clause.Operator = _operator.Stringify();
}
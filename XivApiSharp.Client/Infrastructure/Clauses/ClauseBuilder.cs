using System.Numerics;
using System.Web;
using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Client.Core.Extensions;
using XivApiSharp.Client.Infrastructure.Clauses.Steps;

namespace XivApiSharp.Client.Infrastructure.Clauses;

/// <summary>
/// Builds a singular clause for use in a <see cref="QueryString"/>.
/// </summary>
/// <seealso cref="Clause{T}">Clause&lt;T&gt;</seealso>
public class ClauseBuilder : IInitialClauseBuilderStep, IConditionStep,
    IOperatorStep 
{
    private string _name = string.Empty;
    private ClauseConditionals _conditionals;
    private ClauseOperators _operator;
    
    /// <summary>
    /// Internal empty constructor to prevent external instantiation.
    /// </summary>
    internal ClauseBuilder() {}

    /// <inheritdoc/>
    public IConditionStep WhereSpecifier(string name)
    {
        _name = name;
        
        return this;
    }
    
    /// <inheritdoc/>
    public IOperatorStep MustBe
    {
        get
        {
            _conditionals = ClauseConditionals.Is;
            
            return this;
        }
    }

    /// <inheritdoc/>
    public IOperatorStep MustNotBe
    {
        get
        {
            _conditionals = ClauseConditionals.IsNot;

            return this;
        }
    }
    
    /// <inheritdoc/>
    public Clause<string> PartiallyEqualTo(string value) =>
        BuildClause(ClauseOperators.PartiallyEqualTo, value);

    /// <inheritdoc/>
    public Clause<string> EqualTo(string value) =>
        BuildClause(ClauseOperators.EqualTo, value);

    /// <inheritdoc/>
    public Clause<bool> EqualTo(bool value) =>
        BuildClause(ClauseOperators.EqualTo, value);

    /// <inheritdoc/>
    public Clause<T> EqualTo<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.EqualTo, value);

    /// <inheritdoc/>
    public Clause<T> GreaterThan<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.GreaterThan, value);

    /// <inheritdoc/>
    public Clause<T> GreaterThanOrEqualTo<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.GreaterThanOrEqualTo, value);

    /// <inheritdoc/>
    public Clause<T> LessThan<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.LessThan, value);

    /// <inheritdoc/>
    public Clause<T> LessThanOrEqualTo<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.LessThanOrEqualTo, value);

    // Clause Building
    private Clause<T> BuildClause<T>(ClauseOperators op, T value) where T : notnull
    {
        Clause<T> clause = BuildCommon<T>(op);
        clause.Value = value;

        return clause;
    }

    private Clause<string> BuildClause(ClauseOperators op, string value)
    {
        Clause<string> clause = BuildCommon<string>(op);
        clause.Value = $"\"{HttpUtility.UrlEncode(value)}\"";

        return clause;
    }

    private Clause<T> BuildCommon<T>(ClauseOperators op) where T : notnull
    {
        _operator = op;
        Clause<T> baseClause = new();
        
        AddClauseSpecifier(baseClause);
        AddClauseOperator(baseClause);

        return baseClause;
    }
    
    private void AddClauseSpecifier<T>(Clause<T> clause) where T : notnull
    {
        string specifier = _conditionals == ClauseConditionals.Is
            ? string.Empty
            : "-";

        specifier += $"{_name}";
        clause.Specifier = specifier;
    }

    private void AddClauseOperator<T>(Clause<T> clause) where T : notnull =>
        clause.Operator = _operator.Stringify();
}
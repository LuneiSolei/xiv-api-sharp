using System.Numerics;
using System.Web;
using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Client.Core.Extensions;
using XivApiSharp.Client.Infrastructure.Requests.Clauses.Steps;

namespace XivApiSharp.Client.Infrastructure.Requests.Clauses;

/// <summary>
/// Builds the specific query parameter used by XIV API in the url string.
/// This does <b>NOT</b> represent the actual query of the url. This query
/// string contains an ordered list of clauses and parameters, in which both
/// have operators, joined by an ampersand (&amp;).
/// </summary>
/// <remarks>
///     <para>
///         <b>Parameter (param)</b> - Single key-value pair.
///     </para>
///     <para>
///         <b>Clause</b> - Logical grouping/condition built from one or more
///         parameters.
///     </para>
///     <para>
///         <b>Operator (op)</b> - Symbol representing a specific operation
///         (=, ~, +, -, etc.)
///     </para>
/// </remarks>
public class ClauseBuilder : IInitialClauseBuilderStep, IConditionStep,
    IOperatorStep 
{
    private string _name = string.Empty;
    private ClauseConditionals _conditionals;
    private ClauseOperators _operator;
    
    internal ClauseBuilder() {}

    // WhereField Step
    public IConditionStep WhereSpecifier(string name)
    {
        _name = name;
        
        return this;
    }

    public IOperatorStep Is
    {
        get
        {
            _conditionals = ClauseConditionals.Is;
            
            return this;
        }
    }

    public IOperatorStep IsNot
    {
        get
        {
            _conditionals = ClauseConditionals.IsNot;

            return this;
        }
    }

    // Operator Step
    public Clause<string> PartiallyEqualTo(string value) =>
        BuildClause(ClauseOperators.PartiallyEqualTo, value);

    public Clause<string> EqualTo(string value) =>
        BuildClause(ClauseOperators.EqualTo, value);

    public Clause<bool> EqualTo(bool value) =>
        BuildClause(ClauseOperators.EqualTo, value);

    public Clause<T> EqualTo<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.EqualTo, value);

    public Clause<T> GreaterThan<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.GreaterThan, value);

    public Clause<T> GreaterThanOrEqualTo<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.GreaterThanOrEqualTo, value);
    
    public Clause<T> LessThan<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.LessThan, value);

    public Clause<T> LessThanOrEqualTo<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.LessThanOrEqualTo, value);

    // Clause Building
    private Clause<T> BuildClause<T>(ClauseOperators op, T value)
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

    private Clause<T> BuildCommon<T>(ClauseOperators op)
    {
        _operator = op;
        Clause<T> baseClause = new();
        
        AddClauseSpecifier(baseClause);
        AddClauseOperator(baseClause);

        return baseClause;
    }
    
    private void AddClauseSpecifier<T>(Clause<T> clause)
    {
        string specifier = _conditionals == ClauseConditionals.Is
            ? string.Empty
            : "-";

        specifier += $"{_name}";
        clause.Specifier = specifier;
    }

    private void AddClauseOperator<T>(Clause<T> clause) =>
        clause.Operator = _operator.Stringify();
}
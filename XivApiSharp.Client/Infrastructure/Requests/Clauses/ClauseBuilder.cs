using System.Numerics;
using System.Web;
using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Enums;
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
    private string _value = string.Empty;
    
    internal ClauseBuilder() {}

    // WhereField Step
    public IConditionStep WhereSpecifier(string name)
    {
        _name = name;
        
        return this;
    }
    
    // Condition Step
    public IOperatorStep Is()
    {
        _conditionals = ClauseConditionals.Is; 
        
        return this;
    }

    public IOperatorStep IsNot()
    {
        _conditionals = ClauseConditionals.IsNot; 
        
        return this;
    }

    // Operator Step
    public Clause PartiallyEqualTo(string value) =>
        BuildClause(ClauseOperators.PartiallyEqualTo, value);

    public Clause PartiallyEqualTo(bool value) =>
        BuildClause(ClauseOperators.PartiallyEqualTo, value.ToString());

    public Clause PartiallyEqualTo<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.PartiallyEqualTo, 
            value.ToString() ?? string.Empty);

    public Clause EqualTo(string value) =>
        BuildClause(ClauseOperators.EqualTo, value);

    public Clause EqualTo(bool value) =>
        BuildClause(ClauseOperators.LessThanOrEqualTo, value.ToString());

    public Clause EqualTo<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.EqualTo, 
            value.ToString() ?? string.Empty);

    public Clause GreaterThan(string value) =>
        BuildClause(ClauseOperators.GreaterThan, value);

    public Clause GreaterThan<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.GreaterThan, 
            value.ToString() ?? string.Empty);

    public Clause GreaterThanOrEqualTo(string value) =>
        BuildClause(ClauseOperators.GreaterThanOrEqualTo, value);

    public Clause GreaterThanOrEqualTo<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.GreaterThanOrEqualTo, 
            value.ToString() ?? string.Empty);

    public Clause LessThan(string value) =>
        BuildClause(ClauseOperators.LessThan, value);
    
    public Clause LessThan<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.LessThan, 
            value.ToString() ?? string.Empty);

    public Clause LessThanOrEqualTo(string value) =>
        BuildClause(ClauseOperators.LessThanOrEqualTo, value);

    public Clause LessThanOrEqualTo<T>(T value) where T : INumber<T> =>
        BuildClause(ClauseOperators.LessThanOrEqualTo, 
            value.ToString() ?? string.Empty);

    // Clause Building
    private Clause BuildClause(ClauseOperators op, string value)
    {
        _operator = op;
        _value = value;
        Clause clause = new();
        
        AddClauseSpecifier(clause);
        AddClauseOperator(clause);
        AddClauseValue(clause);

        return clause;
    }
    
    private void AddClauseSpecifier(Clause clause)
    {
        string specifier = _conditionals == ClauseConditionals.Is
            ? string.Empty
            : "-";

        specifier += $"{_name}";
        clause.Specifier = specifier;
    }

    private void AddClauseOperator(Clause clause) => 
        clause.Operator = Utilities.ToOperatorSign(_operator);

    private void AddClauseValue(Clause clause) => 
        clause.Value = $"\"{HttpUtility.UrlEncode(_value)}\"";
}
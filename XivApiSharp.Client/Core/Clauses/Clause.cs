using System.Numerics;
using System.Web;
using XivApiSharp.Client.Core.Extensions;

namespace XivApiSharp.Client.Core.Clauses;

/// <inheritdoc />
internal sealed class Clause<T> : IClause where T : notnull
{
    /// <summary>
    /// Main constructor for clause.
    /// </summary>
    /// <param name="specifier">
    /// The specifier to be compared against.
    /// </param>
    /// <param name="op">
    /// The comparison operator to perform.
    /// </param>
    /// <param name="value">
    /// The value to be compared.
    /// </param>
    /// <param name="condition">
    /// The matching condition for the clause.
    /// </param>
    /// <seealso cref="IClause"/>
    public Clause(string specifier, ClauseOperators op, T value, ClauseConditionals condition)
    {
        Specifier = specifier;
        Operator = op;
        Value = value;
        Condition = condition;
    }
    
    /// <inheritdoc />
    public string Specifier { get; set; }

    /// <inheritdoc />
    public ClauseOperators Operator { get; set; }

    /// <summary>
    /// The value of clause to be compared.
    /// </summary>
    public T Value { get; set; }
    
    /// <inheritdoc/>
    public ClauseConditionals Condition { get; set; }

    /// <inheritdoc cref="IClause.ToString" />
    public override string ToString()
    {
        // Set specifier with condition attached
        string specifierWithCondition = Condition == ClauseConditionals.MustBe
            ? string.Empty
            : "-";
        specifierWithCondition += $"{Specifier}";

        string newValue = Value switch
        {
            bool b => b.ToString().ToLowerInvariant(), // Convert boolean values to lowercase because .NET capitalizes them by default.
            string s => $"\"{HttpUtility.UrlEncode(s)}\"", // Encode strings.
            _ => Value.ToString() ?? string.Empty // Anything else gets to be a string without encoding.
        };

        return $"{specifierWithCondition}{Operator.Stringify()}{newValue}";
    }
}
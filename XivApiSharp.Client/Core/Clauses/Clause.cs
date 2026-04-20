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
    /// <param name="decorator">
    /// The matching decorator for the clause.
    /// </param>
    /// <seealso cref="IClause"/>
    public Clause(string specifier, ClauseOperators op, T value, ClauseDecorators decorator)
    {
        Specifier = specifier;
        ClauseOperator = op;
        Value = value;
        Decorator = decorator;
    }
    
    /// <inheritdoc />
    public string Specifier { get; set; }

    /// <inheritdoc />
    public ClauseOperators ClauseOperator { get; set; }

    /// <summary>
    /// The value of clause to be compared.
    /// </summary>
    public T Value { get; set; }
    
    /// <inheritdoc/>
    public ClauseDecorators Decorator { get; set; }

    /// <inheritdoc cref="IClause.ToString" />
    public override string ToString()
    {
        // Set specifier with decorator attached
        string specifierWithDecorator = Decorator == ClauseDecorators.Must
            ? string.Empty
            : "-";
        specifierWithDecorator += $"{Specifier}";

        string newValue = Value switch
        {
            bool b => b.ToString().ToLowerInvariant(), // Convert boolean values to lowercase because .NET capitalizes them by default.
            string s => $"\"{HttpUtility.UrlEncode(s)}\"", // Encode strings.
            _ => Value.ToString() ?? string.Empty // Anything else gets to be a string without encoding.
        };

        return $"{specifierWithDecorator}{ClauseOperator.Stringify()}{newValue}";
    }

    /// <inheritdoc cref="IClause.ToStringUnencoded" />
    public string ToStringUnencoded() =>
        throw new NotImplementedException();
}
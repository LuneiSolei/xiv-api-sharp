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

    /// <inheritdoc cref="IClause.ToString"/>
    public override string ToString()
    {
        string newValue = Value switch
        {
            // Convert boolean values to lowercase because .NET capitalizes them by default.
            bool b => b.ToString().ToLowerInvariant(), 
            
            // Encode strings.
            string s => $"\"{HttpUtility.UrlEncode(s)}\"", 
            
            // Anything else gets to be a string without encoding.
            _ => Value.ToString() ?? string.Empty 
        };

        return $"{Decorator.GetStringValue()}{Specifier}{ClauseOperator
            .GetStringValue()}{newValue}";
    }

    /// <inheritdoc cref="IClause.ToStringUnencoded"/>
    public string ToStringUnencoded() =>
        throw new NotImplementedException();
}
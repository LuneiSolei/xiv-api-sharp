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
    /// <param name="lang">
    /// (Optional) The language to use for this Clause.
    /// </param>
    /// <seealso cref="IClause"/>
    public Clause(string specifier, ClauseOperators op, T value, 
        ClauseDecorators decorator, SchemaLanguage lang = SchemaLanguage.None)
    {
        Specifier = specifier;
        ClauseOperator = op;
        Value = value;
        Decorator = decorator;
        Language = lang;
    }
    
    /// <inheritdoc/>
    public SchemaLanguage Language { get; set; }

    /// <inheritdoc/>
    public string EncodedValue { get; set; } = "";

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

    /// <inheritdoc cref="IClauseElement.ToUriEncodedString"/>
    public string ToUriEncodedString()
    {
        string encodedDecorator = Decorator.ToUriEncodedString();
        string encodedOperator = ClauseOperator.ToUriEncodedString();
        string encodedSpecifier = HttpUtility.UrlEncode(Specifier);
        string encodedLanguage = string.Empty;
        
        // Use language, if any was provided
        if (Language != SchemaLanguage.None)
        {
            encodedLanguage = HttpUtility.UrlEncode(
                $"@{Language.ToString().ToLower()}");
        }
        
        // Determine new encoded clause value
        string encodedValue = Value switch
        {
            // Convert boolean values to lowercase because .NET capitalizes them by default.
            bool b => b.ToString().ToLowerInvariant(), 
            
            // Encode strings.
            string s => $"\"{HttpUtility.UrlEncode(s)}\"", 
            
            // Anything else gets to be a string without encoding.
            _ => Value.ToString() ?? string.Empty 
        };

        return $"{encodedDecorator}{encodedSpecifier}{encodedLanguage}"
               + $"{encodedOperator}{encodedValue}";
    }

    /// <inheritdoc cref="IClause.ToUnencodedString"/>
    public string ToUnencodedString() =>
        throw new NotImplementedException();
}
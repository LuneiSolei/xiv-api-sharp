namespace XivApiSharp.Client.Core.Clauses;

/// <summary>
/// Represents a type that is used as a clause as defined by the XIV API
/// QueryString model. A clause combines a specifier, operator, a value, and
/// an optional decorator.
/// </summary>
public interface IClause
{
    /// <summary>
    /// Name of the field to compare the value against.
    /// </summary>
    internal string Specifier { get; set; }
    
    /// <summary>
    /// The comparison operator to use.
    /// </summary>
    internal ClauseOperators Operator { get; set; }

    /// <summary>
    /// The boolean operator state of the clause.
    /// </summary>
    internal ClauseConditionals Condition { get; set; }
    
    /// <summary>
    /// Converts this instance into its URI encoded string representation.
    /// </summary>
    /// <remarks>
    /// All strings are automatically URI encoded by default. To retrieve an
    /// unencoded string, use <see cref="ToStringUnencoded"/> instead.
    /// </remarks>
    /// <returns>
    /// The URI encoded string representation of this instance.
    /// </returns>
    /// <seealso cref="ToStringUnencoded"/>
    string ToString();

    /// <summary>
    /// Converts this instance into its unencoded string representation.
    /// </summary>
    /// <remarks>
    /// To retrieve a URI encoded version, use <see cref="ToString"/> instead.
    /// </remarks>
    /// <returns>
    /// The unencoded string representation of this instance. 
    /// </returns>
    /// <seealso cref="ToString"/>
    string ToStringUnencoded();
}
namespace XivApiSharp.Client.Core.Clauses;

/// <summary>
/// Defines a clause (filter/condition) as defined by the XIV API QueryString, combining a field specifier,
/// comparison operator, a value, and (optionally) a decorator.
/// </summary>
/// <remarks>
/// Implementations of <see cref="IClause"/> are expected to provide a strongly-typed <c>Value</c>
/// property, exposing it as <see cref="object"/> for use in generic contexts.
/// </remarks>
public interface IClause
{ 
    /// <summary>
    /// Name of the field to compare the value against.
    /// </summary>
    string? Specifier { get; set; }
    
    /// <summary>
    /// The comparison operator to use.
    /// </summary>
    string? Operator { get; set; }
    
    /// <summary>
    /// Converts the specifier, operator, and value of this instance into its
    /// string representation.
    /// </summary>
    /// <returns>The string representation of this instance.</returns>
    string ToString();
}
namespace XivApiSharp.Client.Core.Clauses;

/// <summary>
/// Represents a type that is used as a clause as defined by the XIV API
/// QueryString model. A clause combines a specifier, operator, a value, and
/// an optional decorator.
/// </summary>
public interface IClause : IClauseElement
{
    /// <summary>
    /// Name of the field to compare the value against.
    /// </summary>
    internal string Specifier { get; set; }
    
    /// <summary>
    /// The comparison operator to use.
    /// </summary>
    internal ClauseOperators ClauseOperator { get; set; }

    /// <summary>
    /// The boolean operator state of the clause.
    /// </summary>
    internal ClauseDecorators Decorator { get; set; }
    
    /// <summary>
    /// The language to use for the clause.
    /// </summary>
    internal SchemaLanguage Language { get; set; }
}
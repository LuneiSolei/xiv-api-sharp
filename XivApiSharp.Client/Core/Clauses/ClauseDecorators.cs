using XivApiSharp.Client.Infrastructure.Clauses;

namespace XivApiSharp.Client.Core.Clauses;

/// <summary>
/// Represents the boolean state of a clause.
/// </summary>
/// <seealso cref="Clause{T}">Clause&lt;T&gt;</seealso>
public enum ClauseDecorators
{
    /// <summary>
    /// Helper enum which specifies that no decorator is used.
    /// </summary>
    /// <remarks>
    /// This is the default decorator.
    /// </remarks>
    [StringValue("")]
    None,
    
    /// <summary>
    /// Helper enum which specifies that the clause is used to include results.
    /// </summary>
    [StringValue("+")]
    Must,
    
    /// <summary>
    /// Helper enum which specifies that the clause is used to exclude results.
    /// </summary>
    [StringValue("-")]
    MustNot
}
namespace XivApiSharp.Client.Core.Clauses;

/// <summary>
/// Represents the boolean state of a clause.
/// </summary>
/// <seealso cref="Clause{T}">Clause&lt;T&gt;</seealso>
internal enum ClauseDecorators
{
    /// <summary>
    /// Helper enum which specifies that the clause is used to include results.
    /// </summary>
    /// <remarks>
    /// This is the default decorator.
    /// </remarks>
    Must,
    
    /// <summary>
    /// Helper enum which specifies that the clause is used to exclude results.
    /// </summary>
    MustNot
}
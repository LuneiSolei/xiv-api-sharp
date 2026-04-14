namespace XivApiSharp.Client.Core.Clauses.Enums;

/// <summary>
/// Represents the boolean state of a clause.
/// </summary>
/// <seealso cref="Clause{T}">Clause&lt;T&gt;</seealso>
public enum ClauseConditionals
{
    /// <summary>
    /// Helper enum which specifies that the clause is used to exclude results.
    /// </summary>
    IsNot,
    
    /// <summary>
    /// Helper enum which specifies that the clause is used to include results.
    /// </summary>
    /// <remarks>This is the default conditional.</remarks>
    Is
}
namespace XivApiSharp.Client.Core.Clauses;

/// <summary>
/// Represents the operation that the clause will use to compare its value to.
/// </summary>
/// <seealso cref="Clause{T}">Clause&lt;T&gt;</seealso>
internal enum ClauseOperators
{
    /// <summary>
    /// Uses the <c>"~="</c> operator.
    /// </summary>
    PartiallyEqualTo,
    
    /// <summary>
    /// Uses the <c>=</c> operator.
    /// </summary>
    EqualTo,
    
    /// <summary>
    /// Uses the <c>&lt;</c> operator.
    /// </summary>
    LessThan,
    
    /// <summary>
    /// Uses the <c>&lt;=</c> operator.
    /// </summary>
    LessThanOrEqualTo,
    
    /// <summary>
    /// Uses the <c>&gt;</c> operator.
    /// </summary>
    GreaterThan,
    
    /// <summary>
    /// Uses the <c>&gt;=</c> operator.
    /// </summary>
    GreaterThanOrEqualTo
}
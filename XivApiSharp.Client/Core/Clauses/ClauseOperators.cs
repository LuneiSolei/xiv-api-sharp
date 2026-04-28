using XivApiSharp.Client.Infrastructure.Clauses;

namespace XivApiSharp.Client.Core.Clauses;

/// <summary>
/// Represents the operation that the clause will use to compare its value to.
/// </summary>
/// <seealso cref="Clause{T}">Clause&lt;T&gt;</seealso>
public enum ClauseOperators
{
    /// <summary>
    /// Uses the <c>"~="</c> operator.
    /// </summary>
    [StringValue("~")]
    PartiallyEqual,

    /// <summary>
    /// Uses the <c>=</c> operator.
    /// </summary>
    [StringValue("=")]
    Equal,

    /// <summary>
    /// Uses the <c>&lt;</c> operator.
    /// </summary>
    [StringValue("<")]
    LessThan,

    /// <summary>
    /// Uses the <c>&lt;=</c> operator.
    /// </summary>
    [StringValue("<=")]
    LessThanOrEqual,

    /// <summary>
    /// Uses the <c>&gt;</c> operator.
    /// </summary>
    [StringValue(">")]
    GreaterThan,

    /// <summary>
    /// Uses the <c>&gt;=</c> operator.
    /// </summary>
    [StringValue(">=")]
    GreaterThanOrEqual
}
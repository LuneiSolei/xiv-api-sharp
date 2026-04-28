using XivApiSharp.Client.Core.ClauseGroups;
using XivApiSharp.Client.Infrastructure.Clauses;

namespace XivApiSharp.Client.Core.Clauses;

/// <summary>
/// Represents the requirement status of a clause.
/// </summary>
/// <seealso cref="Clause{T}">Clause&lt;T&gt;</seealso>
public enum ClauseDecorators
{
    /// <summary>
    /// Indicates no decorator.
    /// </summary>
    /// <remarks>
    /// This is the default decorator.
    /// </remarks>
    [StringValue("")]
    None,

    /// <summary>
    /// The "Must" (+) decorator. This decorator, when used on individual clauses, requires that any returned results
    /// *must* match the clause's condition. When used on a clause group, it requires that *at least one* of the grouped
    /// clauses must be matched on any given returned result.
    /// </summary>
    /// <seealso cref="IClause{T}"/>
    /// <seealso cref="IClauseGroup"/>
    [StringValue("+")]
    Must,

    /// <summary>
    /// The "Must Not" (-) decorator. This decorator, when used on individual clauses, requires that any returned
    /// results *must not* match the clause's condition. When used on a clause group, it requires that returned results
    /// *must not match any* of the grouped clauses.
    /// </summary>
    /// <seealso cref="IClause{T}"/>
    /// <seealso cref="IClauseGroup"/>
    [StringValue("-")]
    MustNot
}
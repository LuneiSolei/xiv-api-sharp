using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Application.Clauses;

/// <summary>
/// Defines properties for a ClauseBuilder that determine the boolean state of
/// the clause.
/// </summary>
/// <seealso cref="IClause"/>
public interface IWhereSpecifier
{
    /// <summary>
    /// Indicates the clause <b>MUST</b> be matched for every result returned.
    /// </summary>
    IWithConditional MustBe { get; }
    
    /// <summary>
    /// Indicates the clause <b>MUST NOT</b> be matched for any result returned.
    /// </summary>
    IWithConditional MustNotBe { get; }
}
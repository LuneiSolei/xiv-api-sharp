namespace XivApiSharp.Client.Core.Clauses;

/// <summary>
/// Defines properties for a ClauseBuilder that determine the boolean state of
/// the clause.
/// </summary>
/// <seealso cref="IClause"/>
public interface IWhereSpecifier : IWithDecorator
{
    /// <summary>
    /// Indicates the clause <b>MUST</b> be matched for every result returned.
    /// </summary>
    IWithDecorator Must { get; }
    
    /// <summary>
    /// Indicates the clause <b>MUST NOT</b> be matched for any result returned.
    /// </summary>
    IWithDecorator MustNot { get; }
}
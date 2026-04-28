namespace XivApiSharp.Client.Core.Clauses;

/// <summary>
/// Defines properties for a ClauseBuilder that determine the boolean state of
/// the clause.
/// </summary>
/// <seealso cref="IClause{T}"/>
public interface IOptionalDecoratorStep : IOperatorStep
{
    /// <summary>
    /// Indicates the clause <b>MUST</b> be matched for every result returned.
    /// </summary>
    IOperatorStep Must { get; }

    /// <summary>
    /// Indicates the clause <b>MUST NOT</b> be matched for any result returned.
    /// </summary>
    IOperatorStep MustNot { get; }
}
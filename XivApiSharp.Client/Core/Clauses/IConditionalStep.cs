using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Infrastructure.Clauses.Steps;

/// <summary>
/// Defines properties for a ClauseBuilder that determine the boolean state of the <see cref="Clause{T}">Clause&lt;T&gt;</see>.
/// </summary>
public interface IConditionalStep
{
    /// <summary>
    /// Indicates the clause <b>MUST</b> be matched for every result returned.
    /// </summary>
    IOperatorStep MustBe { get; }
    
    /// <summary>
    /// Indicates the clause <b>MUST NOT</b> be matched for any result returned.
    /// </summary>
    IOperatorStep MustNotBe { get; }
}
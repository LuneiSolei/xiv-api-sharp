using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Infrastructure.Clauses.Steps;

/// <summary>
/// Defines methods for the initial step of a ClauseBuilder.
/// </summary>
public interface IInitialClauseBuilderStep
{
    /// <summary>
    /// Sets the specifier portion of the clause.
    /// </summary>
    /// <param name="name">The name of the specifier to use.</param>
    /// <seealso cref="Clause{T}">Clause&lt;T&gt;</seealso>
    IConditionalStep WhereSpecifier(string name);
}
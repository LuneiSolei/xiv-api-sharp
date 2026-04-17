using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Application.Clauses;

/// <summary>
/// Defines methods for the initial step of a ClauseBuilder.
/// </summary>
public interface IClauseBuilder
{
    /// <summary>
    /// Sets the specifier portion of the clause.
    /// </summary>
    /// <param name="name">The name of the specifier to use.</param>
    /// <seealso cref="IClause"/>
    IWhereSpecifier WhereSpecifier(string name);
}
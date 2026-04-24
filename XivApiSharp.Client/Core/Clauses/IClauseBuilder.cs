namespace XivApiSharp.Client.Core.Clauses;

/// <summary>
/// Defines methods for the initial step of a ClauseBuilder.
/// </summary>
public interface IClauseBuilder 
    : IOptionalLanguageStep, IOptionalDecoratorStep, IOperatorStep
{
    /// <summary>
    /// Sets the specifier portion of the clause.
    /// </summary>
    /// <param name="specifier">
    /// The specifier of the specifier to use.
    /// </param>
    /// <returns>
    /// The optional language step of the clause builder.
    /// </returns>
    /// <seealso cref="IClause"/>
    IOptionalLanguageStep WhereSpecifier(string specifier);
}
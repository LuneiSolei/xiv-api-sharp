namespace XivApiSharp.Client.Core.Clauses;

/// <summary>
/// Defines methods for the initial step of a ClauseBuilder.
/// </summary>
public interface IClauseBuilder
{
    /// <summary>
    /// Sets the specifier portion of the clause.
    /// </summary>
    /// <param name="specifier">
    /// The specifier of the specifier to use.
    /// </param>
    /// <remarks>
    /// This begins the multistep method chain.
    /// </remarks>
    /// <returns>
    /// The optional language step of the clause builder.
    /// </returns>
    /// <seealso cref="IClause"/>
    IOptionalLanguageStep WhereSpecifier(string specifier);

    // The below methods are for the "single step" chain.
    IClauseBuilder WithDecorator(ClauseDecorators decorator);

    IClauseBuilder WithSpecifier(string specifier);

    IClauseBuilder WithLanguage(SchemaLanguage language);

    IClauseBuilder WithOperator(ClauseOperators @operator);

    IClause<T> WithValue<T>(T value);
}
namespace XivApiSharp.Client.Core.Clauses;

/// <summary>
/// Defines methods for the initial step of a ClauseBuilder.
/// </summary>
public interface IClauseBuilder<T> where T : notnull
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
    /// <seealso cref="IClause{T}"/>
    IOptionalLanguageStep WhereSpecifier(string specifier);

    // The below methods are for the "single step" chain.
    /// <summary>
    /// Sets the <see cref="ClauseDecorators">decorator</see> for the clause to use.
    /// </summary>
    /// <param name="decorator">
    /// The member of <see cref="ClauseDecorators"/> to use.
    /// </param>
    /// <returns>
    /// This clause builder instance for method chaining.
    /// </returns>
    IClauseBuilder<T> WithDecorator(ClauseDecorators decorator);

    /// <summary>
    /// Sets the specifier for the clause to use.
    /// </summary>
    /// <param name="specifier">
    /// The string field specifier for the clause to compare its value to.
    /// </param>
    /// <returns>
    /// This clause builder instance for method chaining.
    /// </returns>
    IClauseBuilder<T> WithSpecifier(string specifier);

    /// <summary>
    /// Sets the language for the clause to use. Overrides the <see cref="QueryString"/> language parameter.
    /// </summary>
    /// <param name="language">
    /// The language for the clause to use.
    /// </param>
    /// <returns>
    /// This clause builder instance for method chaining.
    /// </returns>
    IClauseBuilder<T> WithLanguage(SchemaLanguage language);

    /// <summary>
    /// Sets the <see cref="ClauseOperators">operator</see> for the clause to use.
    /// </summary>
    /// <param name="operator">
    /// The member of <see cref="ClauseOperators"/> to use.
    /// </param>
    /// <returns>
    /// This clause builder instance for method chaining.
    /// </returns>
    IClauseBuilder<T> WithOperator(ClauseOperators @operator);

    /// <summary>
    /// Sets the value for the clause to compare its specifier against.
    /// </summary>
    /// <param name="value">
    /// The value for the clause to use.
    /// </param>
    /// <typeparam name="T">
    /// The type of the value. Can be either a <c>string</c>, <c>boolean</c>, or <c>INumber</c>.
    /// </typeparam>
    /// <returns>
    /// The built clause.
    /// </returns>
    /// <seealso cref="IClause{T}"/>
    IClauseBuilder<T> WithValue(T value);

    /// <summary>
    /// Builds the clause.
    /// </summary>
    /// <returns>
    /// A built instance of <see cref="IClause{T}"/>.
    /// </returns>
    IClause<T> Build();
}
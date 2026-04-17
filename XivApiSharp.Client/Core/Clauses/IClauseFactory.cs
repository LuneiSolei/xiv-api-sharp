namespace XivApiSharp.Client.Core.Clauses;

/// <summary>
/// Represents a type that is used for creating clause instances used with an
/// instance of QueryString.
/// </summary>
/// <seealso cref="IClause"/>
/// <seealso cref="QueryString"/>
internal interface IClauseFactory
{
    /// <summary>
    /// Creates a new instance of Clause&lt;T&gt;.
    /// </summary>
    /// <param name="specifier">
    /// The name of the specifier being compared
    /// against.
    /// </param>
    /// <param name="op">
    /// The comparison operator to compare the specifier and value with.
    /// </param>
    /// <param name="value">
    /// The value being compared.
    /// </param>
    /// <param name="condition">
    /// The matching condition for the clause.
    /// </param>
    /// <typeparam name="T">
    /// The type of the clause value.
    /// </typeparam>
    /// <returns>
    /// An instance of IClause
    /// </returns>
    /// <seealso cref="IClause"/>
    IClause CreateClause<T>(string specifier, ClauseOperators op, T value,
        ClauseConditionals condition) where T : notnull;
}
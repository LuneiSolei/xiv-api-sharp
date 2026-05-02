using XivApiSharp.Client.Core.Clauses.Builders;
using XivApiSharp.Client.Infrastructure;

namespace XivApiSharp.Client.Core.Clauses;

/// <summary>
/// Represents a type that is used for creating clause instances used with an
/// instance of QueryString.
/// </summary>
/// <seealso cref="IClause{T}"/>
/// <seealso cref="QueryString"/>
internal interface IClauseFactory
{
    /// <summary>
    /// Creates a new instance of Clause&lt;T&gt;.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the clause value.
    /// </typeparam>
    /// <returns>
    /// An instance of IClause
    /// </returns>
    /// <seealso cref="IClause{T}"/>
    IClause<T> CreateClause<T>(
        ClauseDecorators decorator,
        string specifier,
        SchemaLanguage language,
        ClauseOperators op,
        T value);

    IClauseBuilder<T> CreateClauseBuilder<T>();
}
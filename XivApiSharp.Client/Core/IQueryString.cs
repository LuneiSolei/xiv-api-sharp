using JetBrains.Annotations;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Core;

/// <summary>
///     Represents a type that is used to form strings for the "query" parameter to XIV API's various endpoints.
/// </summary>
public interface IQueryString
{
    /// <summary>
    ///     The individual <see cref="IClause{T}">clauses</see> to be included in the query string.
    /// </summary>
    /// <seealso cref="IXivApiService.NewClause" />
    ICollection<IBaseClause> Clauses { get; set; }

    /// <summary>
    ///     Adds an individual <see cref="IClause{T}">clause</see> to the query string.
    /// </summary>
    /// <param name="clause">The clause to add.</param>
    [UsedImplicitly]
    void AddClause(IBaseClause clause)
    {
        Clauses.Add(clause);
    }

    /// <summary>
    ///     Adds a collection of <see cref="IClause{T}">clauses</see> to the query string.
    /// </summary>
    /// <param name="clauses">
    ///     The collection of clauses to add.
    /// </param>
    [UsedImplicitly]
    void AddClauses(ICollection<IBaseClause> clauses)
    {
        foreach (IBaseClause baseClause in clauses) Clauses.Add(baseClause);
    }

    /// <summary>
    ///     Converts this instance into its unencoded string representation.
    /// </summary>
    /// <returns>
    ///     The unencoded string representation of this instance.
    /// </returns>
    string ToUnencodedString();

    /// <summary>
    ///     Converts this instance into is URI encoded string representation.
    /// </summary>
    /// <returns>
    ///     The URI encoded string representation of this instance.
    /// </returns>
    string ToUriEncodedString();
}
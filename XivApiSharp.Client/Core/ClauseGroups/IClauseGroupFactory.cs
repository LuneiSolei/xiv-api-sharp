using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Core.ClauseGroups;

/// <summary>
/// Represents a type that is used to build clause groups.
/// </summary>
internal interface IClauseGroupFactory
{
    /// <summary>
    /// Creates a new instance of a clause group with the provided elements.
    /// </summary>
    /// <param name="elements">
    /// The elements to instantiate the clause group with.
    /// </param>
    /// <param name="decorator">
    /// The decorator to add to apply to the clause group.
    /// </param>
    /// <returns>
    /// The created clause group.
    /// </returns>
    /// <seealso cref="IClauseGroup"/>
    IClauseGroup CreateClauseGroup(IEnumerable<IBaseClause> elements, 
        ClauseDecorators decorator);
}
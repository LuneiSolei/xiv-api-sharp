namespace XivApiSharp.Client.Core.Clauses;

/// <summary>
/// Represents a type that is used to define a group of clauses. This clause
/// group is then utilized by <see cref="QueryString"/>.
/// </summary>
public interface IClauseGroup : IBaseClause
{
    /// <summary>
    /// The clauses that are within this clause group.
    /// </summary>
    IEnumerable<IBaseClause> Clauses { get; set; }

    /// <summary>
    /// The <see cref="ClauseDecorators">clause decorator</see> to be used in front of the clause group when converted
    /// to a string.
    /// </summary>
    ClauseDecorators Decorator { get; set; }

    /// <summary>
    /// Adds a <see cref="IClause{T}">single clause</see> or clause group to this clause group instance.
    /// </summary>
    /// <param name="clause">
    /// The clause or clause group to add.
    /// </param>
    void AddClause(IBaseClause clause);

    /// <summary>
    /// Adds multiple <see cref="IClause{T}">singular clauses</see> or clause groups to this clause group instance.
    /// </summary>
    /// <param name="clauses">
    /// The clauses or clause groups to add.
    /// </param>
    void AddClauses(IEnumerable<IBaseClause> clauses);
}
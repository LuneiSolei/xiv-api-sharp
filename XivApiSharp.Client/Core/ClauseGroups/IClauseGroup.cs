using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Core.ClauseGroups;

/// <summary>
/// Represents a type that is used to define a group of clauses. This clause
/// group is then utilized by <see cref="QueryString"/>.
/// </summary>
public interface IClauseGroup : IBaseClause
{
    void AddClause(IBaseClause clause);
    void AddClauses(IEnumerable<IBaseClause> clauses);
}
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Core;

public record QueryString
{
    private List<IClauseGroup> ClauseGroups { get; } = [];
    private List<IClause> Clauses { get; } = [];

    public void AddClause<T>(Clause<T> clause) => 
        Clauses.Add(clause);

    public void AddClauses<T>(IEnumerable<Clause<T>> clauses) =>
        Clauses.AddRange(clauses);

    public void AddClauseGroup<T>(ClauseGroup<T> clauseGroup) => 
        ClauseGroups.Add(clauseGroup);
    public void AddClauseGroup(ClauseGroup group) => 
        ClauseGroups.Add(group);
    
    public void AddClauseGroups<T>(IEnumerable<IClauseGroup> clausesGroups) =>
        ClauseGroups.AddRange(clausesGroups);
    public void AddClauseGroups(IEnumerable<ClauseGroup> groups) =>
        ClauseGroups.AddRange(groups);
    
    public override string ToString()
    {
        // Query clauses MUST be separated via whitespace
        string result = string.Join(" ", Clauses);
        result += string.Join(" ", ClauseGroups);
        
        return result;
    }
}
namespace XivApiSharp.Client.Core;

public record QueryString
{
    private List<ClauseGroup> ClauseGroups { get; } = [];
    private List<Clause> Clauses { get; } = [];

    public void AddClause(Clause clause) => 
        Clauses.Add(clause);

    public void AddClauses(IEnumerable<Clause> clauses) =>
        Clauses.AddRange(clauses);

    public void AddClauseGroup(ClauseGroup clauseGroup) => 
        ClauseGroups.Add(clauseGroup);
    
    public void AddClauseGroups(IEnumerable<ClauseGroup> clausesGroups) =>
        ClauseGroups.AddRange(clausesGroups);
    
    public override string ToString()
    {
        // Query clauses MUST be separated via whitespace
        string result = string.Join(" ", Clauses);
        result += string.Join(" ", ClauseGroups);
        
        return result;
    }
}
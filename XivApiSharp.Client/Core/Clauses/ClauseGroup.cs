namespace XivApiSharp.Client.Core.Clauses;

// TODO: Implement
internal sealed class ClauseGroup(ClauseGroupOperators? groupOperator) : IClauseGroup
{
    private List<IClause> Clauses { get; }
    private ClauseGroupOperators Operators { get; } = 
        groupOperator ?? ClauseGroupOperators.Or;

    public override string ToString()
    {
        return $"{GenerateOperator()}({string.Join(' ', Clauses)})";
    }

    private string GenerateOperator()
    {
        return Operators switch
        {
            ClauseGroupOperators.Or => string.Empty,
            ClauseGroupOperators.Must => "+",
            ClauseGroupOperators.MustNot => "-",
            _ => string.Empty
        };
    }
}
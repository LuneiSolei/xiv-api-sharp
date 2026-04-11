using XivApiSharp.Client.Core.Enums;

namespace XivApiSharp.Client.Core;

public class ClauseGroup(ClauseGroupOperator? groupOperator, List<Clause>? clauses)
{
    private List<Clause> Clauses { get; } = clauses ?? [];
    private ClauseGroupOperator Operator { get; } = 
        groupOperator ?? ClauseGroupOperator.Or;

    public override string ToString()
    {
        return $"{GenerateOperator()}({string.Join(' ', Clauses)})";
    }

    private string GenerateOperator()
    {
        return Operator switch
        {
            ClauseGroupOperator.Or => string.Empty,
            ClauseGroupOperator.Must => "+",
            ClauseGroupOperator.MustNot => "-",
            _ => string.Empty
        };
    }
}
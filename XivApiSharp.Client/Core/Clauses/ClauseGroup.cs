using XivApiSharp.Client.Core.Clauses.Enums;
using XivApiSharp.Client.Core.Clauses.Interfaces;
using XivApiSharp.Client.Core.Enums;

namespace XivApiSharp.Client.Core.Clauses;

// TODO: Implement
public class ClauseGroup(ClauseGroupOperator? groupOperator) : IClauseGroup
{
    private List<IClause> Clauses { get; }
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
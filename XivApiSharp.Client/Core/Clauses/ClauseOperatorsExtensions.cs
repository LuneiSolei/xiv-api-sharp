using XivApiSharp.Client.Core.Enums;

namespace XivApiSharp.Client.Core.Clauses;

public static class ClauseOperatorsExtensions
{
    extension(ClauseOperators op)
    {
        public string ToStringOperator()
        {
            return op switch
            {
                ClauseOperators.EqualTo => "=",
                ClauseOperators.PartiallyEqualTo => "~",
                ClauseOperators.LessThan => "<",
                ClauseOperators.LessThanOrEqualTo => "<=",
                ClauseOperators.GreaterThan => ">",
                ClauseOperators.GreaterThanOrEqualTo => ">=",
                _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
            };
        }
    }
}
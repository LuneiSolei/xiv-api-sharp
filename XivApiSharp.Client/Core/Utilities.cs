using XivApiSharp.Client.Core.Enums;

namespace XivApiSharp.Client.Core;

internal static class Utilities
{
    public static string ToOperatorSign(ClauseOperators op)
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
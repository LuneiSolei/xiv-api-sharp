using XivApiSharp.Client.Core.Enums;

namespace XivApiSharp.Client.Core;

internal static class Utilities
{
    public static string ToOperatorSign(ClauseOperators op)
    {
        switch (op)
        {
            case ClauseOperators.EqualTo:
                return "=";
            case ClauseOperators.PartiallyEqualTo:
                return "~";
            case ClauseOperators.LessThan:
                return "<";
            case ClauseOperators.LessThanOrEqualTo:
                return "<=";
            case ClauseOperators.GreaterThan:
                return ">";
            case ClauseOperators.GreaterThanOrEqualTo:
                return ">=";
            default:
                throw new ArgumentOutOfRangeException(nameof(op), op, null);
        }
    }
}
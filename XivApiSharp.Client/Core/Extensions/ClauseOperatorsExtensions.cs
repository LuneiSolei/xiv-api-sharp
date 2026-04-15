using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Core.Extensions;

/// <summary>
/// Extension methods for <see cref="ClauseOperators"/>.
/// </summary>
public static class ClauseOperatorsExtensions
{
    extension(ClauseOperators op)
    {
        /// <summary>
        /// Converts the instance into its string representation.
        /// </summary>
        /// <returns>
        /// The symbol(s) that represent the operator in the
        /// <see cref="QueryString"/>
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Indicates that an invalid operator option was used.
        /// </exception>
        public string Stringify()
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
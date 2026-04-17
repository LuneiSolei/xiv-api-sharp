namespace XivApiSharp.Client.Core.Clauses;

/// <inheritdoc/>
internal class ClauseFactory : IClauseFactory
{
    /// <inheritdoc/>
    IClause IClauseFactory.CreateClause<T>(string specifier, ClauseOperators op,
        T value, ClauseConditionals condition)
    {
        Clause<T> clause = new(specifier, op, value, condition);
        
        return clause;
    }
}
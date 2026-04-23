using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Infrastructure.Clauses;

/// <inheritdoc/>
internal class ClauseFactory : IClauseFactory
{
    /// <inheritdoc/>
    IClause IClauseFactory.CreateClause<T>(string specifier, ClauseOperators op,
        T value, ClauseDecorators decorator, SchemaLanguage lang)
    {
        Clause<T> clause = new(specifier, op, value, decorator, lang);
        
        return clause;
    }
}
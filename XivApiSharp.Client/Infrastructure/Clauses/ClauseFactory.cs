using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Infrastructure.Clauses;

/// <inheritdoc/>
internal class ClauseFactory : IClauseFactory
{
    /// <inheritdoc/>
    IClause<T> IClauseFactory.CreateClause<T>(
        ClauseDecorators decorator, 
        string specifier, 
        SchemaLanguage language, 
        ClauseOperators operation, 
        T value)
    {
        return new Clause<T>(
            decorator: decorator,
            specifier: specifier,
            language: language,
            operation: operation,
            value: value);
    }
}
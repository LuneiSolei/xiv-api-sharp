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

    /// <summary>
    /// Creates a new instance of a clause group with the provided elements.
    /// </summary>
    /// <param name="elements">
    /// The elements to instantiate the clause group with.
    /// </param>
    /// <param name="decorator">
    /// The decorator to add to apply to the clause group.
    /// </param>
    /// <returns>
    /// The created clause group.
    /// </returns>
    /// <seealso cref="IClauseGroup"/>
    IClauseGroup IClauseFactory.CreateClauseGroup(IEnumerable<IBaseClause> elements,
        ClauseDecorators decorator) =>
        new ClauseGroup(elements, decorator);
}
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Core.ClauseGroups;

/// <inheritdoc/>
internal class ClauseGroupFactory : IClauseGroupFactory
{
    /// <inheritdoc/>
    public IClauseGroup CreateClauseGroup(IEnumerable<IClauseElement> elements,
        ClauseDecorators decorator) =>
        new ClauseGroup(elements, decorator);
}
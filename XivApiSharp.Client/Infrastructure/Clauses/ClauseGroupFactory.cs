using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Client.Core.Clauses.Builders;
using XivApiSharp.Client.Infrastructure.Clauses.Builders;

namespace XivApiSharp.Client.Infrastructure.Clauses;

public class ClauseGroupFactory : IClauseGroupFactory
{
    /// <inheritdoc />
    IClauseGroup IClauseGroupFactory.CreateClauseGroup(IEnumerable<IBaseClause> elements, ClauseDecorators decorator) =>
        new ClauseGroup(elements, decorator);

    /// <inheritdoc />
    public IClauseGroupBuilder CreateClauseGroupBuilder() => new ClauseGroupBuilder(this);
}
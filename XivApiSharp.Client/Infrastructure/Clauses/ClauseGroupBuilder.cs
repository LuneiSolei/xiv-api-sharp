using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Infrastructure.Clauses;

/// <inheritdoc />
internal class ClauseGroupBuilder : IClauseGroupBuilder
{
    private ClauseDecorators _decorator = ClauseDecorators.None;
    private IEnumerable<IBaseClause> _clauses = [];
    private readonly IClauseFactory _factory;

    internal ClauseGroupBuilder(IClauseFactory factory)
    {
        _factory = factory;
    }

    /// <inheritdoc />
    public IClauseGroupBuilder WithClauses(IEnumerable<IBaseClause> clauses)
    {
        _clauses = _clauses.Concat(clauses);
        return this;
    }

    /// <inheritdoc />
    public IClauseGroupBuilder MustMatch
    {
        get
        {
            _decorator = ClauseDecorators.Must;
            return this;
        }
    }

    /// <inheritdoc />
    public IClauseGroupBuilder MustNotMatch
    {
        get
        {
            _decorator = ClauseDecorators.MustNot;
            return this;
        }
    }

    /// <inheritdoc/>
    public IClauseGroup Build()
    {
        return _factory.CreateClauseGroup(_clauses, _decorator);
    }
}
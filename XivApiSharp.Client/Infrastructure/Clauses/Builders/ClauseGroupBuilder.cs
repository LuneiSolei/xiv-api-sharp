using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Client.Core.Clauses.Builders;

namespace XivApiSharp.Client.Infrastructure.Clauses.Builders;

/// <inheritdoc />
internal class ClauseGroupBuilder : IClauseGroupBuilder
{
    /// <summary>
    ///     The decorator for the clause group to use.
    /// </summary>
    private ClauseDecorators _decorator = ClauseDecorators.None;

    /// <summary>
    ///     The clauses for the clause group to use.
    /// </summary>
    private IEnumerable<IBaseClause> _clauses = [];

    /// <summary>
    ///     The clause factory for the clause group builder to create the clause group with.
    /// </summary>
    private readonly IClauseGroupFactory _factory;

    /// <summary>
    ///     Internal constructor to instantiate with the clause factory.
    /// </summary>
    /// <param name="factory">
    ///     The clause factory to instantiate with.
    /// </param>
    internal ClauseGroupBuilder(IClauseGroupFactory factory) => _factory = factory;

    /// <inheritdoc />
    public IClauseGroupBuilder WithClauses(IEnumerable<IBaseClause> clauses)
    {
        _clauses = _clauses.Concat(clauses);
        return this;
    }

    /// <inheritdoc />
    public IClauseGroupBuilder WithDecorator(ClauseDecorators decorator)
    {
        _decorator = decorator;
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
    public IClauseGroup Build() => _factory.CreateClauseGroup(_clauses, _decorator);
}
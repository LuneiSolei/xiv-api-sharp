using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Infrastructure.Clauses;

/// <summary>
/// Builds a singular clause for use in a <see cref="QueryString"/>.
/// </summary>
/// <seealso cref="IClause"/>
public sealed class ClauseBuilder : IClauseBuilder
{
    /// <summary>
    /// The injected IClauseFactory for the builder to use.
    /// </summary>
    private readonly IClauseFactory _factory;

    /// <summary>
    /// Creates a new instance with an injected IClauseFactory.
    /// </summary>
    /// <param name="factory">The factory instance for the builder to use.</param>
    internal ClauseBuilder(IClauseFactory factory)
    {
        _factory = factory;
    }

    /// <inheritdoc/>
    public IWhereSpecifier WhereSpecifier(string name) => 
        new WhereSpecifier(name, _factory);
}
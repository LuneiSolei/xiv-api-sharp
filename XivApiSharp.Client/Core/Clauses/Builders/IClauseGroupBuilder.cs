namespace XivApiSharp.Client.Core.Clauses.Builders;

/// <summary>
/// Represents a type that is used to construct clause groups.
/// </summary>
/// <seealso cref="IClauseGroup"/>
public interface IClauseGroupBuilder
{
    /// <summary>
    /// Adds the provided clauses to the clause group.
    /// </summary>
    /// <param name="clauses">
    /// The clauses to add.
    /// </param>
    /// <returns>
    /// This instance to allow for method chaining additional options.
    /// </returns>
    IClauseGroupBuilder WithClauses(IEnumerable<IBaseClause> clauses);

    /// <summary>
    ///     Adds the provided clause decorator to the clause group.
    /// </summary>
    /// <param name="decorator">
    ///     The clause decorator to add.
    /// </param>
    /// <returns>
    ///     This instance to allow for method chaining additional options.
    /// </returns>
    IClauseGroupBuilder WithDecorator(ClauseDecorators decorator);

    /// <summary>
    /// Requires that at least one of the clauses in the group is matched on any returned results.
    /// </summary>
    /// <returns>This instance to allow for method chaining additional options.</returns>
    /// <seealso cref="ClauseDecorators"/>
    IClauseGroupBuilder MustMatch { get; }

    /// <summary>
    /// Requires that none of the clauses in the group are matched on any returned results.
    /// </summary>
    /// <returns>This instance to allow for method chaining additional options.</returns>
    /// <seealso cref="ClauseDecorators"/>
    IClauseGroupBuilder MustNotMatch { get; }

    /// <summary>
    /// Builds an instance of <see cref="IClauseGroup"/> using the previously provided options.
    /// </summary>
    /// <returns>A new instance of a clause group.</returns>
    IClauseGroup Build();
}
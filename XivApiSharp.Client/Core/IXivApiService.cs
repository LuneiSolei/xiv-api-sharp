using XivApiSharp.Client.Core.ClauseGroups;
using XivApiSharp.Client.Core.Clauses;

namespace XivApiSharp.Client.Core;

/// <summary>
/// Represents a type that is used for providing the main services of XIV API Sharp.
/// </summary>
public interface IXivApiService
{

    /// <summary>
    /// Creates a new instance of ClauseBuilder.
    /// </summary>
    /// <returns>
    /// The interface for ClauseBuilder.
    /// </returns>
    /// <seealso cref="IClauseBuilder{T}"/>
    IClauseBuilder<T> NewClause<T>() where T : notnull;

    /// <summary>
    /// Creates a new instance of <see cref="IClauseGroupBuilder"/>
    /// </summary>
    /// <returns>A new instance of a clause group builder.</returns>
    IClauseGroupBuilder NewClauseGroup();
}
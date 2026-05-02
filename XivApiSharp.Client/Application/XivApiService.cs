using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Clauses.Builders;

namespace XivApiSharp.Client.Application;

/// <summary>
/// Provides functionality to interact with the XIV API.
/// </summary>
/// <seealso href="https://xivapi.com"/>
internal class XivApiService : IXivApiService
{
    private readonly IXivApiDependencies _dependencies;

    /// <summary>
    /// Constructor for XivApiService.
    /// </summary>
    /// <param name="opts">
    /// The options configuration used to modify behavior of
    /// the XivApiService.
    /// </param>
    /// <param name="client">
    /// The HttpClient used for making requests.
    /// </param>
    public XivApiService(IXivApiDependencies deps, HttpClient client) => _dependencies = deps;

    /// <inheritdoc />
    public IClauseBuilder<T> NewClause<T>() where T : notnull => _dependencies.ClauseFactory.CreateClauseBuilder<T>();

    /// <inheritdoc/>
    public IClauseGroupBuilder NewClauseGroup() => _dependencies.ClauseGroupFactory.CreateClauseGroupBuilder();
}
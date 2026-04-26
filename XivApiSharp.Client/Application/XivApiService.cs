using Microsoft.Extensions.Options;
using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Client.Core.InternalDependencies;
using XivApiSharp.Client.Core.Options;
using XivApiSharp.Client.Infrastructure.Clauses;

namespace XivApiSharp.Client.Application;

/// <summary>
/// Provides functionality to interact with the XIV API.
/// </summary>
/// <seealso href="https://xivapi.com"/>
internal class XivApiService : IXivApiService
{
    /// <summary>
    /// Stores the options configuration.
    /// </summary>
    /// <seealso cref="XivApiOptions"/>
    private readonly XivApiOptions _opts;

    /// <summary>
    /// Stores access to internal dependencies required by XivApiService.
    /// </summary>
    /// <remarks>
    /// This pattern ensures that internal dependencies are encapsulated and not
    /// exposed directly to users.
    /// </remarks>
    /// <seealso cref="IInternalDependencies"/>
    private readonly IInternalDependencies _internalDependencies;

    /// <summary>
    /// The HttpClient to use for making requests.
    /// </summary>
    private readonly HttpClient _client;

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
    /// <param name="internalDependencies">
    /// The dependencies required by XivApiService.
    /// </param>
    public XivApiService(IOptions<XivApiOptions> opts, HttpClient client,
        IInternalDependencies internalDependencies)
    {
        _opts = opts.Value;
        _internalDependencies = internalDependencies;
        _client = client;
    }

    /// <inheritdoc />
    public IClauseBuilder NewClause() => new ClauseBuilder(_internalDependencies.ClauseFactory);
}
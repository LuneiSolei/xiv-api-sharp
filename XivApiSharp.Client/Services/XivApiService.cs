using Microsoft.Extensions.Options;
using XivApiSharp.Client.Core.Options;
using XivApiSharp.Client.Infrastructure.Requests;
using XivApiSharp.Client.Infrastructure.Requests.Clauses;
using XivApiSharp.Client.Infrastructure.Requests.Clauses.Steps;

namespace XivApiSharp.Client.Services;

public class XivApiService(IOptions<XivApiOptions> opts, HttpClient _client)
{
    private readonly XivApiOptions _opts = opts.Value;

    public RequestBuilder NewRequestBuilder() => new (_opts);

    public static IInitialClauseBuilderStep NewClause() => new ClauseBuilder();
}
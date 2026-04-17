using Microsoft.Extensions.Options;
using XivApiSharp.Client.Application.Clauses;
using XivApiSharp.Client.Core.Options;
using XivApiSharp.Client.Infrastructure.Clauses;
using XivApiSharp.Client.Infrastructure.Requests;

namespace XivApiSharp.Client.Application;

public class XivApiService(IOptions<XivApiOptions> opts, HttpClient _client)
{
    private readonly XivApiOptions _opts = opts.Value;

    public RequestBuilder NewRequestBuilder() => new (_opts);

    public static IClauseBuilder NewClause() => new ClauseBuilder();
}
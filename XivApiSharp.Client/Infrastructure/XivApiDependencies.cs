using Microsoft.Extensions.Options;
using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Client.Core.Options;

namespace XivApiSharp.Client.Infrastructure;

internal class XivApiDependencies : IXivApiDependencies
{
    public XivApiDependencies(
        IOptions<XivApiOptions> options,
        HttpClient client,
        IClauseFactory clauseFactory,
        IClauseGroupFactory clauseGroupFactory)
    {
        Options = options;
        Client = client;
        ClauseFactory = clauseFactory;
        ClauseGroupFactory = clauseGroupFactory;
    }

    public IOptions<XivApiOptions> Options { get; }
    public HttpClient Client { get; set; }
    public IClauseFactory ClauseFactory { get; }
    public IClauseGroupFactory ClauseGroupFactory { get; }
}
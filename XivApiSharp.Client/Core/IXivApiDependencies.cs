using Microsoft.Extensions.Options;
using XivApiSharp.Client.Core.Clauses;
using XivApiSharp.Client.Core.Options;

namespace XivApiSharp.Client.Core;

internal interface IXivApiDependencies
{
    IOptions<XivApiOptions> Options { get; }

    HttpClient Client { get; set; }

    IClauseFactory ClauseFactory { get; }

    IClauseGroupFactory ClauseGroupFactory { get; }
}
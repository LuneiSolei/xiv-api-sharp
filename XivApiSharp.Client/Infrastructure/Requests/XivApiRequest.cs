using XivApiSharp.Client.Core;
using XivApiSharp.Client.Core.Options;

namespace XivApiSharp.Client.Infrastructure.Requests;

public abstract class XivApiRequest
{
    protected string BaseUrl;
    protected XivApiOptions Options;
    protected string? Version;
    protected SchemaLanguage? Language;
    protected string? Schema;
    
    internal XivApiRequest(XivApiOptions opts)
    {
        Options = opts;
        BaseUrl = $"{opts.Scheme}://{opts.BaseUrl}/";
    }
}
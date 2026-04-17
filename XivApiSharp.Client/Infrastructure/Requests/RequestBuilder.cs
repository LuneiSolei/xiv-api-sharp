using XivApiSharp.Client.Core.Options;
using XivApiSharp.Client.Core.Requests;

namespace XivApiSharp.Client.Infrastructure.Requests;

public sealed class RequestBuilder : IRequestBuilder
{
    private readonly XivApiOptions _opts;

    internal RequestBuilder(XivApiOptions opts)
    {
        _opts = opts;
    }

    public ISearchSheetRequest AsSearch()
    {
        return new SearchSheetRequest(_opts);
    }

    public override string ToString() => "";
}
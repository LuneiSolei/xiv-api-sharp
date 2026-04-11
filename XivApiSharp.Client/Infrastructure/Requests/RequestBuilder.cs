using XivApiSharp.Client.Core.Options;
using XivApiSharp.Client.Infrastructure.Requests.Steps;

namespace XivApiSharp.Client.Infrastructure.Requests;

public sealed class RequestBuilder : IInitialRequestBuilderStep
{
    private readonly XivApiOptions _opts;

    internal RequestBuilder(XivApiOptions opts)
    {
        _opts = opts;
    }

    public ISearchSheetRequestStep AsSearch()
    {
        return new SearchSheetRequest(_opts);
    }

    public override string ToString() => "";
}
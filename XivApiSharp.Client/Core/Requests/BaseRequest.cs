namespace XivApiSharp.Client.Core.Requests;

/// <inheritdoc />
internal abstract class BaseRequest : IBaseRequest
{
    /// <inheritdoc />
    public required IQueryString QueryString { get; set; }

    /// <inheritdoc />
    public required string Endpoint { get; set; }

    private protected HttpClient Client { get; }

    internal BaseRequest(HttpClient client) => Client = client;

    public async Task<HttpContent> GetAsync()
    {
        Client.BaseAddress = new Uri(Endpoint);
        HttpResponseMessage response = await Client.GetAsync(Client.BaseAddress);
        response.EnsureSuccessStatusCode();

        return response.Content;
    }
}
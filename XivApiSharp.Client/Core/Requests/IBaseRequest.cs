namespace XivApiSharp.Client.Core.Requests;

public interface IBaseRequest
{
    IQueryString QueryString { get; }

    string Endpoint { get; }

    Task<HttpContent> GetAsync();
}
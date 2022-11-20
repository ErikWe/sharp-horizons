namespace SharpHorizons.Query.Request.HTTP;

using SharpHorizons.Query.Result.HTTP;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

/// <inheritdoc cref="IHTTPQueryHandler"/>
internal sealed class HTTPQueryHandler : IHTTPQueryHandler
{
    /// <summary><inheritdoc cref="IHttpClientFactory" path="/summary"/></summary>
    private HttpClient Client { get; }

    /// <inheritdoc cref="HTTPQueryHandler"/>
    /// <param name="httpClientFactory"><inheritdoc cref="Client" path="/summary"/></param>
    public HTTPQueryHandler(IHttpClientFactory httpClientFactory)
    {
        Client = httpClientFactory.CreateClient();
    }

    async Task<IHTTPQueryResult> IHTTPQueryHandler.RequestAsync(HorizonsQueryURI queryURI) => await RequestAsync(queryURI, CancellationToken.None);
    async Task<IHTTPQueryResult> IHTTPQueryHandler.RequestAsync(HorizonsQueryURI queryURI, CancellationToken token) => await RequestAsync(queryURI, token);

    /// <inheritdoc cref="IHTTPQueryHandler.RequestAsync(HorizonsQueryURI, CancellationToken)"/>
    private async Task<IHTTPQueryResult> RequestAsync(HorizonsQueryURI queryURI, CancellationToken token)
    {
        var response = await Client.GetAsync(queryURI, token);

        return new HTTPQueryResult(response);
    }
}

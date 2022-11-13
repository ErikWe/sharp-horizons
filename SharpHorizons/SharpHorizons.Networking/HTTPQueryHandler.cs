namespace SharpHorizons.Networking;

using SharpHorizons.Query.Request;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

/// <inheritdoc cref="IHTTPQueryHandler"/>
internal sealed class HTTPQueryHandler : IHTTPQueryHandler
{
    /// <summary><inheritdoc cref="IHttpClientFactory" path="/summary"/></summary>
    private HttpClient Client { get; }

    public HTTPQueryHandler(IHttpClientFactory httpClientFactory)
    {
        Client = httpClientFactory.CreateClient();
    }

    async Task<HttpResponseMessage> IHTTPQueryHandler.RequestAsync(HorizonsQueryURI queryURI) => await Client.GetAsync(queryURI);
    async Task<HttpResponseMessage> IHTTPQueryHandler.RequestAsync(HorizonsQueryURI queryURI, CancellationToken token) => await Client.GetAsync(queryURI, token);
}

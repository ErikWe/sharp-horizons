namespace SharpHorizons.Query.Request.HTTP;

using SharpHorizons.Query.Result.HTTP;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

/// <inheritdoc cref="IHTTPQueryHandler"/>
internal sealed class HTTPQueryHandler : IHTTPQueryHandler
{
    /// <inheritdoc cref="IHttpClientFactory"/>
    private HttpClient Client { get; }

    /// <inheritdoc cref="HTTPQueryHandler"/>
    /// <param name="httpClientFactory"><inheritdoc cref="Client" path="/summary"/></param>
    public HTTPQueryHandler(IHttpClientFactory httpClientFactory)
    {
        Client = httpClientFactory.CreateClient();
    }

    async Task<HTTPQueryResult> IHTTPQueryHandler.RequestAsync(HorizonsQueryURI queryURI) => await RequestAsync(queryURI, CancellationToken.None);
    async Task<HTTPQueryResult> IHTTPQueryHandler.RequestAsync(HorizonsQueryURI queryURI, CancellationToken token) => await RequestAsync(queryURI, token);

    /// <inheritdoc cref="IHTTPQueryHandler.RequestAsync(HorizonsQueryURI, CancellationToken)"/>
    private async Task<HTTPQueryResult> RequestAsync(HorizonsQueryURI queryURI, CancellationToken token)
    {
        HorizonsQueryURI.Validate(queryURI);

        var response = await Client.GetAsync(queryURI.Value, token);

        return new HTTPQueryResult(response);
    }
}

namespace SharpHorizons.Query.Request.HTTP;

using SharpHorizons.Query.Result.HTTP;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

/// <inheritdoc cref="IHTTPQueryHandler"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class HTTPQueryHandler : IHTTPQueryHandler
{
    /// <inheritdoc cref="IHorizonsHTTPAddressProvider"/>
    private IHorizonsHTTPAddressProvider HTTPAddressProvider { get; }

    /// <inheritdoc cref="IHttpClientFactory"/>
    private HttpClient Client { get; }

    /// <inheritdoc cref="HTTPQueryHandler"/>
    /// <param name="httpAddressProvider"><inheritdoc cref="HTTPAddressProvider" path="/summary"/></param>
    /// <param name="httpClientFactory"><inheritdoc cref="Client" path="/summary"/></param>
    public HTTPQueryHandler(IHorizonsHTTPAddressProvider httpAddressProvider, IHttpClientFactory httpClientFactory)
    {
        HTTPAddressProvider = httpAddressProvider;

        Client = httpClientFactory.CreateClient();
    }

    async Task<HTTPQueryResult> IHTTPQueryHandler.RequestAsync(HorizonsQueryString queryString) => await RequestAsync(queryString, CancellationToken.None).ConfigureAwait(false);
    async Task<HTTPQueryResult> IHTTPQueryHandler.RequestAsync(HorizonsQueryString queryString, CancellationToken token) => await RequestAsync(queryString, token).ConfigureAwait(false);

    /// <inheritdoc cref="IHTTPQueryHandler.RequestAsync(HorizonsQueryString, CancellationToken)"/>
    private async Task<HTTPQueryResult> RequestAsync(HorizonsQueryString queryString, CancellationToken token)
    {
        HorizonsQueryString.Validate(queryString);

        var response = await Client.GetAsync(ComposeURI(queryString), token).ConfigureAwait(false);

        return new HTTPQueryResult(response);
    }

    /// <summary>Composes a <see cref="Uri"/> describing the <see cref="HorizonsQueryString"/> using HTTP.</summary>
    /// <param name="queryString">This <see cref="HorizonsQueryString"/> is described by the composed <see cref="Uri"/>.</param>
    private Uri ComposeURI(HorizonsQueryString queryString) => new(HTTPAddressProvider.HTTPAddress, $"?{queryString.Value}");
}

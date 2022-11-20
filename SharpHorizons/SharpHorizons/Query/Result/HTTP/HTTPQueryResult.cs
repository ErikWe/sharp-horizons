namespace SharpHorizons.Query.Result.HTTP;

using System.Diagnostics.CodeAnalysis;
using System.Net.Http;

/// <inheritdoc cref="IHTTPQueryResult"/>
internal sealed record class HTTPQueryResult : IHTTPQueryResult
{
    public required HttpResponseMessage Response { get; init; }

    /// <inheritdoc cref="HTTPQueryResult"/>
    public HTTPQueryResult() { }

    /// <inheritdoc cref="HTTPQueryResult"/>
    /// <param name="response"><inheritdoc cref="Response" path="/summary"/></param>
    [SetsRequiredMembers]
    public HTTPQueryResult(HttpResponseMessage response)
    {
        Response = response;
    }
}

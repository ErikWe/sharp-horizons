namespace SharpHorizons.Query.Result.HTTP;

using System.Net.Http;

/// <summary>Represents the result of a HTTP query.</summary>
public interface IHTTPQueryResult
{
    /// <summary>The <see cref="HttpResponseMessage"/> of the HTTP query.</summary>
    public abstract HttpResponseMessage Response { get; }
}

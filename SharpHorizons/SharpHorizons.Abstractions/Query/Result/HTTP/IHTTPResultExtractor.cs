namespace SharpHorizons.Query.Result.HTTP;

using System.Threading.Tasks;

/// <summary>Handles extraction of <see cref="IQueryResult"/> from <see cref="IHTTPQueryResult"/>.</summary>
public interface IHTTPResultExtractor
{
    /// <summary>Extracts a <see cref="IQueryResult"/> from <paramref name="httpResult"/>.</summary>
    /// <param name="httpResult">A <see cref="IQueryResult"/> is extracted from this <see cref="IHTTPQueryResult"/>.</param>
    /// <exception cref="UnexpectedQueryResultFormatException"/>
    /// <exception cref="UnsuccesfulHTTPRequestException"/>
    public abstract Task<IQueryResult> ExtractAsync(IHTTPQueryResult httpResult);
}

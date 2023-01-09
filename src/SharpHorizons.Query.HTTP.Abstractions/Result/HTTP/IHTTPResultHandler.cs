namespace SharpHorizons.Query.Result.HTTP;

using Microsoft.CodeAnalysis;

using System;
using System.Threading.Tasks;

/// <summary>Handles extraction of <see cref="QueryResult"/> from <see cref="HTTPQueryResult"/>.</summary>
public interface IHTTPResultHandler
{
    /// <summary>Extracts a <see cref="QueryResult"/> from <paramref name="httpResult"/>.</summary>
    /// <param name="httpResult">A <see cref="QueryResult"/> is extracted from this <see cref="HTTPQueryResult"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="UnexpectedQueryResultFormatException"/>
    public abstract Task<Optional<QueryResult>> ExtractAsync(HTTPQueryResult httpResult);
}

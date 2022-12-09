namespace SharpHorizons.Query.Request.HTTP;

using SharpHorizons.Query.Result.HTTP;

using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>Executes JPL Horizons queries using HTTP.</summary>
public interface IHTTPQueryHandler
{
    /// <summary>Executes a query identified by a <see cref="HorizonsQueryURI"/>, <paramref name="queryURI"/>.</summary>
    /// <param name="queryURI">The <see cref="HorizonsQueryURI"/> of the executed query, described using HTTP.</param>
    /// <exception cref="ArgumentException"/>
    public abstract Task<IHTTPQueryResult> RequestAsync(HorizonsQueryURI queryURI);

    /// <summary>Executes a query identified by a <see cref="HorizonsQueryURI"/>, <paramref name="queryURI"/>.</summary>
    /// <param name="queryURI">The <see cref="HorizonsQueryURI"/> of the executed query, described using HTTP.</param>
    /// <param name="token">Allows the query to be cancelled.</param>
    /// <exception cref="ArgumentException"/>
    public abstract Task<IHTTPQueryResult> RequestAsync(HorizonsQueryURI queryURI, CancellationToken token);
}

namespace SharpHorizons.Query.Request.HTTP;

using SharpHorizons.Query.Result.HTTP;

using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>Executes JPL Horizons queries using HTTP.</summary>
public interface IHTTPQueryHandler
{
    /// <summary>Executes a query described by the <see cref="HorizonsQueryString"/> <paramref name="queryString"/>.</summary>
    /// <param name="queryString">This <see cref="HorizonsQueryString"/> describes the query to be executed.</param>
    /// <exception cref="ArgumentException"/>
    public abstract Task<HTTPQueryResult> RequestAsync(HorizonsQueryString queryString);

    /// <summary>Executes a query described by the <see cref="HorizonsQueryString"/> <paramref name="queryString"/>.</summary>
    /// <param name="queryString">Ths <see cref="HorizonsQueryString"/> describes the query to be executed.</param>
    /// <param name="token">Allows the query to be cancelled.</param>
    /// <exception cref="ArgumentException"/>
    public abstract Task<HTTPQueryResult> RequestAsync(HorizonsQueryString queryString, CancellationToken token);
}

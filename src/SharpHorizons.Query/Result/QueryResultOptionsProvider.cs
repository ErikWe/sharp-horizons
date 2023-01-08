namespace SharpHorizons.Query.Result;

using Microsoft.Extensions.Options;

using SharpHorizons.Settings.Query.Result;

/// <inheritdoc cref="IQueryResultOptionsProvider"/>
internal sealed class QueryResultOptionsProvider : IQueryResultOptionsProvider
{
    /// <inheritdoc cref="QueryResultOptions"/>
    private QueryResultOptions Options { get; }

    /// <inheritdoc cref="QueryResultOptionsProvider"/>
    /// <param name="options"><inheritdoc cref="Options" path="/summary"/></param>
    public QueryResultOptionsProvider(IOptions<QueryResultOptions> options)
    {
        Options = options.Value;
    }

    string IQueryResultOptionsProvider.RawTextSource => Options.RawTextSource;
    string IQueryResultOptionsProvider.RawTextVersion => Options.RawTextVersion;
}

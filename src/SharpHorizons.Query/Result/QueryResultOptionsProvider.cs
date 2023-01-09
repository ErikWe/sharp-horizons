namespace SharpHorizons.Query.Result;

using Microsoft.Extensions.Options;

using SharpHorizons.Settings.Query.Result;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IQueryResultOptionsProvider"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
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

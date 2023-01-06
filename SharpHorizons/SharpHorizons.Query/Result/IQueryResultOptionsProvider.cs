namespace SharpHorizons.Query.Result;

using SharpHorizons.Settings.Query.Result;

/// <summary>Provides options for how the result of a query is interpreted.</summary>
public interface IQueryResultOptionsProvider
{
    /// <inheritdoc cref="QueryResultOptions.RawTextSource"/>
    public abstract string RawTextSource { get; }

    /// <inheritdoc cref="QueryResultOptions.RawTextVersion"/>
    public abstract string RawTextVersion { get; }
}

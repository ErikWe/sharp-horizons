namespace SharpHorizons.Query.Result;

/// <summary>Provides options related to query results.</summary>
public interface IQueryResultOptionsProvider
{
    /// <summary>The key corresponding to the source in a response formatted as raw text.</summary>
    public abstract string RawTextSource { get; }

    /// <summary>The key corresponding to the version in a response formatted as raw text.</summary>
    public abstract string RawTextVersion { get; }
}

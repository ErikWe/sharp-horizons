namespace SharpHorizons.Query.Result;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Describes the signature of a <see cref="IQueryResult"/>.</summary>
public readonly record struct QueryResultSignature
{
    /// <summary>The source of the result.</summary>
    public required string Source { get; init; }

    /// <summary>The version of <see cref="Source"/> used to execute the query.</summary>
    public required string Version { get; init; }

    /// <inheritdoc cref="QueryResultSignature"/>
    public QueryResultSignature() { }

    /// <inheritdoc cref="QueryResultSignature"/>
    /// <param name="source"><inheritdoc cref="Source" path="/summary"/></param>
    /// <param name="version"><inheritdoc cref="Version" path="/summary"/></param>
    [SetsRequiredMembers]
    public QueryResultSignature(string source, string version)
    {
        Source = source;
        Version = version;
    }
}

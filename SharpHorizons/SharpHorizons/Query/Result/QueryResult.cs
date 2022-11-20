namespace SharpHorizons.Query.Result;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IQueryResult"/>
internal sealed record class QueryResult : IQueryResult
{
    public required QueryResultSignature Signature { get; init; }
    public required string Content { get; init; }

    /// <inheritdoc cref="QueryResult"/>
    public QueryResult() { }

    /// <inheritdoc cref="QueryResult"/>
    /// <param name="signature"><inheritdoc cref="Signature" path="/summary"/></param>
    /// <param name="content"><inheritdoc cref="Content" path="/summary"/></param>
    [SetsRequiredMembers]
    public QueryResult(QueryResultSignature signature, string content)
    {
        Signature = signature;
        Content = content;
    }
}

namespace SharpHorizons.Query.Result;

/// <summary>Represents the result of a query.</summary>
public interface IQueryResult
{
    /// <summary>The <see cref="QueryResultSignature"/> of the <see cref="IQueryResult"/>.</summary>
    public QueryResultSignature Signature { get; }

    /// <summary>The content of the <see cref="IQueryResult"/>.</summary>
    public string Content { get; }
}

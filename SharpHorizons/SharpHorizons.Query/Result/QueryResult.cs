namespace SharpHorizons.Query.Result;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Represents the result, or a part of the result, of a query.</summary>
public readonly record struct QueryResult
{
    /// <summary>The <see cref="QueryResultSignature"/> of the <see cref="QueryResult"/>.</summary>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidOperationException"/>
    public required QueryResultSignature Signature
    {
        get
        {
            try
            {
                QueryResultSignature.Validate(signatureField);
            }
            catch (ArgumentException e)
            {
                throw InvalidOperationExceptionFactory.InvalidState<QueryResult>(e);
            }

            return signatureField;
        }
        init
        {
            QueryResultSignature.Validate(value);

            signatureField = value;
        }
    }

    /// <summary>The content of the <see cref="QueryResult"/>.</summary>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    public required string Content
    {
        get
        {
            try
            {
                ArgumentNullException.ThrowIfNull(contentField);
            }
            catch (ArgumentException e)
            {
                throw InvalidOperationExceptionFactory.InvalidState<QueryResult>(e);
            }

            return contentField;
        }
        init
        {
            ArgumentNullException.ThrowIfNull(value);

            contentField = value;
        }
    }

    /// <inheritdoc cref="QueryResult"/>
    public QueryResult() { }

    /// <inheritdoc cref="QueryResult"/>
    /// <param name="signature"><inheritdoc cref="Signature" path="/summary"/></param>
    /// <param name="content"><inheritdoc cref="Content" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    [SetsRequiredMembers]
    public QueryResult(QueryResultSignature signature, string content)
    {
        Signature = signature;
        Content = content;
    }

    /// <summary>Backing field for <see cref="Signature"/>. Should not be used elsewhere.</summary>
    private readonly QueryResultSignature signatureField;
    /// <summary>Backing field for <see cref="Content"/>. Should not be used elsewhere.</summary>
    private readonly string contentField = null!;

    /// <summary>Validates the <see cref="QueryResult"/> <paramref name="result"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="result">This <see cref="QueryResult"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="result"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(QueryResult result, [CallerArgumentExpression(nameof(result))] string? argumentExpression = null)
    {
        try
        {
            _ = result.Signature;
            _ = result.Content;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<QueryResult>(argumentExpression, e);
        }
    }
}

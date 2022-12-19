namespace SharpHorizons.Query.Result;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Describes the signature of a <see cref="QueryResult"/>.</summary>
public readonly record struct QueryResultSignature
{
    /// <summary>The source of the <see cref="QueryResult"/>.</summary>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public required string Source
    {
        get
        {
            try
            {
                ArgumentException.ThrowIfNullOrEmpty(sourceField);
            }
            catch (ArgumentException e)
            {
                throw InvalidOperationExceptionFactory.InvalidState<QueryResultSignature>(e);
            }

            return sourceField;
        }
        init
        {
            ArgumentException.ThrowIfNullOrEmpty(value);

            sourceField = value;
        }
    }

    /// <summary>The version of <see cref="Source"/> used to execute the query.</summary>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public required string Version
    {
        get
        {
            try
            {
                ArgumentException.ThrowIfNullOrEmpty(versionField);
            }
            catch (ArgumentException e)
            {
                throw InvalidOperationExceptionFactory.InvalidState<QueryResultSignature>(e);
            }

            return versionField;
        }
        init
        {
            ArgumentException.ThrowIfNullOrEmpty(value);

            versionField = value;
        }
    }

    /// <inheritdoc cref="QueryResultSignature"/>
    public QueryResultSignature() { }

    /// <inheritdoc cref="QueryResultSignature"/>
    /// <param name="source"><inheritdoc cref="Source" path="/summary"/></param>
    /// <param name="version"><inheritdoc cref="Version" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    [SetsRequiredMembers]
    public QueryResultSignature(string source, string version)
    {
        Source = source;
        Version = version;
    }

    /// <summary>Backing field for <see cref="Source"/>. Should not be used elsewhere.</summary>
    private readonly string? sourceField;
    /// <summary>Backing field for <see cref="Version"/>. Should not be used elsewhere.</summary>
    private readonly string? versionField;

    /// <summary>Validates the <see cref="QueryResultSignature"/> <paramref name="signature"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="signature">This <see cref="QueryResultSignature"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="signature"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(QueryResultSignature signature, [CallerArgumentExpression(nameof(signature))] string? argumentExpression = null)
    {
        try
        {
            _ = signature.Source;
            _ = signature.Version;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<QueryResultSignature>(argumentExpression, e);
        }
    }
}

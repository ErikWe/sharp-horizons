namespace SharpHorizons.Query.Result;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Describes the signature of a <see cref="IQueryResult"/>.</summary>
public readonly record struct QueryResultSignature
{
    /// <summary>The source of the <see cref="IQueryResult"/>.</summary>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public required string Source
    {
        get
        {
            Validate();

            return sourceField!;
        }
        init
        {
            ValidateSource(value);

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
            Validate();

            return versionField!;
        }
        init
        {
            ValidateSource(value);

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

    /// <summary>Validates that <paramref name="source"/> can be used to represent the source of a <see cref="QueryResultSignature"/>, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="source"><inheritdoc cref="Source" path="/summary"/></param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="source"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void ValidateSource(string? source, [CallerArgumentExpression(nameof(source))] string? argumentExpression = null) => ArgumentException.ThrowIfNullOrEmpty(source, argumentExpression);

    /// <summary>Validates that <paramref name="version"/> can be used to represent the version of a <see cref="QueryResultSignature"/>, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="version"><inheritdoc cref="Version" path="/summary"/></param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="version"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void ValidateVersion(string? version, [CallerArgumentExpression(nameof(version))] string? argumentExpression = null) => ArgumentException.ThrowIfNullOrEmpty(version, argumentExpression);

    /// <summary>Validates the <see cref="QueryResultSignature"/> <paramref name="signature"/>, and throws an <see cref="Exception"/> of type <typeparamref name="TException"/> if invalid.</summary>
    /// <typeparam name="TException">The type of the <see cref="Exception"/> that is thrown if <paramref name="signature"/> is invalid.</typeparam>
    /// <param name="signature">This <see cref="QueryResultSignature"/> is validated.</param>
    /// <param name="exceptionInstantiation">Handles instantiation of <typeparamref name="TException"/>.</param>
    private static void Validate<TException>(QueryResultSignature signature, ExceptionInstantiation<TException> exceptionInstantiation) where TException : Exception
    {
        try
        {
            ValidateSource(signature.sourceField);
            ValidateVersion(signature.versionField);
        }
        catch (ArgumentException e)
        {
            throw exceptionInstantiation(e);
        }
    }

    /// <summary>Validates the <see cref="QueryResultSignature"/>, and throws an <see cref="InvalidOperationException"/> if invalid.</summary>
    /// <exception cref="InvalidOperationException"/>
    private void Validate() => Validate(this, InvalidOperationExceptionFactory.InvalidState<QueryResultSignature>);

    /// <summary>Validates the <see cref="QueryResultSignature"/> <paramref name="signature"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="signature">This <see cref="QueryResultSignature"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="signature"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(QueryResultSignature signature, [CallerArgumentExpression(nameof(signature))] string? argumentExpression = null) => Validate(signature, ArgumentExceptionFactory.InvalidStateDelegate<QueryResultSignature>(argumentExpression));
}

namespace SharpHorizons.Query.Result.HTTP;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Runtime.CompilerServices;

/// <summary>Represents the result of a HTTP query.</summary>
public readonly record struct HTTPQueryResult
{
    /// <summary>The <see cref="HttpResponseMessage"/> of the HTTP query.</summary>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    public required HttpResponseMessage Response
    {
        get
        {
            try
            {
                ArgumentNullException.ThrowIfNull(responseField);
            }
            catch (ArgumentException e)
            {
                throw InvalidOperationExceptionFactory.InvalidState<HTTPQueryResult>(e);
            }

            return responseField;
        }
        init
        {
            ArgumentNullException.ThrowIfNull(value);

            responseField = value;
        }
    }

    /// <inheritdoc cref="HTTPQueryResult"/>
    public HTTPQueryResult() { }

    /// <inheritdoc cref="HTTPQueryResult"/>
    /// <param name="response"><inheritdoc cref="Response" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    [SetsRequiredMembers]
    public HTTPQueryResult(HttpResponseMessage response)
    {
        Response = response;
    }

    /// <summary>Backing field for <see cref="Response"/>. Should not be used elsewhere.</summary>
    private readonly HttpResponseMessage responseField = null!;

    /// <summary>Validates the <see cref="HTTPQueryResult"/> <paramref name="result"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="result">This <see cref="HTTPQueryResult"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="result"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(HTTPQueryResult result, [CallerArgumentExpression(nameof(result))] string? argumentExpression = null)
    {
        try
        {
            _ = result.Response;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<HTTPQueryResult>(argumentExpression, e);
        }
    }
}

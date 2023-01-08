namespace SharpHorizons.Query.Request;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Represents a <see cref="string"/> that describes a Horizons query.</summary>
public readonly record struct HorizonsQueryString
{
    /// <summary>The <see cref="string"/> that describe a Horizons query.</summary>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    public required string Value
    {
        get
        {
            try
            {
                ArgumentExceptionUtility.ThrowIfNullOrWhiteSpace(valueField);
            }
            catch (ArgumentException e)
            {
                throw InvalidOperationExceptionFactory.InvalidState<HorizonsQueryString>(e);
            }

            return valueField;
        }
        init
        {
            ArgumentExceptionUtility.ThrowIfNullOrWhiteSpace(value);

            valueField = value;
        }
    }

    /// <inheritdoc cref="HorizonsQueryString"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    [SetsRequiredMembers]
    public HorizonsQueryString(string value)
    {
        Value = value;
    }

    /// <summary>Retrieves the <see cref="Value"/> represented by the <see cref="HorizonsQueryString"/>.</summary>
    /// <exception cref="InvalidOperationException"/>
    public override string ToString() => Value;

    /// <summary>Backing field for <see cref="Value"/>. Should not be used elsewhere.</summary>
    private readonly string? valueField;

    /// <inheritdoc cref="HorizonsQueryString(string)"/>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator HorizonsQueryString(string value) => new(value);

    /// <summary>Retrieves the <see cref="Value"/> represented by <paramref name="queryString"/>.</summary>
    /// <param name="queryString"><inheritdoc cref="HorizonsQueryString" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    public static explicit operator string(HorizonsQueryString queryString)
    {
        try
        {
            return queryString.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<HorizonsQueryString>(nameof(queryString), e);
        }
    }

    /// <summary>Validates the <see cref="HorizonsQueryString"/> <paramref name="queryString"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="queryString">This <see cref="HorizonsQueryString"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="queryString"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(HorizonsQueryString queryString, [CallerArgumentExpression(nameof(queryString))] string? argumentExpression = null)
    {
        try
        {
            _ = queryString.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<HorizonsQueryString>(argumentExpression, e);
        }
    }
}

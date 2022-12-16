namespace SharpHorizons.Query.Request;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Represents an <see cref="Uri"/> that describes a Horizons query.</summary>
public readonly record struct HorizonsQueryURI
{
    /// <summary>The <see cref="Uri"/> that describe a Horizons query.</summary>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    public required Uri Value
    {
        get
        {
            try
            {
                ArgumentNullException.ThrowIfNull(valueField);
            }
            catch (ArgumentNullException e)
            {
                throw InvalidOperationExceptionFactory.InvalidState<HorizonsQueryURI>(e);
            }

            return valueField!;
        }
        init
        {
            ArgumentNullException.ThrowIfNull(value);

            valueField = value;
        }
    }

    /// <inheritdoc cref="HorizonsQueryURI"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    [SetsRequiredMembers]
    public HorizonsQueryURI(Uri value)
    {
        Value = value;
    }

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Uri"/> represented by the <see cref="HorizonsQueryURI"/>.</summary>
    /// <exception cref="InvalidOperationException"/>
    public override string ToString() => Value.ToString();

    /// <summary>Backing field for <see cref="Value"/>. Should not be used elsewhere.</summary>
    private readonly Uri? valueField;

    /// <inheritdoc cref="HorizonsQueryURI(Uri)"/>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator HorizonsQueryURI(Uri value) => new(value);

    /// <summary>Retrieves the <see cref="Value"/> represented by <paramref name="uri"/>.</summary>
    /// <param name="uri"><inheritdoc cref="HorizonsQueryURI" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    public static explicit operator Uri(HorizonsQueryURI uri)
    {
        try
        {
            return uri.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<HorizonsQueryURI>(nameof(uri), e);
        }
    }

    /// <summary>Validates the <see cref="HorizonsQueryURI"/> <paramref name="queryURI"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="queryURI">This <see cref="HorizonsQueryURI"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="queryURI"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(HorizonsQueryURI queryURI, [CallerArgumentExpression(nameof(queryURI))] string? argumentExpression = null)
    {
        try
        {
            _ = queryURI.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<HorizonsQueryURI>(argumentExpression, e);
        }
    }
}

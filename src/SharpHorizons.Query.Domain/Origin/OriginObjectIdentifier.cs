namespace SharpHorizons.Query.Origin;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>An identifier describing an <see cref="IOriginObject"/>.</summary>
public readonly record struct OriginObjectIdentifier
{
    /// <summary>The identifier describing the <see cref="IOriginObject"/>.</summary>
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
                throw InvalidOperationExceptionFactory.InvalidState<OriginObjectIdentifier>(e);
            }

            return valueField;
        }
        init
        {
            ArgumentExceptionUtility.ThrowIfNullOrWhiteSpace(value);

            valueField = value;
        }
    }

    /// <inheritdoc cref="OriginObjectIdentifier"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    [SetsRequiredMembers]
    public OriginObjectIdentifier(string value)
    {
        Value = value;
    }

    /// <summary>Retrieves the <see cref="Value"/> represented by the <see cref="OriginObjectIdentifier"/>.</summary>
    /// <exception cref="InvalidOperationException"/>
    public override string ToString() => Value;

    /// <summary>Backing field for <see cref="Value"/>. Should not be used elsewhere.</summary>
    private readonly string? valueField;

    /// <inheritdoc cref="OriginObjectIdentifier(string)"/>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator OriginObjectIdentifier(string value) => new(value);

    /// <summary>Retrieves the <see cref="Value"/> represented by <paramref name="originObject"/>.</summary>
    /// <param name="originObject"><inheritdoc cref="OriginObjectIdentifier" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    public static explicit operator string(OriginObjectIdentifier originObject)
    {
        try
        {
            return originObject.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<OriginObjectIdentifier>(nameof(originObject), e);
        }
    }

    /// <summary>Validates the <see cref="OriginObjectIdentifier"/> <paramref name="identifier"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="identifier">This <see cref="OriginObjectIdentifier"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="identifier"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(OriginObjectIdentifier identifier, [CallerArgumentExpression(nameof(identifier))] string? argumentExpression = null)
    {
        try
        {
            _ = identifier.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<OriginObjectIdentifier>(argumentExpression, e);
        }
    }
}

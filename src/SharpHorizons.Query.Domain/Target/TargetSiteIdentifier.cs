namespace SharpHorizons.Query.Target;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>An identifier describing a <see cref="ITargetSite"/>.</summary>
public readonly record struct TargetSiteIdentifier
{
    /// <summary>The identifier describing the <see cref="ITargetSite"/>.</summary>
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
                throw InvalidOperationExceptionFactory.InvalidState<TargetSiteIdentifier>(e);
            }

            return valueField;
        }
        init
        {
            ArgumentExceptionUtility.ThrowIfNullOrWhiteSpace(value);

            valueField = value;
        }
    }

    /// <inheritdoc cref="TargetSiteIdentifier"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    [SetsRequiredMembers]
    public TargetSiteIdentifier(string value)
    {
        Value = value;
    }

    /// <summary>Retrieves the <see cref="string"/> <see cref="Value"/> represented by the <see cref="TargetSiteIdentifier"/>.</summary>
    /// <exception cref="InvalidOperationException"/>
    public override string ToString() => Value;

    /// <summary>Backing field for <see cref="Value"/>. Should not be used elsewhere.</summary>
    private readonly string? valueField;

    /// <summary>Constructs a <see cref="TargetSiteIdentifier"/> representing the <see cref="string"/> <paramref name="value"/>.</summary>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public static TargetSiteIdentifier FromString(string value) => new(value);

    /// <inheritdoc cref="TargetSiteIdentifier(string)"/>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator TargetSiteIdentifier(string value) => FromString(value);

    /// <summary>Retrieves the <see cref="string"/> <see cref="Value"/> represented by <paramref name="targetSite"/>.</summary>
    /// <param name="targetSite"><inheritdoc cref="TargetSiteIdentifier" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    public static explicit operator string(TargetSiteIdentifier targetSite)
    {
        try
        {
            return targetSite.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<TargetSiteIdentifier>(nameof(targetSite), e);
        }
    }

    /// <summary>Validates the <see cref="TargetSiteIdentifier"/> <paramref name="identifier"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="identifier">This <see cref="TargetSiteIdentifier"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="identifier"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(TargetSiteIdentifier identifier, [CallerArgumentExpression(nameof(identifier))] string? argumentExpression = null)
    {
        try
        {
            _ = identifier.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<TargetSiteIdentifier>(argumentExpression, e);
        }
    }
}

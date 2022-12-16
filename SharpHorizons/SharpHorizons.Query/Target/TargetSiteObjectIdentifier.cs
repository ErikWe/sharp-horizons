namespace SharpHorizons.Query.Target;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>An identifier describing an <see cref="ITargetSiteObject"/>.</summary>
public readonly record struct TargetSiteObjectIdentifier
{
    /// <summary>The identifier describing the <see cref="ITargetSiteObject"/>.</summary>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    public required string Value
    {
        get
        {
            try
            {
                ArgumentException.ThrowIfNullOrEmpty(valueField);
            }
            catch (ArgumentException e)
            {
                throw InvalidOperationExceptionFactory.InvalidState<TargetSiteObjectIdentifier>(e);
            }

            return valueField;
        }
        init
        {
            ArgumentException.ThrowIfNullOrEmpty(value);

            valueField = value;
        }
    }

    /// <inheritdoc cref="TargetSiteObjectIdentifier"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    [SetsRequiredMembers]
    public TargetSiteObjectIdentifier(string value)
    {
        Value = value;
    }

    /// <summary>Retrieves the <see cref="Value"/> represented by the <see cref="TargetSiteObjectIdentifier"/>.</summary>
    /// <exception cref="InvalidOperationException"/>
    public override string ToString() => Value;

    /// <summary>Backing field for <see cref="Value"/>. Should not be used elsewhere.</summary>
    private readonly string? valueField;

    /// <inheritdoc cref="TargetSiteObjectIdentifier(string)"/>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator TargetSiteObjectIdentifier(string value) => new(value);

    /// <summary>Retrieves the <see cref="Value"/> represented by <paramref name="targetSite"/>.</summary>
    /// <param name="targetSite"><inheritdoc cref="TargetSiteObjectIdentifier" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    public static explicit operator string(TargetSiteObjectIdentifier targetSite)
    {
        try
        {
            return targetSite.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<TargetSiteObjectIdentifier>(nameof(targetSite), e);
        }
    }

    /// <summary>Validates the <see cref="TargetSiteObjectIdentifier"/> <paramref name="identifier"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="identifier">This <see cref="TargetSiteObjectIdentifier"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="identifier"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(TargetSiteObjectIdentifier identifier, [CallerArgumentExpression(nameof(identifier))] string? argumentExpression = null)
    {
        try
        {
            _ = identifier.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<TargetSiteObjectIdentifier>(argumentExpression, e);
        }
    }
}

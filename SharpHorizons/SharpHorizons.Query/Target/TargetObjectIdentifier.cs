namespace SharpHorizons.Query.Target;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>An identifier describing an <see cref="ITargetObject"/>.</summary>
public readonly record struct TargetObjectIdentifier
{
    /// <summary>The identifier describing the <see cref="ITargetObject"/>.</summary>
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
                throw InvalidOperationExceptionFactory.InvalidState<TargetObjectIdentifier>(e);
            }

            return valueField;
        }
        init
        {
            ArgumentExceptionUtility.ThrowIfNullOrWhiteSpace(value);

            valueField = value;
        }
    }

    /// <inheritdoc cref="TargetObjectIdentifier"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    [SetsRequiredMembers]
    public TargetObjectIdentifier(string value)
    {
        Value = value;
    }

    /// <summary>Retrieves the <see cref="Value"/> represented by the <see cref="TargetObjectIdentifier"/>.</summary>
    /// <exception cref="InvalidOperationException"/>
    public override string ToString() => Value;

    /// <summary>Backing field for <see cref="Value"/>. Should not be used elsewhere.</summary>
    private readonly string? valueField;

    /// <inheritdoc cref="TargetObjectIdentifier(string)"/>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator TargetObjectIdentifier(string value) => new(value);

    /// <summary>Retrieves the <see cref="Value"/> represented by <paramref name="targetSite"/>.</summary>
    /// <param name="targetSite"><inheritdoc cref="TargetObjectIdentifier" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    public static explicit operator string(TargetObjectIdentifier targetSite)
    {
        try
        {
            return targetSite.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<TargetObjectIdentifier>(nameof(targetSite), e);
        }
    }

    /// <summary>Validates the <see cref="TargetObjectIdentifier"/> <paramref name="identifier"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="identifier">This <see cref="TargetObjectIdentifier"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="identifier"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(TargetObjectIdentifier identifier, [CallerArgumentExpression(nameof(identifier))] string? argumentExpression = null)
    {
        try
        {
            _ = identifier.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<TargetObjectIdentifier>(argumentExpression, e);
        }
    }
}

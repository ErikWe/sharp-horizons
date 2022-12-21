namespace SharpHorizons.MPC;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Represents the name of an <see cref="MPCComet"/>.</summary>
public readonly record struct MPCCometName
{
    /// <summary>The <see cref="string"/> name of the <see cref="MPCComet"/>.</summary>
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
                throw InvalidOperationExceptionFactory.InvalidState<MPCCometName>(e);
            }

            return valueField;
        }
        init
        {
            ArgumentExceptionUtility.ThrowIfNullOrWhiteSpace(value);

            valueField = value;
        }
    }

    /// <inheritdoc cref="MPCCometName"/>
    public MPCCometName() { }

    /// <inheritdoc cref="MPCCometName"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    [SetsRequiredMembers]
    public MPCCometName(string value)
    {
        Value = value;
    }

    /// <summary>Retrieves the <see cref="Value"/> represented by the <see cref="MPCCometName"/>.</summary>
    /// <exception cref="InvalidOperationException"/>
    public override string ToString() => Value;

    /// <summary>Backing field for <see cref="Value"/>. Should not be used elsewhere.</summary>
    private readonly string? valueField;

    /// <inheritdoc cref="MPCCometName"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator MPCCometName(string value) => new(value);

    /// <summary>Retrieves the <see cref="Value"/> represented by <paramref name="name"/>.</summary>
    /// <param name="name"><inheritdoc cref="MPCCometName" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    public static explicit operator string(MPCCometName name)
    {
        try
        {
            return name.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<MPCCometName>(nameof(name), e);
        }
    }

    /// <summary>Validates the <see cref="MPCCometName"/> <paramref name="name"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="name">This <see cref="MPCCometName"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="name"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(MPCCometName name, [CallerArgumentExpression(nameof(name))] string? argumentExpression = null)
    {
        try
        {
            _ = name.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<MPCCometName>(argumentExpression, e);
        }
    }
}

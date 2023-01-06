namespace SharpHorizons.MPC;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Represents the name of an <see cref="MPCObject"/>.</summary>
public readonly record struct MPCName
{
    /// <summary>The <see cref="string"/> name of the <see cref="MPCObject"/>.</summary>
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
                throw InvalidOperationExceptionFactory.InvalidState<MPCName>(e);
            }

            return valueField;
        }
        init
        {
            ArgumentExceptionUtility.ThrowIfNullOrWhiteSpace(value);

            valueField = value;
        }
    }

    /// <inheritdoc cref="MPCName"/>
    public MPCName() { }

    /// <inheritdoc cref="MPCName"/>
    /// <param name="valie"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    [SetsRequiredMembers]
    public MPCName(string valie)
    {
        Value = valie;
    }

    /// <summary>Retrieves the <see cref="Value"/> represented by the <see cref="MPCName"/>.</summary>
    /// <exception cref="InvalidOperationException"/>
    public override string ToString() => Value;

    /// <summary>Backing field for <see cref="Value"/>. Should not be used elsewhere.</summary>
    private readonly string? valueField;

    /// <inheritdoc cref="MPCName"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator MPCName(string value) => new(value);

    /// <summary>Retrieves the <see cref="Value"/> represented by <paramref name="name"/>.</summary>
    /// <param name="name"><inheritdoc cref="MPCName" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    public static explicit operator string(MPCName name)
    {
        try
        {
            return name.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<MPCName>(nameof(name), e);
        }
    }

    /// <summary>Validates the <see cref="MPCName"/> <paramref name="name"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="name">This <see cref="MPCName"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="name"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(MPCName name, [CallerArgumentExpression(nameof(name))] string? argumentExpression = null)
    {
        try
        {
            _ = name.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<MPCName>(argumentExpression, e);
        }
    }
}

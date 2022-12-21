namespace SharpHorizons.MPC;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Represents the designation of an <see cref="MPCComet"/>.</summary>
public readonly record struct MPCCometDesignation
{
    /// <summary>The <see cref="string"/> designation of the <see cref="MPCComet"/>.</summary>
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
                throw InvalidOperationExceptionFactory.InvalidState<MPCCometDesignation>(e);
            }

            return valueField;
        }
        init
        {
            ArgumentExceptionUtility.ThrowIfNullOrWhiteSpace(value);

            valueField = value;
        }
    }

    /// <inheritdoc cref="MPCCometDesignation"/>
    public MPCCometDesignation() { }

    /// <inheritdoc cref="MPCCometDesignation"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    [SetsRequiredMembers]
    public MPCCometDesignation(string value)
    {
        Value = value;
    }

    /// <summary>Retrieves the <see cref="Value"/> represented by the <see cref="MPCCometDesignation"/>.</summary>
    /// <exception cref="InvalidOperationException"/>
    public override string ToString() => Value;

    /// <summary>Backing field for <see cref="Value"/>. Should not be used elsewhere.</summary>
    private readonly string? valueField;

    /// <inheritdoc cref="MPCCometDesignation"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator MPCCometDesignation(string value) => new(value);

    /// <summary>Retrieves the <see cref="Value"/> represented by <paramref name="designation"/>.</summary>
    /// <param name="designation"><inheritdoc cref="MPCCometDesignation" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    public static explicit operator string(MPCCometDesignation designation)
    {
        try
        {
            return designation.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<MPCCometDesignation>(nameof(designation), e);
        }
    }

    /// <summary>Validates the <see cref="MPCCometDesignation"/> <paramref name="designation"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="designation">This <see cref="MPCCometDesignation"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="designation"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(MPCCometDesignation designation, [CallerArgumentExpression(nameof(designation))] string? argumentExpression = null)
    {
        try
        {
            _ = designation.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<MPCCometDesignation>(argumentExpression, e);
        }
    }
}

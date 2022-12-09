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
            Validate();

            return valueField!;
        }
        init
        {
            Validate(value);

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
        Validate(designation);

        return designation.valueField!;
    }

    /// <summary>Validates that <paramref name="value"/> can be used to represent the designation of an <see cref="MPCComet"/>, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="value"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void Validate(string? value, [CallerArgumentExpression(nameof(value))] string? argumentExpression = null) => ArgumentException.ThrowIfNullOrEmpty(value, argumentExpression);

    /// <summary>Validates the <see cref="MPCCometDesignation"/> <paramref name="designation"/>, and throws an <see cref="Exception"/> of type <typeparamref name="TException"/> if invalid.</summary>
    /// <typeparam name="TException">The type of the <see cref="Exception"/> that is thrown if <paramref name="designation"/> is invalid.</typeparam>
    /// <param name="designation">This <see cref="MPCCometDesignation"/> is validated.</param>
    /// <param name="exceptionInstantiation">Handles construction of <typeparamref name="TException"/>.</param>
    private static void Validate<TException>(MPCCometDesignation designation, ExceptionInstantiation<TException> exceptionInstantiation) where TException : Exception
    {
        try
        {
            Validate(designation.valueField);
        }
        catch (ArgumentException e)
        {
            throw exceptionInstantiation(e);
        }
    }

    /// <summary>Validates the <see cref="MPCCometDesignation"/>, and throws an <see cref="InvalidOperationException"/> if invalid.</summary>
    /// <exception cref="InvalidOperationException"/>
    private void Validate() => Validate(this, InvalidOperationExceptionFactory.InvalidState<MPCCometDesignation>);

    /// <summary>Validates the <see cref="MPCCometDesignation"/> <paramref name="designation"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="designation">This <see cref="MPCCometDesignation"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="designation"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(MPCCometDesignation designation, [CallerArgumentExpression(nameof(designation))] string? argumentExpression = null) => Validate(designation, ArgumentExceptionFactory.InvalidStateDelegate<MPCCometDesignation>(argumentExpression));
}

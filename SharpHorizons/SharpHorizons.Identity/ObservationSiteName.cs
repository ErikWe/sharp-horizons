namespace SharpHorizons;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Represents the name of a <see cref="ObservationSite"/>.</summary>
public readonly record struct ObservationSiteName
{
    /// <summary>The <see cref="string"/> name of the <see cref="ObservationSite"/>.</summary>
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

    /// <inheritdoc cref="ObservationSiteName"/>
    public ObservationSiteName() { }

    /// <inheritdoc cref="ObservationSiteName"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    [SetsRequiredMembers]
    public ObservationSiteName(string value)
    {
        Value = value;
    }

    /// <summary>Retrieves the <see cref="Value"/> represented by the <see cref="ObservationSiteName"/>.</summary>
    /// <exception cref="InvalidOperationException"/>
    public override string ToString() => Value;

    /// <summary>Backing field for <see cref="Value"/>. Should not be used elsewhere.</summary>
    private readonly string? valueField;

    /// <inheritdoc cref="ObservationSiteName"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator ObservationSiteName(string value) => new(value);

    /// <summary>Retrieves the <see cref="Value"/> represented by <paramref name="observationSiteName"/>.</summary>
    /// <param name="observationSiteName"><inheritdoc cref="ObservationSiteName" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    public static explicit operator string(ObservationSiteName observationSiteName)
    {
        Validate(observationSiteName);

        return observationSiteName.valueField!;
    }

    /// <summary>Validates that <paramref name="value"/> can be used to represent the name of an <see cref="ObservationSite"/>, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="value"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void Validate(string? value, [CallerArgumentExpression(nameof(value))] string? argumentExpression = null) => ArgumentException.ThrowIfNullOrEmpty(value, argumentExpression);

    /// <summary>Validates the <see cref="ObservationSiteName"/> <paramref name="name"/>, and throws an <see cref="Exception"/> of type <typeparamref name="TException"/> if invalid.</summary>
    /// <typeparam name="TException">The type of the <see cref="Exception"/> that is thrown if <paramref name="name"/> is invalid.</typeparam>
    /// <param name="name">This <see cref="ObservationSiteName"/> is validated.</param>
    /// <param name="exceptionInstantiation">Handles construction of <typeparamref name="TException"/>.</param>
    private static void Validate<TException>(ObservationSiteName name, ExceptionInstantiation<TException> exceptionInstantiation) where TException : Exception
    {
        try
        {
            Validate(name.valueField);
        }
        catch (ArgumentException e)
        {
            throw exceptionInstantiation(e);
        }
    }

    /// <summary>Validates the <see cref="ObservationSiteName"/>, and throws an <see cref="InvalidOperationException"/> if invalid.</summary>
    /// <exception cref="InvalidOperationException"/>
    private void Validate() => Validate(this, InvalidOperationExceptionFactory.InvalidState<ObservationSiteName>);

    /// <summary>Validates the <see cref="ObservationSiteName"/> <paramref name="name"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="name">This <see cref="ObservationSiteName"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="name"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(ObservationSiteName name, [CallerArgumentExpression(nameof(name))] string? argumentExpression = null) => Validate(name, ArgumentExceptionFactory.InvalidStateDelegate<ObservationSiteName>(argumentExpression));
}

namespace SharpHorizons;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;

/// <summary>Represents the <see cref="string"/> ID of a <see cref="ObservationSite"/>.</summary>
public readonly record struct ObservationSiteID
{
    /// <summary>The <see cref="string"/> ID of the <see cref="ObservationSite"/>.</summary>
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

    /// <inheritdoc cref="ObservationSiteID"/>
    public ObservationSiteID() { }

    /// <inheritdoc cref="ObservationSiteID"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    [SetsRequiredMembers]
    public ObservationSiteID(string value)
    {
        Value = value;
    }

    /// <inheritdoc cref="ObservationSiteID"/>
    /// <param name="value">The <see cref="int"/> ID of the <see cref="ObservationSite"/>. This <see cref="int"/> is formatted as a <see cref="string"/> using the <see cref="CultureInfo.InvariantCulture"/>.</param>
    [SetsRequiredMembers]
    public ObservationSiteID(int value) : this(value.ToString(CultureInfo.InvariantCulture)) { }

    /// <summary>Retrieves the <see cref="Value"/> represented by the <see cref="ObservationSiteID"/>.</summary>
    /// <exception cref="InvalidOperationException"/>
    public override string ToString() => Value;

    /// <summary>Backing field for <see cref="Value"/>. Should not be used elsewhere.</summary>
    private readonly string? valueField;

    /// <inheritdoc cref="ObservationSiteID"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public static explicit operator ObservationSiteID(string value) => new(value);

    /// <inheritdoc cref="ObservationSiteID"/>
    /// <param name="value">The <see cref="int"/> ID of the <see cref="ObservationSite"/>. This <see cref="int"/> is formatted as a <see cref="string"/> using the <see cref="CultureInfo.InvariantCulture"/>.</param>
    public static explicit operator ObservationSiteID(int value) => new(value);

    /// <summary>Retrieves the <see cref="Value"/> represented by <paramref name="observationSiteID"/>.</summary>
    /// <param name="observationSiteID"><inheritdoc cref="ObservationSiteID" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    public static explicit operator string(ObservationSiteID observationSiteID)
    {
        Validate(observationSiteID);

        return observationSiteID.valueField!;
    }

    /// <summary>Validates that <paramref name="value"/> can be used to represent the id of an <see cref="ObservationSite"/>, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="value"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void Validate(string? value, [CallerArgumentExpression(nameof(value))] string? argumentExpression = null) => ArgumentException.ThrowIfNullOrEmpty(value, argumentExpression);

    /// <summary>Validates the <see cref="ObservationSiteID"/> <paramref name="id"/>, and throws an <see cref="Exception"/> of type <typeparamref name="TException"/> if invalid.</summary>
    /// <typeparam name="TException">The type of the <see cref="Exception"/> that is thrown if <paramref name="id"/> is invalid.</typeparam>
    /// <param name="id">This <see cref="ObservationSiteID"/> is validated.</param>
    /// <param name="exceptionInstantiation">Handles construction of <typeparamref name="TException"/>.</param>
    private static void Validate<TException>(ObservationSiteID id, ExceptionInstantiation<TException> exceptionInstantiation) where TException : Exception
    {
        try
        {
            Validate(id.valueField);
        }
        catch (ArgumentException e)
        {
            throw exceptionInstantiation(e);
        }
    }

    /// <summary>Validates the <see cref="ObservationSiteID"/>, and throws an <see cref="InvalidOperationException"/> if invalid.</summary>
    /// <exception cref="InvalidOperationException"/>
    private void Validate() => Validate(this, InvalidOperationExceptionFactory.InvalidState<ObservationSiteID>);

    /// <summary>Validates the <see cref="ObservationSiteID"/> <paramref name="id"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="id">This <see cref="ObservationSiteID"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="id"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(ObservationSiteID id, [CallerArgumentExpression(nameof(id))] string? argumentExpression = null) => Validate(id, ArgumentExceptionFactory.InvalidStateDelegate<ObservationSiteID>(argumentExpression));
}

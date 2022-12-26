﻿namespace SharpHorizons;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;

/// <summary>Represents the <see cref="string"/> ID of an <see cref="ObservationSite"/>.</summary>
/// <remarks>An <see cref="ObservationSiteID"/> represents a value in the range [-99, 999], or a single alphabetical letter followed by a value in the range [0, 99].</remarks>
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
            try
            {
                ArgumentNullException.ThrowIfNull(valueField);
            }
            catch (ArgumentNullException e)
            {
                throw InvalidOperationExceptionFactory.InvalidState<ObservationSiteID>(e);
            }

            return valueField;
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
    /// <param name="value">The <see cref="int"/> ID of the <see cref="ObservationSite"/>. The <see cref="string"/> ID of the <see cref="ObservationSite"/> is this <see cref="int"/> formatted using the <see cref="CultureInfo.InvariantCulture"/>.</param>
    /// <exception cref="ArgumentOutOfRangeException"/>
    [SetsRequiredMembers]
    public ObservationSiteID(int value)
    {
        Validate(value);

        Value = value.ToString(CultureInfo.InvariantCulture);
    }

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
        try
        {
            return observationSiteID.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<ObservationSiteID>(nameof(observationSiteID), e);
        }
    }

    /// <summary>Validates that the <see cref="string"/>-representation of <paramref name="value"/> can be used to represent the <see cref="Value"/> of an <see cref="ObservationSite"/>, and throws an <see cref="ArgumentOutOfRangeException"/> otherwise.</summary>
    /// <param name="value">The <see cref="int"/> ID of the <see cref="ObservationSite"/>. The <see cref="string"/> ID of the <see cref="ObservationSite"/> is this <see cref="int"/> formatted using the <see cref="CultureInfo.InvariantCulture"/>.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="value"/>.</param>
    /// <exception cref="ArgumentOutOfRangeException"/>
    private static void Validate(int value, [CallerArgumentExpression(nameof(value))] string? argumentExpression = null)
    {
        if (value is < -99 or > 999)
        {
            throw new ArgumentOutOfRangeException(argumentExpression, value, ExceptionMessage(value));
        }
    }

    /// <summary>Validates that <paramref name="value"/> can be used to represent the <see cref="Value"/> of an <see cref="ObservationSite"/>, and throws an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="value"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void Validate([NotNull] string? value, [CallerArgumentExpression(nameof(value))] string? argumentExpression = null)
    {
        ArgumentExceptionUtility.ThrowIfNullOrWhiteSpace(value, argumentExpression);

        if (value.Length > 3)
        {
            throw new ArgumentException(ExceptionMessage(value), argumentExpression);
        }

        if (int.TryParse(value, out _))
        {
            return;
        }

        if (value[0] is (>= 'A' and <= 'Z') or (>= 'a' and <= 'z') && int.TryParse(value[1..], out _))
        {
            return;
        }

        throw new ArgumentException(ExceptionMessage(value), argumentExpression);
    }

    /// <summary>Constructs the <see cref="string"/> message of the <see cref="ArgumentOutOfRangeException"/> caused by an invalid argument <paramref name="value"/>.</summary>
    /// <param name="value">The value of the invalid argument.</param>
    private static string ExceptionMessage(int value) => $"A value in the range [-99, 999] should be used to describe the {nameof(Value)} of an {nameof(ObservationSiteID)}.";

    /// <summary>Constructs the <see cref="string"/> message of the <see cref="ArgumentException"/> caused by an invalid argument <paramref name="value"/>.</summary>
    /// <param name="value">The value of the invalid argument.</param>
    private static string ExceptionMessage(string value) => $"A value in the range [-99, 999], or a single alphabetical letter followed by a value in the range [0, 99], should be used to describe the {nameof(Value)} of an {nameof(ObservationSiteID)}.";

    /// <summary>Validates the <see cref="ObservationSiteID"/> <paramref name="id"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="id">This <see cref="ObservationSiteID"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="id"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(ObservationSiteID id, [CallerArgumentExpression(nameof(id))] string? argumentExpression = null)
    {
        try
        {
            _ = id.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<ObservationSiteID>(argumentExpression, e);
        }
    }
}

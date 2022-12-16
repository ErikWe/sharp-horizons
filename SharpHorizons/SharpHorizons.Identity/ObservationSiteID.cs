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
            try
            {
                ArgumentException.ThrowIfNullOrEmpty(valueField);
            }
            catch (ArgumentException e)
            {
                throw InvalidOperationExceptionFactory.InvalidState<ObservationSiteID>(e);
            }

            return valueField;
        }
        init
        {
            ArgumentException.ThrowIfNullOrEmpty(value);

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
        try
        {
            return observationSiteID.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<ObservationSiteID>(nameof(observationSiteID), e);
        }
    }

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

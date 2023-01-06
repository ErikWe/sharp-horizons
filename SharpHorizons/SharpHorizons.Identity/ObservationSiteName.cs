namespace SharpHorizons;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Represents the <see cref="string"/> name of an <see cref="ObservationSite"/>.</summary>
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
            try
            {
                ArgumentExceptionUtility.ThrowIfNullOrWhiteSpace(valueField);
            }
            catch (ArgumentException e)
            {
                throw InvalidOperationExceptionFactory.InvalidState<ObservationSiteName>(e);
            }

            return valueField;
        }
        init
        {
            ArgumentExceptionUtility.ThrowIfNullOrWhiteSpace(value);

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
        try
        {
            return observationSiteName.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<ObservationSiteName>(nameof(observationSiteName), e);
        }
    }

    /// <summary>Validates the <see cref="ObservationSiteName"/> <paramref name="name"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="name">This <see cref="ObservationSiteName"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="name"/>.</param>
    /// <exception cref="ArgumentException"/>
    public static void Validate(ObservationSiteName name, [CallerArgumentExpression(nameof(name))] string? argumentExpression = null)
    {
        try
        {
            _ = name.Value;
        }
        catch (InvalidOperationException e)
        {
            throw ArgumentExceptionFactory.InvalidState<ObservationSiteName>(argumentExpression, e);
        }
    }
}

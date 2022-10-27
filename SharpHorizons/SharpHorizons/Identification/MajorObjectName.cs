namespace SharpHorizons.Identification;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

/// <summary>Represents the name of an object marked as a <see cref="HorizonsBodyType.Major"/> body in Horizons - typically a planet, a moon of a planet, a spacecraft, or a few other special cases.</summary>
public readonly record struct MajorObjectName
{
    /// <summary>The name of the object in Horizons.</summary>
    public string Value { get; }

    /// <summary>Represents the name { <paramref name="value"/> } of an object marked as a <see cref="HorizonsBodyType.Major"/> body in Horizons.</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    public MajorObjectName(string value)
    {
        Value = value;
    }

    /// <summary>Retrieves a <see cref="string"/>-representation of the name represented by <see langword="this"/>.</summary>
    public override string ToString() => Value.ToString(CultureInfo.CurrentCulture);
    /// <summary>Retrieves a <see cref="string"/>-representation of the name represented by <see langword="this"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(IFormatProvider? provider) => Value.ToString(provider);

    /// <inheritdoc cref="MajorObjectName"/>
    [SuppressMessage("Usage", "CA2225", Justification = "Available through a constructor")]
    public static implicit operator MajorObjectName(string value) => new(value);

    /// <summary>Retrieves the ID represented by <paramref name="majorBodyName"/>.</summary>
    /// <param name="majorBodyName"><inheritdoc cref="MajorObjectName" path="/summary"/></param>
    public static implicit operator string(MajorObjectName majorBodyName) => majorBodyName;
}
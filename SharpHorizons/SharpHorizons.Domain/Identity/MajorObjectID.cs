namespace SharpHorizons.Identity;

using System;
using System.Globalization;

/// <summary>Represents the ID of an object classified as a <see cref="HorizonsObjectClass.Major"/> object in Horizons - typically a planet, a moon, or a spacecraft.</summary>
public readonly record struct MajorObjectID
{
    /// <summary>The ID of the object in Horizons.</summary>
    public int Value { get; }

    /// <summary>Represents the ID { <paramref name="value"/> } of an object classified as a <see cref="HorizonsObjectClass.Major"/> object in Horizons - typically a planet, a moon, or a spacecraft.</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    public MajorObjectID(int value)
    {
        Value = value;
    }

    /// <summary>Retrieves a <see cref="string"/>-representation of the ID represented by <see langword="this"/>.</summary>
    public override string ToString() => Value.ToString(CultureInfo.CurrentCulture);
    /// <summary>Retrieves a <see cref="string"/>-representation of the ID represented by <see langword="this"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(IFormatProvider? provider) => Value.ToString(provider);
    /// <summary>Retrieves a <see cref="string"/>-representation of the ID represented by <see langword="this"/>, formatted according to <paramref name="format"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    public string ToString(string? format) => Value.ToString(format, CultureInfo.CurrentCulture);
    /// <summary>Retrieves a <see cref="string"/>-representation of the ID represented by <see langword="this"/>, formatted according to <paramref name="format"/> and <paramref name="provider"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(string format, IFormatProvider? provider) => Value.ToString(format, provider);

    /// <inheritdoc cref="MajorObjectID(int)"/>
    public static implicit operator MajorObjectID(int value) => new(value);

    /// <summary>Retrieves the ID represented by <paramref name="majorBodyID"/>.</summary>
    /// <param name="majorBodyID"><inheritdoc cref="MajorObjectID" path="/summary"/></param>
    public static implicit operator int(MajorObjectID majorBodyID) => majorBodyID.Value;
}
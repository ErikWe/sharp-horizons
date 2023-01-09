namespace SharpHorizons;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

/// <summary>Represents the <see cref="int"/> ID of a <see cref="MajorObject"/>.</summary>
public readonly record struct MajorObjectID
{
    /// <summary>The <see cref="int"/> ID of the <see cref="MajorObject"/>.</summary>
    public required int Value { get; init; }

    /// <inheritdoc cref="MajorObjectID"/>
    public MajorObjectID() { }

    /// <inheritdoc cref="MajorObjectID"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    [SetsRequiredMembers]
    public MajorObjectID(int value)
    {
        Value = value;
    }

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Value"/> represented by the <see cref="MajorObjectID"/>, formatted according to the <see cref="CultureInfo.CurrentCulture"/>.</summary>
    public override string ToString() => Value.ToString(CultureInfo.CurrentCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Value"/> represented by the <see cref="MajorObjectID"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(IFormatProvider? provider) => Value.ToString(provider);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Value"/> represented by the <see cref="MajorObjectID"/>, formatted according to <paramref name="format"/> and the <see cref="CultureInfo.CurrentCulture"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    public string ToString(string? format) => Value.ToString(format, CultureInfo.CurrentCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Value"/> represented by the <see cref="MajorObjectID"/>, formatted according to <paramref name="format"/> and <paramref name="provider"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(string? format, IFormatProvider? provider) => Value.ToString(format, provider);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Value"/> represented by the <see cref="MajorObjectID"/>, formatted according to the <see cref="CultureInfo.InvariantCulture"/>.</summary>
    public string ToStringInvariant() => Value.ToString(CultureInfo.InvariantCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="Value"/> represented by the <see cref="MajorObjectID"/>, formatted according to <paramref name="format"/> and the <see cref="CultureInfo.InvariantCulture"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    public string ToStringInvariant(string? format) => Value.ToString(format, CultureInfo.InvariantCulture);

    /// <summary>Retrieves the <see cref="int"/> <see cref="Value"/> represented by the <see cref="MajorObjectID"/>.</summary>
    public int ToInt32() => Value;

    /// <summary>Constructs a <see cref="MajorObjectID"/>, representing the <see cref="int"/> <paramref name="value"/>.</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    public static MajorObjectID FromInt32(int value) => new(value);

    /// <inheritdoc cref="MajorObjectID"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    public static explicit operator MajorObjectID(int value) => FromInt32(value);

    /// <summary>Retrieves the <see cref="int"/> <see cref="Value"/> represented by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID"><inheritdoc cref="MajorObjectID" path="/summary"/></param>
    public static implicit operator int(MajorObjectID majorObjectID) => majorObjectID.Value;
}

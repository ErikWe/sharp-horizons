namespace SharpHorizons;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

/// <summary>Represents the ID of a <see cref="MajorObject"/>.</summary>
public readonly record struct MajorObjectID
{
    /// <summary>The <see cref="int"/> ID of the <see cref="MajorObject"/>.</summary>
    public required int ID { get; init; }

    /// <inheritdoc cref="MajorObjectID"/>
    public MajorObjectID() { }

    /// <inheritdoc cref="MajorObjectID"/>
    /// <param name="id"><inheritdoc cref="ID" path="/summary"/></param>
    [SetsRequiredMembers]
    public MajorObjectID(int id)
    {
        ID = id;
    }

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="ID"/> represented by the <see cref="MajorObjectID"/>, formatted according to the <see cref="CultureInfo.CurrentCulture"/>.</summary>
    public override string ToString() => ID.ToString(CultureInfo.CurrentCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="ID"/> represented by the <see cref="MajorObjectID"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(IFormatProvider? provider) => ID.ToString(provider);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="ID"/> represented by the <see cref="MajorObjectID"/>, formatted according to <paramref name="format"/> and the <see cref="CultureInfo.CurrentCulture"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    public string ToString(string? format) => ID.ToString(format, CultureInfo.CurrentCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="ID"/> represented by the <see cref="MajorObjectID"/>, formatted according to <paramref name="format"/> and <paramref name="provider"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(string? format, IFormatProvider? provider) => ID.ToString(format, provider);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="ID"/> represented by the <see cref="MajorObjectID"/>, formatted according to the <see cref="CultureInfo.InvariantCulture"/>.</summary>
    public string ToStringInvariant() => ID.ToString(CultureInfo.InvariantCulture);

    /// <summary>Retrieves a <see cref="string"/>-representation of the <see cref="ID"/> represented by the <see cref="MajorObjectID"/>, formatted according to <paramref name="format"/> and the <see cref="CultureInfo.InvariantCulture"/>.</summary>
    /// <param name="format">Provides formatting information.</param>
    public string ToStringInvariant(string? format) => ID.ToString(format, CultureInfo.InvariantCulture);

    /// <inheritdoc cref="MajorObjectID"/>
    /// <param name="id"><inheritdoc cref="ID" path="/summary"/></param>
    public static explicit operator MajorObjectID(int id) => new(id);

    /// <summary>Retrieves the <see cref="ID"/> represented by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID"><inheritdoc cref="MajorObjectID" path="/summary"/></param>
    public static implicit operator int(MajorObjectID majorObjectID) => majorObjectID.ID;
}
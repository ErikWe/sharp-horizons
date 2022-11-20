namespace SharpHorizons.Identity;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

/// <summary>Represents the <see cref="string"/> ID of a pre-defined observation site in Horizons.</summary>
public readonly record struct ObservationSiteID
{
    /// <summary>The ID of the observation site in Horizons.</summary>
    public required string ID { get; init; }

    /// <inheritdoc cref="ObservationSiteID"/>
    public ObservationSiteID() { }

    /// <inheritdoc cref="ObservationSiteID"/>
    /// <param name="id"><inheritdoc cref="ID" path="/summary"/></param>
    [SetsRequiredMembers]
    public ObservationSiteID(string id)
    {
        ID = id;
    }

    /// <inheritdoc cref="ObservationSiteID"/>
    /// <param name="id">The <see cref="int"/> ID of the observation site in Horizons. This ID is formatted as a <see cref="string"/>.</param>
    [SetsRequiredMembers]
    public ObservationSiteID(int id)
    {
        ID = id.ToString(CultureInfo.InvariantCulture);
    }

    /// <summary>Retrieves the ID represented by <see langword="this"/>.</summary>
    public override string ToString() => ID.ToString(CultureInfo.CurrentCulture);

    /// <summary>Retrieves the ID represented by <see langword="this"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(IFormatProvider? provider) => ID.ToString(provider);

    /// <inheritdoc cref="ObservationSiteID"/>
    /// <param name="id"><inheritdoc cref="ID" path="/summary"/></param>
    public static implicit operator ObservationSiteID(string id) => new(id);

    /// <inheritdoc cref="ObservationSiteID"/>
    /// <param name="id"><inheritdoc cref="ID" path="/summary"/></param>
    public static implicit operator ObservationSiteID(int id) => new(id);

    /// <summary>Retrieves the ID represented by <paramref name="observationSiteID"/>.</summary>
    /// <param name="observationSiteID"><inheritdoc cref="ObservationSiteID" path="/summary"/></param>
    public static implicit operator string(ObservationSiteID observationSiteID) => observationSiteID.ID;
}
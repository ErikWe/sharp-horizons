namespace SharpHorizons.Identity;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents the name of a pre-defined observation site in Horizons.</summary>
public readonly record struct ObservationSiteName
{
    /// <summary>The Name of the observation site in Horizons.</summary>
    public required string Name { get; init; }

    /// <inheritdoc cref="ObservationSiteName"/>
    public ObservationSiteName() { }

    /// <inheritdoc cref="ObservationSiteName"/>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    [SetsRequiredMembers]
    public ObservationSiteName(string name)
    {
        Name = name;
    }

    /// <summary>Retrieves the name represented by <see langword="this"/>.</summary>
    public override string ToString() => Name;

    /// <summary>Retrieves the name represented by <see langword="this"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(IFormatProvider? provider) => Name.ToString(provider);

    /// <inheritdoc cref="ObservationSiteName"/>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    public static implicit operator ObservationSiteName(string name) => new(name);

    /// <summary>Retrieves the name represented by <paramref name="observationSiteName"/>.</summary>
    /// <param name="observationSiteName"><inheritdoc cref="ObservationSiteName" path="/summary"/></param>
    public static implicit operator string(ObservationSiteName observationSiteName) => observationSiteName.Name;
}
namespace SharpHorizons.Identity;

using System.Diagnostics.CodeAnalysis;

/// <summary>Represents a pre-defined observation site in Horizons.</summary>
public sealed record class ObservationSite
{
    /// <summary>The ID of the observation site.</summary>
    public required ObservationSiteID ID { get; init; }

    /// <summary>The name of the observation site.</summary>
    public required ObservationSiteName Name { get; init; }

    /// <inheritdoc cref="ObservationSite"/>
    public ObservationSite() { }

    /// <inheritdoc cref="ObservationSite"/>
    /// <param name="id"><inheritdoc cref="ID" path="/summary"/></param>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    [SetsRequiredMembers]
    public ObservationSite(ObservationSiteID id, ObservationSiteName name)
    {
        ID = id;
        Name = name;
    }
}

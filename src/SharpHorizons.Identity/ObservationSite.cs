namespace SharpHorizons;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents a pre-defined observation site in Horizons.</summary>
public sealed record class ObservationSite
{
    /// <summary>The <see cref="ObservationSiteID"/> of the <see cref="ObservationSite"/>.</summary>
    /// <exception cref="ArgumentException"/>
    public required ObservationSiteID ID
    {
        get => id;
        init
        {
            ObservationSiteID.Validate(value);

            id = value;
        }
    }

    /// <summary>The <see cref="ObservationSiteName"/> of the <see cref="ObservationSite"/>.</summary>
    /// <exception cref="ArgumentException"/>
    public required ObservationSiteName Name
    {
        get => name;
        init
        {
            ObservationSiteName.Validate(value);

            name = value;
        }
    }

    /// <inheritdoc cref="ObservationSite"/>
    public ObservationSite() { }

    /// <inheritdoc cref="ObservationSite"/>
    /// <param name="id"><inheritdoc cref="ID" path="/summary"/></param>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    [SetsRequiredMembers]
    public ObservationSite(ObservationSiteID id, ObservationSiteName name)
    {
        ObservationSiteID.Validate(id);
        ObservationSiteName.Validate(name);

        ID = id;
        Name = name;
    }

    /// <summary>Backing field for <see cref="ID"/>. Should not be used elsewhere.</summary>
    private readonly ObservationSiteID id;

    /// <summary>Backing field for <see cref="Name"/>. Should not be used elsewhere.</summary>
    private readonly ObservationSiteName name;
}

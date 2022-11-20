namespace SharpHorizons.Query.Origin;

using SharpHorizons.Identity;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <summary>Describes the <see cref="IOrigin"/> in a query as an <see cref="Identity.ObservationSiteID"/> associated with an <see cref="IOriginObject"/>.</summary>
internal sealed record class ObservationSiteOrigin : IObservationSiteOrigin
{
    /// <summary>The <see cref="IOriginObject"/>, associated with <see cref="ObservationSiteID"/>.</summary>
    public required IOriginObject OriginObject { get; init; }

    /// <summary>The <see cref="ObservationSiteID"/> associated with <see cref="OriginObject"/>.</summary>
    public required ObservationSiteID ObservationSiteID { get; init; }

    /// <summary>Used to compose a <see cref="IOriginArgument"/> describing <see langword="this"/>.</summary>
    public required IOriginComposer<IObservationSiteOrigin> Composer { private get; init; }

    /// <inheritdoc cref="ObservationSiteOrigin"/>
    public ObservationSiteOrigin() { }

    /// <inheritdoc cref="ObservationSiteOrigin"/>
    /// <param name="originobject">The <see cref="IOriginObject"/>, associated with <paramref name="observationSiteID"/>.</param>
    /// <param name="observationSiteID">The <see cref="ObservationSiteID"/> associated with <paramref name="originobject"/>.</param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public ObservationSiteOrigin(IOriginObject originobject, ObservationSiteID observationSiteID, IOriginComposer<IObservationSiteOrigin> composer)
    {
        OriginObject = originobject;
        ObservationSiteID = observationSiteID;

        Composer = composer;
    }

    bool IOrigin.UsesCoordinate => false;
    IOriginArgument IOrigin.ComposeArgument() => Composer.Compose(this);
    IOriginCoordinateArgument IOrigin.ComposeCoordinateArgument() => throw new OriginNotUsingCoordinateException();
    IOriginCoordinateTypeArgument IOrigin.ComposeCoordinateTypeArgument() => throw new OriginNotUsingCoordinateException();
}
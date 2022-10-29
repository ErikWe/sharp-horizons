namespace SharpHorizons.Query.Origin;

using SharpHorizons.Identification;
using SharpHorizons.Query.Arguments;

using System.Globalization;

/// <summary>Describes the <see cref="IOrigin"/> in a query as an <see cref="Identification.ObservationSiteID"/> associated with an <see cref="IOriginObject"/>.</summary>
internal sealed record class ObservationSiteOrigin : IOrigin
{
    /// <summary>The <see cref="IOriginObject"/>, associated with <see cref="ObservationSiteID"/>.</summary>
    private IOriginObject OriginObject { get; }

    /// <summary>The <see cref="ObservationSiteID"/> associated with <see cref="OriginObject"/>.</summary>
    private ObservationSiteID ObservationSiteID { get; }

    /// <summary>Describes the <see cref="IOrigin"/> in a query as <paramref name="observationSiteID"/> associated with <paramref name="originobject"/>.</summary>
    /// <param name="originobject">The <see cref="IOriginObject"/>, associated with <paramref name="observationSiteID"/>.</param>
    /// <param name="observationSiteID">The <see cref="ObservationSiteID"/> associated with <paramref name="originobject"/>.</param>
    public ObservationSiteOrigin(IOriginObject originobject, ObservationSiteID observationSiteID)
    {
        OriginObject = originobject;
        ObservationSiteID = observationSiteID;
    }

    bool IOrigin.UsesCoordinate => false;
    IOriginArgument IOrigin.ComposeArgument() => new OriginArgument($"{ObservationSiteID.ToString(CultureInfo.CurrentCulture)}@{OriginObject.ComposeIdentifier()}");
    IOriginCoordinateArgument IOrigin.ComposeCoordinateArgument() => throw new OriginNotUsingCoordinateException();
    IOriginCoordinateTypeArgument IOrigin.ComposeCoordinateTypeArgument() => throw new OriginNotUsingCoordinateException();
}
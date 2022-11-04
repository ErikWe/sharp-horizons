namespace SharpHorizons.Query.Origin;

using SharpHorizons.Identification;

/// <summary>Describes the <see cref="IOrigin"/> in a query as an <see cref="Identification.ObservationSiteID"/> associated with an <see cref="IOriginObject"/>.</summary>
public interface IObservationSiteOrigin : IOrigin
{
    /// <summary>The <see cref="IOriginObject"/>, associated with <see cref="ObservationSiteID"/>.</summary>
    public abstract IOriginObject OriginObject { get; }

    /// <summary>The <see cref="ObservationSiteID"/> associated with <see cref="OriginObject"/>.</summary>
    public abstract ObservationSiteID ObservationSiteID { get; }
}

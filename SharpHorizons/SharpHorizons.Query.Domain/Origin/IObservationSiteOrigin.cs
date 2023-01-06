namespace SharpHorizons.Query.Origin;

/// <summary>Describes the <see cref="IOrigin"/> in a query as an <see cref="SharpHorizons.ObservationSiteID"/> associated with some <see cref="IOriginObject"/>.</summary>
public interface IObservationSiteOrigin : IOrigin
{
    /// <summary>Some <see cref="IOriginObject"/>, associated with <see cref="ObservationSiteID"/>.</summary>
    public abstract IOriginObject OriginObject { get; }

    /// <summary>The <see cref="ObservationSiteID"/> associated with <see cref="OriginObject"/>.</summary>
    public abstract ObservationSiteID ObservationSiteID { get; }
}

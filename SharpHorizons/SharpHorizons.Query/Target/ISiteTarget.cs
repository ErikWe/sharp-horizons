namespace SharpHorizons.Query.Target;

/// <summary>Describes the <see cref="ITarget"/> in a query as a <see cref="ITargetSite"/> associated with a <see cref="ITargetSiteObject"/>.</summary>
public interface ISiteTarget : ITarget
{
    /// <summary>Represents the <see cref="ITargetSiteObject"/> associated with <see cref="TargetSite"/>.</summary>
    public abstract ITargetSiteObject TargetSiteObject { get; }
    /// <summary>Represents the <see cref="ITargetSite"/> associated with <see cref="TargetSiteObject"/>.</summary>
    public abstract ITargetSite TargetSite { get; }
}

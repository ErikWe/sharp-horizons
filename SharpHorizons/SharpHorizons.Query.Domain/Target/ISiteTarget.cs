namespace SharpHorizons.Query.Target;

/// <summary>Describes the <see cref="ITarget"/> in a query as some <see cref="ITargetSite"/> associated with some <see cref="ITargetObject"/>.</summary>
public interface ISiteTarget : ITarget
{
    /// <summary>Some <see cref="ITargetObject"/> associated with <see cref="TargetSite"/>.</summary>
    public abstract ITargetObject TargetObject { get; }

    /// <summary>Some <see cref="ITargetSite"/> associated with <see cref="TargetObject"/>.</summary>
    public abstract ITargetSite TargetSite { get; }
}

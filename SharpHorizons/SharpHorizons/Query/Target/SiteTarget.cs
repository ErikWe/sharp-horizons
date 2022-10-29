namespace SharpHorizons.Query.Target;

using SharpHorizons.Query.Arguments;

/// <summary>Describes the <see cref="ITarget"/> in a query as a <see cref="ITargetSite"/> associated with a <see cref="ITargetSiteObject"/>.</summary>
internal sealed record class SiteTarget : ITarget
{
    /// <summary>Represents the <see cref="ITargetSiteObject"/> associated with <see cref="TargetSite"/>.</summary>
    private ITargetSiteObject TargetSiteObject { get; }
    /// <summary>Represents the <see cref="ITargetSite"/> associated with <see cref="TargetSiteObject"/>.</summary>
    private ITargetSite TargetSite { get; }

    /// <summary>Describes the <see cref="ITarget"/> in a query as <paramref name="targetSite"/> associated with <paramref name="targetSiteObject"/>.</summary>
    /// <param name="targetSiteObject">Describes the <see cref="ITargetSiteObject"/> associated with <paramref name="targetSite"/>.</param>
    /// <param name="targetSite">Describes the <see cref="ITargetSite"/> associated with <paramref name="targetSiteObject"/>.</param>
    public SiteTarget(ITargetSiteObject targetSiteObject, ITargetSite targetSite)
    {
        TargetSiteObject = targetSiteObject;
        TargetSite = targetSite;
    }

    TargetArgument ITarget.ComposeIdentifier() => $"{TargetSite.ComposeIdentifier()}@{TargetSiteObject.ComposeIdentifier()}";
}
namespace SharpHorizons.Query.Target;

/// <summary>Represents a site associated with some <see cref="ITargetSiteObject"/>.</summary>
internal interface ITargetSite
{
    /// <summary>Composes a <see cref="TargetSiteIdentifier"/> describing the site.</summary>
    public TargetSiteIdentifier ComposeIdentifier();
}
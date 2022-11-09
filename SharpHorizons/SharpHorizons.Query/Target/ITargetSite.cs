namespace SharpHorizons.Query.Target;

/// <summary>Represents a site associated with some <see cref="ITargetSiteObject"/>.</summary>
public interface ITargetSite
{
    /// <summary>Composes a <see cref="TargetSiteIdentifier"/> describing the <see cref="ITargetSite"/>.</summary>
    public abstract TargetSiteIdentifier ComposeIdentifier();
}
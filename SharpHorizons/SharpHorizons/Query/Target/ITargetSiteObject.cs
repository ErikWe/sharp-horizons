namespace SharpHorizons.Query.Target;

/// <summary>Represents an object associated with some <see cref="ITargetSite"/>.</summary>
public interface ITargetSiteObject
{
    /// <summary>Composes a <see cref="TargetSiteObjectIdentifier"/> describing the <see cref="ITargetSiteObject"/>.</summary>
    public abstract TargetSiteObjectIdentifier ComposeIdentifier();
}
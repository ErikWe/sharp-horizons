namespace SharpHorizons.Query.Target;

/// <summary>Represents an object associated with some <see cref="ITargetSite"/>.</summary>
internal interface ITargetSiteObject
{
    /// <summary>Composes a <see cref="TargetSiteObjectIdentifier"/> describing the object.</summary>
    public TargetSiteObjectIdentifier ComposeIdentifier();
}
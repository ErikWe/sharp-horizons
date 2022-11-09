namespace SharpHorizons.Query.Target;

using SharpHorizons.Composers.Arguments.Target;
using SharpHorizons.Identity;

/// <summary>Describes the <see cref="ITargetSiteObject"/> as an object identified by a <see cref="MajorObjectName"/>.</summary>
internal sealed record class MajorObjectNameTargetSiteObject : ITargetSiteObject
{
    /// <summary>The <see cref="MajorObjectID"/> of an object which represents the <see cref="ITargetSiteObject"/>.</summary>
    private MajorObjectName Name { get; }

    /// <summary>Used to compose a <see cref="TargetSiteObjectIdentifier"/> describing <see langword="this"/>.</summary>
    private ITargetSiteObjectComposer<MajorObjectName> Composer { get; }

    /// <summary>Describes the <see cref="ITargetSiteObject"/> as an object identified by <paramref name="name"/>.</summary>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public MajorObjectNameTargetSiteObject(MajorObjectName name, ITargetSiteObjectComposer<MajorObjectName> composer)
    {
        Name = name;

        Composer = composer;
    }

    TargetSiteObjectIdentifier ITargetSiteObject.ComposeIdentifier() => Composer.Compose(Name);
}

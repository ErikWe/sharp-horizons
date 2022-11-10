namespace SharpHorizons.Query.Target;

using SharpHorizons.Identity;

/// <summary>Describes the <see cref="ITargetSiteObject"/> as a <see cref="Identity.MajorObject"/>.</summary>
internal sealed record class MajorObjectTargetSiteObject : ITargetSiteObject
{
    /// <summary>The <see cref="Identity.MajorObject"/> which represents the <see cref="ITargetSiteObject"/>.</summary>
    private MajorObject MajorObject { get; }

    /// <summary>Used to compose a <see cref="TargetSiteObjectIdentifier"/> describing <see langword="this"/>.</summary>
    private ITargetSiteObjectComposer<MajorObject> Composer { get; }

    /// <summary>Describes the <see cref="ITargetSiteObject"/> as <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject"><inheritdoc cref="MajorObject" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public MajorObjectTargetSiteObject(MajorObject majorObject, ITargetSiteObjectComposer<MajorObject> composer)
    {
        MajorObject = majorObject;

        Composer = composer;
    }

    TargetSiteObjectIdentifier ITargetSiteObject.ComposeIdentifier() => Composer.Compose(MajorObject);
}

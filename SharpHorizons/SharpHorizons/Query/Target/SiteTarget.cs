namespace SharpHorizons.Query.Target;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

/// <inheritdoc cref="ISiteTarget"/>
internal sealed record class SiteTarget : ISiteTarget
{
    /// <inheritdoc/>
    public ITargetSiteObject TargetSiteObject { get; }

    /// <inheritdoc/>
    public ITargetSite TargetSite { get; }

    /// <summary>Used to compose a <see cref="ICommandArgument"/> describing <see langword="this"/>.</summary>
    private ICommandComposer<ISiteTarget> Composer { get; }

    /// <summary>Describes the <see cref="ITarget"/> in a query as <paramref name="targetSite"/> associated with <paramref name="targetSiteObject"/>.</summary>
    /// <param name="targetSiteObject">Describes the <see cref="ITargetSiteObject"/> associated with <paramref name="targetSite"/>.</param>
    /// <param name="targetSite">Describes the <see cref="ITargetSite"/> associated with <paramref name="targetSiteObject"/>.</param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public SiteTarget(ITargetSiteObject targetSiteObject, ITargetSite targetSite, ICommandComposer<ISiteTarget> composer)
    {
        TargetSiteObject = targetSiteObject;
        TargetSite = targetSite;

        Composer = composer;
    }

    ICommandArgument ITarget.ComposeArgument() => Composer.Compose(this);
}
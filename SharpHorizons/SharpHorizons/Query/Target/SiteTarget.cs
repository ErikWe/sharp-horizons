namespace SharpHorizons.Query.Target;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="ISiteTarget"/>
internal sealed record class SiteTarget : ISiteTarget
{
    public required ITargetObject TargetObject { get; init; }
    public required ITargetSite TargetSite { get; init; }

    /// <summary>Used to compose a <see cref="ITargetArgument"/> describing <see langword="this"/>.</summary>
    public required ITargetComposer<ISiteTarget> Composer { private get; init; }

    /// <inheritdoc cref="SiteTarget"/>
    public SiteTarget() { }

    /// <inheritdoc cref="SiteTarget"/>
    /// <param name="targetObject"><inheritdoc cref="TargetObject" path="/summary"/></param>
    /// <param name="targetSite"><inheritdoc cref="TargetSite" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public SiteTarget(ITargetObject targetObject, ITargetSite targetSite, ITargetComposer<ISiteTarget> composer)
    {
        TargetObject = targetObject;
        TargetSite = targetSite;

        Composer = composer;
    }

    ITargetArgument ITarget.ComposeArgument() => ((IArgumentComposer<ITargetArgument, ISiteTarget>)Composer).Compose(this);
}

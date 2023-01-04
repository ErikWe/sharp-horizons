namespace SharpHorizons.Query.Target;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IBodyCentricTarget"/>
internal sealed record class BodyCentricTarget : IBodyCentricTarget
{
    public required ITargetObject TargetObject { get; init; }

    /// <summary>Used to compose a <see cref="ITargetArgument"/> describing <see langword="this"/>.</summary>
    public required ITargetComposer<IBodyCentricTarget> Composer { private get; init; }

    /// <inheritdoc cref="SiteTarget"/>
    public BodyCentricTarget() { }

    /// <inheritdoc cref="SiteTarget"/>
    /// <param name="targetObject"><inheritdoc cref="TargetObject" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public BodyCentricTarget(ITargetObject targetObject, ITargetComposer<IBodyCentricTarget> composer)
    {
        TargetObject = targetObject;

        Composer = composer;
    }

    ITargetArgument ITarget.ComposeArgument() => ((IArgumentComposer<ITargetArgument, IBodyCentricTarget>)Composer).Compose(this);
}

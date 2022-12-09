namespace SharpHorizons.Query.Target;

using SharpHorizons.MPC;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <summary>Describes the <see cref="ITarget"/> in a query as the center of a comet identified by an <see cref="MPCCometName"/>.</summary>
internal sealed record class MPCCometNameTarget : ITarget
{
    /// <summary>The <see cref="MPCCometName"/> of a comet, the center of which represents the <see cref="ITarget"/> in a query.</summary>
    public required MPCCometName Name { private get; init; }

    /// <summary>Used to compose a <see cref="ITargetArgument"/> describing <see langword="this"/>.</summary>
    public required ITargetComposer<MPCCometName> Composer { private get; init; }

    /// <inheritdoc cref="MPCCometNameTarget"/>
    public MPCCometNameTarget() { }

    /// <inheritdoc cref="MPCCometNameTarget"/>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public MPCCometNameTarget(MPCCometName name, ITargetComposer<MPCCometName> composer)
    {
        Name = name;

        Composer = composer;
    }

    ITargetArgument ITarget.ComposeArgument() => ((IArgumentComposer<ITargetArgument, MPCCometName>)Composer).Compose(Name);
}

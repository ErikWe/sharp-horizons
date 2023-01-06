namespace SharpHorizons.Query.Target;

using SharpHorizons.MPC;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <summary>Describes the <see cref="ITarget"/> in a query as the center of a <see cref="MPC.MPCComet"/>.</summary>
internal sealed record class MPCCometTarget : ITarget
{
    /// <summary>The <see cref="MPC.MPCComet"/>, the center of which represents the <see cref="ITarget"/> in a query.</summary>
    public required MPCComet MPCComet { private get; init; }

    /// <summary>Used to compose a <see cref="ITargetArgument"/> describing <see langword="this"/>.</summary>
    public required ITargetComposer<MPCComet> Composer { private get; init; }

    /// <inheritdoc cref="MPCCometTarget"/>
    public MPCCometTarget() { }

    /// <inheritdoc cref="MPCCometTarget"/>
    /// <param name="mpcComet"><inheritdoc cref="MPCComet" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public MPCCometTarget(MPCComet mpcComet, ITargetComposer<MPCComet> composer)
    {
        MPCComet = mpcComet;

        Composer = composer;
    }

    ITargetArgument ITarget.ComposeArgument() => ((IArgumentComposer<ITargetArgument, MPCComet>)Composer).Compose(MPCComet);
}

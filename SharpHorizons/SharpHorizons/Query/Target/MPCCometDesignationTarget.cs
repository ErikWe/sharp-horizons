namespace SharpHorizons.Query.Target;

using SharpHorizons.Identity;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <summary>Describes the <see cref="ITarget"/> in a query as the center of a comet identified by an <see cref="MPCCometDesignation"/>.</summary>
internal sealed record class MPCCometDesignationTarget : ITarget
{
    /// <summary>The <see cref="MPCCometDesignation"/> of a comet, the center of which represents the <see cref="ITarget"/> in a query.</summary>
    public required MPCCometDesignation Designation { private get; init; }

    /// <summary>Used to compose a <see cref="ITargetArgument"/> describing <see langword="this"/>.</summary>
    public required ITargetComposer<MPCCometDesignation> Composer { private get; init; }

    /// <inheritdoc cref="MPCCometDesignationTarget"/>
    public MPCCometDesignationTarget() { }

    /// <inheritdoc cref="MPCCometDesignationTarget"/>
    /// <param name="designation"><inheritdoc cref="Designation" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public MPCCometDesignationTarget(MPCCometDesignation designation, ITargetComposer<MPCCometDesignation> composer)
    {
        Designation = designation;

        Composer = composer;
    }

    ITargetArgument ITarget.ComposeArgument() => ((IArgumentComposer<ITargetArgument, MPCCometDesignation>)Composer).Compose(Designation);
}

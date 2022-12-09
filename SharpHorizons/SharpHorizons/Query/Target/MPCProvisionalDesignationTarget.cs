namespace SharpHorizons.Query.Target;

using SharpHorizons.MPC;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by a <see cref="MPCProvisionalDesignation"/>.</summary>
internal sealed record class MPCProvisionalDesignationTarget : ITarget
{
    /// <summary>The <see cref="MPCProvisionalDesignation"/> of an object, the center of which represents the <see cref="ITarget"/> in a query.</summary>
    public required MPCProvisionalDesignation Designation { private get; init; }

    /// <summary>Used to compose a <see cref="ITargetArgument"/> describing <see langword="this"/>.</summary>
    public required ITargetComposer<MPCProvisionalDesignation> Composer { private get; init; }

    /// <inheritdoc cref="MPCProvisionalDesignationTarget"/>
    public MPCProvisionalDesignationTarget() { }

    /// <inheritdoc cref="MPCProvisionalDesignationTarget"/>
    /// <param name="designation"><inheritdoc cref="Designation" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public MPCProvisionalDesignationTarget(MPCProvisionalDesignation designation, ITargetComposer<MPCProvisionalDesignation> composer)
    {
        Designation = designation;

        Composer = composer;
    }

    ITargetArgument ITarget.ComposeArgument() => ((IArgumentComposer<ITargetArgument, MPCProvisionalDesignation>)Composer).Compose(Designation);
}

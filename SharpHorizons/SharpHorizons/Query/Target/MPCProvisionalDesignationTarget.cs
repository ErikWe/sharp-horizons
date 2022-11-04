namespace SharpHorizons.Query.Target;

using SharpHorizons.Identification;
using SharpHorizons.Query.Arguments;

/// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by a <see cref="MPCProvisionalDesignation"/>.</summary>
internal sealed record class MPCProvisionalDesignationTarget : ITarget
{
    /// <summary>The <see cref="MPCProvisionalDesignation"/> of an object, the center of which represents the <see cref="ITarget"/> in a query.</summary>
    private MPCProvisionalDesignation Designation { get; }

    /// <summary>Used to compose a <see cref="ITargetArgument"/> describing <see langword="this"/>.</summary>
    private ITargetComposer<MPCProvisionalDesignation> Composer { get; }

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by <paramref name="designation"/>.</summary>
    /// <param name="designation"><inheritdoc cref="Designation" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public MPCProvisionalDesignationTarget(MPCProvisionalDesignation designation, ITargetComposer<MPCProvisionalDesignation> composer)
    {
        Designation = designation;

        Composer = composer;
    }

    ITargetArgument ITarget.ComposeArgument() => Composer.Compose(Designation);
}

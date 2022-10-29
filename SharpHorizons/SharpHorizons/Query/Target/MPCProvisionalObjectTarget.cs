namespace SharpHorizons.Query.Target;

using SharpHorizons.Identification;
using SharpHorizons.Query.Arguments;

/// <summary>Describes the <see cref="ITarget"/> in a query as an object identified by an <see cref="MPCProvisionalDesignation"/>.</summary>
internal sealed record class MPCProvisionalDesignationTarget : ITarget
{
    /// <summary>The <see cref="MPCProvisionalDesignation"/> of an object, the center of which represents the <see cref="ITarget"/> in a query.</summary>
    private MPCProvisionalDesignation Designation { get; }

    /// <summary>Describes the <see cref="ITarget"/> in a query as an object identified by <paramref name="designation"/>.</summary>
    /// <param name="designation"><inheritdoc cref="Designation" path="/summary"/></param>
    public MPCProvisionalDesignationTarget(MPCProvisionalDesignation designation)
    {
        Designation = designation;
    }

    ITargetArgument ITarget.ComposeArgument() => new TargetArgument(Designation.Value);
}

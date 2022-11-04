namespace SharpHorizons.Query.Target;

using SharpHorizons.Identification;
using SharpHorizons.Query.Arguments;

/// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCProvisionalDesignation"/>.</summary>
internal sealed class MPCProvisionalDesignationTargetComposer : ITargetComposer<MPCProvisionalDesignation>
{
    ITargetArgument IArgumentComposer<ITargetArgument, MPCProvisionalDesignation>.Compose(MPCProvisionalDesignation obj) => new QueryArgument($"{obj.Value};");
}

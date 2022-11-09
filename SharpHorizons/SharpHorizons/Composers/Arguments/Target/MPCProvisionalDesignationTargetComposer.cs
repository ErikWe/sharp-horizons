namespace SharpHorizons.Composers.Arguments.Target;

using SharpHorizons.Identity;
using SharpHorizons.Query;

/// <summary>Composes <see cref="ICommandArgument"/> that describe <see cref="MPCProvisionalDesignation"/>.</summary>
internal sealed class MPCProvisionalDesignationTargetComposer : ICommandComposer<MPCProvisionalDesignation>
{
    ICommandArgument IArgumentComposer<ICommandArgument, MPCProvisionalDesignation>.Compose(MPCProvisionalDesignation obj) => new QueryArgument($"{obj.Value};");
}

namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.Identity;

/// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCProvisionalDesignation"/>.</summary>
internal sealed class MPCProvisionalDesignationTargetComposer : ITargetComposer<MPCProvisionalDesignation>
{
    ITargetArgument IArgumentComposer<ITargetArgument, MPCProvisionalDesignation>.Compose(MPCProvisionalDesignation obj) => new QueryArgument($"{obj.Designation};");
    ICommandArgument IArgumentComposer<ICommandArgument, MPCProvisionalDesignation>.Compose(MPCProvisionalDesignation obj) => ((IArgumentComposer<ITargetArgument, MPCProvisionalDesignation>)this).Compose(obj);
}

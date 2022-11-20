namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.Identity;

/// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCCometDesignation"/>.</summary>
internal sealed class MPCCometDesignationTargetComposer : ITargetComposer<MPCCometDesignation>
{
    ITargetArgument IArgumentComposer<ITargetArgument, MPCCometDesignation>.Compose(MPCCometDesignation obj) => new QueryArgument($"{obj.Designation};");
    ICommandArgument IArgumentComposer<ICommandArgument, MPCCometDesignation>.Compose(MPCCometDesignation obj) => ((IArgumentComposer<ITargetArgument, MPCCometDesignation>)this).Compose(obj);
}

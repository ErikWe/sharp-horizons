namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.MPC;

/// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCProvisionalDesignation"/>.</summary>
internal sealed class MPCProvisionalDesignationTargetComposer : ITargetComposer<MPCProvisionalDesignation>
{
    ITargetArgument IArgumentComposer<ITargetArgument, MPCProvisionalDesignation>.Compose(MPCProvisionalDesignation obj)
    {
        MPCProvisionalDesignation.Validate(obj);

        return new QueryArgument($"{obj.Value};");
    }

    ICommandArgument IArgumentComposer<ICommandArgument, MPCProvisionalDesignation>.Compose(MPCProvisionalDesignation obj) => ((IArgumentComposer<ITargetArgument, MPCProvisionalDesignation>)this).Compose(obj);
}

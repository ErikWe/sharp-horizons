namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.MPC;

using System.Diagnostics.CodeAnalysis;

/// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCProvisionalDesignation"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class MPCProvisionalDesignationTargetComposer : ITargetComposer<MPCProvisionalDesignation>
{
    ITargetArgument IArgumentComposer<ITargetArgument, MPCProvisionalDesignation>.Compose(MPCProvisionalDesignation obj)
    {
        MPCProvisionalDesignation.Validate(obj);

        return new QueryArgument($"{obj.Value};");
    }

    ICommandArgument IArgumentComposer<ICommandArgument, MPCProvisionalDesignation>.Compose(MPCProvisionalDesignation obj) => ((IArgumentComposer<ITargetArgument, MPCProvisionalDesignation>)this).Compose(obj);
}

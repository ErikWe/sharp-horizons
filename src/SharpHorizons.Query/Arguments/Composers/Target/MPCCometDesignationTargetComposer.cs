namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.MPC;

using System.Diagnostics.CodeAnalysis;

/// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCCometDesignation"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class MPCCometDesignationTargetComposer : ITargetComposer<MPCCometDesignation>
{
    ITargetArgument IArgumentComposer<ITargetArgument, MPCCometDesignation>.Compose(MPCCometDesignation obj)
    {
        MPCCometDesignation.Validate(obj);

        return new QueryArgument($"{obj.Value};");
    }

    ICommandArgument IArgumentComposer<ICommandArgument, MPCCometDesignation>.Compose(MPCCometDesignation obj) => ((IArgumentComposer<ITargetArgument, MPCCometDesignation>)this).Compose(obj);
}

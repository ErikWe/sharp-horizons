namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.Identity;

using System;

/// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCComet"/>.</summary>
internal sealed class MPCCometTargetComposer : ITargetComposer<MPCComet>
{
    /// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCCometDesignation"/>.</summary>
    private ITargetComposer<MPCCometDesignation> DesignationComposer { get; }

    /// <inheritdoc cref="MPCCometTargetComposer"/>
    /// <param name="designationComposer"><inheritdoc cref="DesignationComposer" path="/summary"/></param>
    public MPCCometTargetComposer(ITargetComposer<MPCCometDesignation> designationComposer)
    {
        DesignationComposer = designationComposer;
    }

    ITargetArgument IArgumentComposer<ITargetArgument, MPCComet>.Compose(MPCComet obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return ((IArgumentComposer<ITargetArgument, MPCCometDesignation>)DesignationComposer).Compose(obj.Designation);
    }

    ICommandArgument IArgumentComposer<ICommandArgument, MPCComet>.Compose(MPCComet obj) => ((IArgumentComposer<ITargetArgument, MPCComet>)this).Compose(obj);
}

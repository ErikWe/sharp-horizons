namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.MPC;

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

        var argument = ((IArgumentComposer<ITargetArgument, MPCCometDesignation>)DesignationComposer).Compose(obj.Designation);

        try
        {
            QueryArgument.Validate(argument);
        }
        catch (ArgumentException e)
        {
            throw new InvalidOperationException($"The {nameof(ITargetComposer<MPCCometDesignation>)} for {nameof(MPCCometDesignation)} provided an invalid {nameof(ITargetArgument)}.", e);
        }

        return argument;
    }

    ICommandArgument IArgumentComposer<ICommandArgument, MPCComet>.Compose(MPCComet obj) => ((IArgumentComposer<ITargetArgument, MPCComet>)this).Compose(obj);
}

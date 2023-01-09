namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.MPC;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCProvisionalObject"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class MPCProvisionalObjectTargetComposer : ITargetComposer<MPCProvisionalObject>
{
    /// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCProvisionalDesignation"/>.</summary>
    private ITargetComposer<MPCProvisionalDesignation> DesignationComposer { get; }

    /// <inheritdoc cref="MPCObjectTargetComposer"/>
    /// <param name="designationComposer"><inheritdoc cref="DesignationComposer" path="/summary"/></param>
    public MPCProvisionalObjectTargetComposer(ITargetComposer<MPCProvisionalDesignation> designationComposer)
    {
        DesignationComposer = designationComposer;
    }

    ITargetArgument IArgumentComposer<ITargetArgument, MPCProvisionalObject>.Compose(MPCProvisionalObject obj)
    {
        MPCProvisionalObject.Validate(obj);

        var argument = ((IArgumentComposer<ITargetArgument, MPCProvisionalDesignation>)DesignationComposer).Compose(obj.Designation);

        try
        {
            QueryArgument.Validate(argument);
        }
        catch (ArgumentException e)
        {
            throw new InvalidOperationException($"The {nameof(ITargetComposer<MPCProvisionalDesignation>)} for {nameof(MPCProvisionalDesignation)} provided an invalid {nameof(ITargetArgument)}.", e);
        }

        return argument;
    }

    ICommandArgument IArgumentComposer<ICommandArgument, MPCProvisionalObject>.Compose(MPCProvisionalObject obj) => ((IArgumentComposer<ITargetArgument, MPCProvisionalObject>)this).Compose(obj);
}

namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.Identity;

/// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCProvisionalObject"/>.</summary>
internal sealed class MPCProvisionalObjectTargetComposer : ITargetComposer<MPCProvisionalObject>
{
    /// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCProvisionalDesignation"/>.</summary>
    private ITargetComposer<MPCProvisionalDesignation> DesignationComposer { get; }

    /// <summary><inheritdoc cref="MPCObjectTargetComposer" path="/summary"/></summary>
    /// <param name="designationComposer"><inheritdoc cref="DesignationComposer" path="/summary"/></param>
    public MPCProvisionalObjectTargetComposer(ITargetComposer<MPCProvisionalDesignation> designationComposer)
    {
        DesignationComposer = designationComposer;
    }

    ITargetArgument IArgumentComposer<ITargetArgument, MPCProvisionalObject>.Compose(MPCProvisionalObject obj) => ((IArgumentComposer<ITargetArgument, MPCProvisionalDesignation>)DesignationComposer).Compose(obj.Designation);
    ICommandArgument IArgumentComposer<ICommandArgument, MPCProvisionalObject>.Compose(MPCProvisionalObject obj) => ((IArgumentComposer<ITargetArgument, MPCProvisionalObject>)this).Compose(obj);
}

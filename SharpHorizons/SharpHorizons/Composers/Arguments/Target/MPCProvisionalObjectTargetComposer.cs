namespace SharpHorizons.Composers.Arguments.Target;

using SharpHorizons.Identity;
using SharpHorizons.Query;

/// <summary>Composes <see cref="ICommandArgument"/> that describe <see cref="MPCProvisionalObject"/>.</summary>
internal sealed class MPCProvisionalObjectTargetComposer : ICommandComposer<MPCProvisionalObject>
{
    /// <summary>Composes <see cref="ICommandArgument"/> that describe <see cref="MPCProvisionalDesignation"/>.</summary>
    private ICommandComposer<MPCProvisionalDesignation> DesignationComposer { get; }

    /// <summary><inheritdoc cref="MPCObjectTargetComposer" path="/summary"/></summary>
    /// <param name="designationComposer"><inheritdoc cref="DesignationComposer" path="/summary"/></param>
    public MPCProvisionalObjectTargetComposer(ICommandComposer<MPCProvisionalDesignation> designationComposer)
    {
        DesignationComposer = designationComposer;
    }

    ICommandArgument IArgumentComposer<ICommandArgument, MPCProvisionalObject>.Compose(MPCProvisionalObject obj) => DesignationComposer.Compose(obj.Designation);
}

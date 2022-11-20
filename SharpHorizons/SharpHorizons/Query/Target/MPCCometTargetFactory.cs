namespace SharpHorizons.Query.Target;

using SharpHorizons.Identity;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;
using SharpHorizons.Query.Arguments.Composers.Target;

using System;

/// <inheritdoc cref="IMPCCometTargetFactory"/>
internal sealed class MPCCometTargetFactory : IMPCCometTargetFactory
{
    /// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCComet"/>.</summary>
    private ITargetComposer<MPCComet> CometComposer { get; }

    /// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCCometName"/>.</summary>
    private ITargetComposer<MPCCometName> NameComposer { get; }

    /// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCCometDesignation"/>.</summary>
    private ITargetComposer<MPCCometDesignation> DesignationComposer { get; }

    /// <inheritdoc cref="MPCCometTargetFactory"/>
    /// <param name="cometComposer"><inheritdoc cref="CometComposer" path="/summary"/></param>
    /// <param name="nameComposer"><inheritdoc cref="NameComposer" path="/summary"/></param>
    /// <param name="designationComposer"><inheritdoc cref="DesignationComposer" path="/summary"/></param>
    public MPCCometTargetFactory(ITargetComposer<MPCComet>? cometComposer = null, ITargetComposer<MPCCometName>? nameComposer = null, ITargetComposer<MPCCometDesignation>? designationComposer = null)
    {
        designationComposer ??= new MPCCometDesignationTargetComposer();

        CometComposer = cometComposer ?? new MPCCometTargetComposer(designationComposer);
        NameComposer = nameComposer ?? new MPCCometNameTargetComposer();
        DesignationComposer = designationComposer;
    }

    ITarget IMPCCometTargetFactory.Create(MPCComet mpcComet)
    {
        ArgumentNullException.ThrowIfNull(mpcComet);

        return new MPCCometTarget(mpcComet, CometComposer);
    }

    ITarget IMPCCometTargetFactory.Create(MPCCometName mpcName) => new MPCCometNameTarget(mpcName, NameComposer);
    ITarget IMPCCometTargetFactory.Create(MPCCometDesignation mpcDesignation) => new MPCCometDesignationTarget(mpcDesignation, DesignationComposer);
}

namespace SharpHorizons.Query.Target;

using SharpHorizons.Composers.Arguments;
using SharpHorizons.Composers.Arguments.Target;
using SharpHorizons.Identity;

using System;

/// <inheritdoc cref="IMPCTargetFactory"/>
internal sealed class MPCTargetFactory : IMPCTargetFactory
{
    /// <summary>Composes <see cref="ICommandArgument"/> that describe <see cref="MPCObject"/>.</summary>
    private ICommandComposer<MPCObject> ObjectComposer { get; }

    /// <summary>Composes <see cref="ICommandArgument"/> that describe <see cref="MPCProvisionalObject"/>.</summary>
    private ICommandComposer<MPCProvisionalObject> ProvisionalObjectComposer { get; }

    /// <summary>Composes <see cref="ICommandArgument"/> that describe <see cref="MPCName"/>.</summary>
    private ICommandComposer<MPCName> NameComposer { get; }

    /// <summary>Composes <see cref="ICommandArgument"/> that describe <see cref="MPCProvisionalDesignation"/>.</summary>
    private ICommandComposer<MPCProvisionalDesignation> ProvisionalDesignationComposer { get; }

    /// <summary>Composes <see cref="ICommandArgument"/> that describe <see cref="MPCSequentialNumber"/>.</summary>
    private ICommandComposer<MPCSequentialNumber> SequentialNumberComposer { get; }

    /// <summary><inheritdoc cref="MPCTargetFactory" path="/summary"/></summary>
    /// <param name="objectComposer"><inheritdoc cref="ObjectComposer" path="/summary"/></param>
    /// <param name="provisionalObjectComposer"><inheritdoc cref="ProvisionalObjectComposer" path="/summary"/></param>
    /// <param name="nameComposer"><inheritdoc cref="NameComposer" path="/summary"/></param>
    /// <param name="provisionalDesignationComposer"><inheritdoc cref="ProvisionalDesignationComposer" path="/summary"/></param>
    /// <param name="sequentialNumberComposer"><inheritdoc cref="SequentialNumberComposer" path="/summary"/></param>
    public MPCTargetFactory(ICommandComposer<MPCObject>? objectComposer = null, ICommandComposer<MPCProvisionalObject>? provisionalObjectComposer = null, ICommandComposer<MPCName>? nameComposer = null, ICommandComposer<MPCProvisionalDesignation>? provisionalDesignationComposer = null, ICommandComposer<MPCSequentialNumber>? sequentialNumberComposer = null)
    {
        sequentialNumberComposer ??= new MPCSequentialNumberTargetComposer();
        provisionalDesignationComposer ??= new MPCProvisionalDesignationTargetComposer();

        ObjectComposer = objectComposer ?? new MPCObjectTargetComposer(sequentialNumberComposer);
        ProvisionalObjectComposer = provisionalObjectComposer ?? new MPCProvisionalObjectTargetComposer(provisionalDesignationComposer);
        NameComposer = nameComposer ?? new MPCNameTargetComposer();
        ProvisionalDesignationComposer = provisionalDesignationComposer;
        SequentialNumberComposer = sequentialNumberComposer;
    }

    ITarget IMPCTargetFactory.Create(MPCObject mpcObject)
    {
        ArgumentNullException.ThrowIfNull(mpcObject);

        return new MPCObjectTarget(mpcObject, ObjectComposer);
    }

    ITarget IMPCTargetFactory.Create(MPCProvisionalObject mpcObject) => new MPCProvisionalObjectTarget(mpcObject, ProvisionalObjectComposer);
    ITarget IMPCTargetFactory.Create(MPCName mpcName) => new MPCNameTarget(mpcName, NameComposer);
    ITarget IMPCTargetFactory.Create(MPCProvisionalDesignation mpcDesignation) => new MPCProvisionalDesignationTarget(mpcDesignation, ProvisionalDesignationComposer);
    ITarget IMPCTargetFactory.Create(MPCSequentialNumber mpcNumber) => new MPCSequentialNumberTarget(mpcNumber, SequentialNumberComposer);
}

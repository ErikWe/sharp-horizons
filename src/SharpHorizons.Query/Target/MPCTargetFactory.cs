﻿namespace SharpHorizons.Query.Target;

using SharpHorizons.MPC;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;
using SharpHorizons.Query.Arguments.Composers.Target;

using System;

/// <inheritdoc cref="IMPCTargetFactory"/>
internal sealed class MPCTargetFactory : IMPCTargetFactory
{
    /// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCObject"/>.</summary>
    private ITargetComposer<MPCObject> ObjectComposer { get; }

    /// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCProvisionalObject"/>.</summary>
    private ITargetComposer<MPCProvisionalObject> ProvisionalObjectComposer { get; }

    /// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCName"/>.</summary>
    private ITargetComposer<MPCName> NameComposer { get; }

    /// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCProvisionalDesignation"/>.</summary>
    private ITargetComposer<MPCProvisionalDesignation> ProvisionalDesignationComposer { get; }

    /// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCSequentialNumber"/>.</summary>
    private ITargetComposer<MPCSequentialNumber> SequentialNumberComposer { get; }

    /// <inheritdoc cref="MPCTargetFactory"/>
    /// <param name="objectComposer"><inheritdoc cref="ObjectComposer" path="/summary"/></param>
    /// <param name="provisionalObjectComposer"><inheritdoc cref="ProvisionalObjectComposer" path="/summary"/></param>
    /// <param name="nameComposer"><inheritdoc cref="NameComposer" path="/summary"/></param>
    /// <param name="provisionalDesignationComposer"><inheritdoc cref="ProvisionalDesignationComposer" path="/summary"/></param>
    /// <param name="sequentialNumberComposer"><inheritdoc cref="SequentialNumberComposer" path="/summary"/></param>
    public MPCTargetFactory(ITargetComposer<MPCObject>? objectComposer = null, ITargetComposer<MPCProvisionalObject>? provisionalObjectComposer = null, ITargetComposer<MPCName>? nameComposer = null, ITargetComposer<MPCProvisionalDesignation>? provisionalDesignationComposer = null, ITargetComposer<MPCSequentialNumber>? sequentialNumberComposer = null)
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

    ITarget IMPCTargetFactory.Create(MPCProvisionalObject mpcObject)
    {
        MPCProvisionalObject.Validate(mpcObject);

        return new MPCProvisionalObjectTarget(mpcObject, ProvisionalObjectComposer);
    }
    ITarget IMPCTargetFactory.Create(MPCName mpcName)
    {
        MPCName.Validate(mpcName);

        return new MPCNameTarget(mpcName, NameComposer);
    }

    ITarget IMPCTargetFactory.Create(MPCProvisionalDesignation mpcDesignation)
    {
        MPCProvisionalDesignation.Validate(mpcDesignation);

        return new MPCProvisionalDesignationTarget(mpcDesignation, ProvisionalDesignationComposer);
    }

    ITarget IMPCTargetFactory.Create(MPCSequentialNumber mpcNumber)
    {
        MPCSequentialNumber.Validate(mpcNumber);

        return new MPCSequentialNumberTarget(mpcNumber, SequentialNumberComposer);
    }
}

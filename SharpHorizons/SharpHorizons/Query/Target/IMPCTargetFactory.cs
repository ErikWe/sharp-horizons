namespace SharpHorizons.Query.Target;

using SharpHorizons.Identification;

using System;

/// <summary>Handles construction of <see cref="ITarget"/> associated with <see cref="MPCObject"/>.</summary>
public interface IMPCTargetFactory
{
    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of <paramref name="mpcObject"/>.</summary>
    /// <param name="mpcObject">The center of this <see cref="MPCObject"/> represents the <see cref="ITarget"/> in a query.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract ITarget Create(MPCObject mpcObject);

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of <paramref name="mpcObject"/>.</summary>
    /// <param name="mpcObject">The center of this <see cref="MPCProvisionalObject"/> represents the <see cref="ITarget"/> in a query.</param>
    public abstract ITarget Create(MPCProvisionalObject mpcObject);

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by <paramref name="mpcName"/>.</summary>
    /// <param name="mpcName"><inheritdoc cref="MPCNameTarget.Name" path="/summary"/></param>
    public abstract ITarget Create(MPCName mpcName);

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by <paramref name="mpcDesignation"/>.</summary>
    /// <param name="mpcDesignation"><inheritdoc cref="MPCProvisionalDesignationTarget.Designation" path="/summary"/></param>
    public abstract ITarget Create(MPCProvisionalDesignation mpcDesignation);

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by <paramref name="mpcNumber"/>.</summary>
    /// <param name="mpcNumber"><inheritdoc cref="MPCSequentialNumberTarget.Number" path="/summary"/></param>
    public abstract ITarget Create(MPCSequentialNumber mpcNumber);
}
namespace SharpHorizons.Query.Origin;

using SharpHorizons.Identification;

/// <summary>Handles construction of <see cref="IOriginObject"/>.</summary>
public interface IOriginObjectFactory
{
    /// <summary>Describes the <see cref="IOriginObject"/> in a query as <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">This <see cref="MajorObject"/> represents the <see cref="IOriginObject"/> in a query.</param>
    public abstract IOriginObject Create(MajorObject majorObject);

    /// <summary>Describes the <see cref="IOriginObject"/> in a query as an object identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of an object which represents the <see cref="IOriginObject"/> in a query.</param>
    public abstract IOriginObject Create(MajorObjectID majorObjectID);

    /// <summary>Describes the <see cref="IOriginObject"/> in a query as an object identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of an object which represents the <see cref="IOriginObject"/> in a query.</param>
    public abstract IOriginObject Create(MajorObjectName majorObjectName);
}
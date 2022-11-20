namespace SharpHorizons.Query.Origin;

using SharpHorizons.Identity;

/// <summary>Handles construction of <see cref="IOriginObject"/>.</summary>
public interface IOriginObjectFactory
{
    /// <summary>Describes the <see cref="IOriginObject"/> in a query as <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">This <see cref="MajorObject"/> represents the <see cref="IOriginObject"/> in a query.</param>
    public abstract IOriginObject Create(MajorObject majorObject);

    /// <summary>Describes the <see cref="IOriginObject"/> in a query as a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of a <see cref="MajorObject"/> which represents the <see cref="IOriginObject"/> in a query.</param>
    public abstract IOriginObject Create(MajorObjectID majorObjectID);

    /// <summary>Describes the <see cref="IOriginObject"/> in a query as a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of a <see cref="MajorObject"/> which represents the <see cref="IOriginObject"/> in a query.</param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the <see cref="MajorObject"/>, if known - as using the <see cref="MajorObjectName"/> can result in multiple matches.</remarks>
    public abstract IOriginObject Create(MajorObjectName majorObjectName);
}
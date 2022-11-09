namespace SharpHorizons.Query.Origin;

using SharpHorizons.Composers.Arguments.Origin;
using SharpHorizons.Identity;

/// <inheritdoc cref="IOriginObjectFactory"/>
internal sealed class OriginObjectFactory : IOriginObjectFactory
{
    /// <summary>Used to compose <see cref="OriginObjectIdentifier"/> that describe <see cref="MajorObject"/>.</summary>
    private IOriginObjectComposer<MajorObject> MajorObjectComposer { get; }

    /// <summary>Used to compose <see cref="OriginObjectIdentifier"/> that describe <see cref="MajorObjectID"/>.</summary>
    private IOriginObjectComposer<MajorObjectID> MajorObjectIDComposer { get; }

    /// <summary>Used to compose <see cref="OriginObjectIdentifier"/> that describe <see cref="MajorObjectName"/>.</summary>
    private IOriginObjectComposer<MajorObjectName> MajorObjectNameComposer { get; }

    /// <summary><inheritdoc cref="OriginObjectFactory" path="/summary"/></summary>
    /// <param name="majorObjectComposer"><inheritdoc cref="MajorObjectComposer" path="/summary"/></param>
    /// <param name="majorObjectIDComposer"><inheritdoc cref="MajorObjectIDComposer" path="/summary"/></param>
    /// <param name="majorObjectNameComposer"><inheritdoc cref="MajorObjectNameComposer" path="/summary"/></param>
    public OriginObjectFactory(IOriginObjectComposer<MajorObject>? majorObjectComposer = null, IOriginObjectComposer<MajorObjectID>? majorObjectIDComposer = null, IOriginObjectComposer<MajorObjectName>? majorObjectNameComposer = null)
    {
        majorObjectIDComposer ??= new MajorObjectIDComposer();

        MajorObjectComposer = majorObjectComposer ?? new MajorObjectComposer(majorObjectIDComposer);
        MajorObjectIDComposer = majorObjectIDComposer;
        MajorObjectNameComposer = majorObjectNameComposer ?? new MajorObjectNameComposer();
    }

    IOriginObject IOriginObjectFactory.Create(MajorObject majorObject) => new MajorObjectOrigin(majorObject, MajorObjectComposer);
    IOriginObject IOriginObjectFactory.Create(MajorObjectID majorObjectID) => new MajorObjectIDOrigin(majorObjectID, MajorObjectIDComposer);
    IOriginObject IOriginObjectFactory.Create(MajorObjectName majorObjectName) => new MajorObjectNameOrigin(majorObjectName, MajorObjectNameComposer);
}

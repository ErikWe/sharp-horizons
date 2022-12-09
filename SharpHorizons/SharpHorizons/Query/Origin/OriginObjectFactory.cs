namespace SharpHorizons.Query.Origin;

using SharpHorizons.Query.Arguments.Composers.Origin;

using System;

/// <inheritdoc cref="IOriginObjectFactory"/>
internal sealed class OriginObjectFactory : IOriginObjectFactory
{
    /// <summary>Used to compose <see cref="OriginObjectIdentifier"/> that describe <see cref="MajorObject"/>.</summary>
    private IOriginObjectComposer<MajorObject> MajorObjectComposer { get; }

    /// <summary>Used to compose <see cref="OriginObjectIdentifier"/> that describe <see cref="MajorObjectID"/>.</summary>
    private IOriginObjectComposer<MajorObjectID> MajorObjectIDComposer { get; }

    /// <summary>Used to compose <see cref="OriginObjectIdentifier"/> that describe <see cref="ObjectRadiiInterpretation"/>.</summary>
    private IOriginObjectComposer<ObjectRadiiInterpretation> MajorObjectNameComposer { get; }

    /// <inheritdoc cref="OriginObjectFactory"/>
    /// <param name="majorObjectComposer"><inheritdoc cref="MajorObjectComposer" path="/summary"/></param>
    /// <param name="majorObjectIDComposer"><inheritdoc cref="MajorObjectIDComposer" path="/summary"/></param>
    /// <param name="majorObjectNameComposer"><inheritdoc cref="MajorObjectNameComposer" path="/summary"/></param>
    public OriginObjectFactory(IOriginObjectComposer<MajorObject>? majorObjectComposer = null, IOriginObjectComposer<MajorObjectID>? majorObjectIDComposer = null, IOriginObjectComposer<ObjectRadiiInterpretation>? majorObjectNameComposer = null)
    {
        majorObjectIDComposer ??= new MajorObjectIDComposer();

        MajorObjectComposer = majorObjectComposer ?? new MajorObjectComposer(majorObjectIDComposer);
        MajorObjectIDComposer = majorObjectIDComposer;
        MajorObjectNameComposer = majorObjectNameComposer ?? new MajorObjectNameComposer();
    }

    IOriginObject IOriginObjectFactory.Create(MajorObject majorObject)
    {
        ArgumentNullException.ThrowIfNull(majorObject);

        return new MajorObjectOrigin(majorObject, MajorObjectComposer);
    }

    IOriginObject IOriginObjectFactory.Create(MajorObjectID majorObjectID) => new MajorObjectIDOrigin(majorObjectID, MajorObjectIDComposer);
    IOriginObject IOriginObjectFactory.Create(ObjectRadiiInterpretation majorObjectName)
    {
        ObjectRadiiInterpretation.Validate(majorObjectName);

        return new MajorObjectNameOrigin(majorObjectName, MajorObjectNameComposer);
    }
}

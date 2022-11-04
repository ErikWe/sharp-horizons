﻿namespace SharpHorizons.Query.Origin;

using SharpHorizons.Identification;

using System;

/// <summary>Composes <see cref="OriginObjectIdentifier"/> that describe <see cref="MajorObject"/>.</summary>
internal sealed class MajorObjectComposer : IOriginObjectComposer<MajorObject>
{
    /// <summary>Used to compose a <see cref="OriginObjectIdentifier"/> that describe the <see cref="MajorObjectID"/> associated with a <see cref="MajorObject"/>.</summary>
    private IOriginObjectComposer<MajorObjectID> MajorObjectIDComposer { get; }

    /// <summary><inheritdoc cref="MajorObjectComposer" path="/summary"/></summary>
    /// <param name="majorObjectIDComposer"><inheritdoc cref="MajorObjectIDComposer" path="/summary"/></param>
    public MajorObjectComposer(IOriginObjectComposer<MajorObjectID> majorObjectIDComposer)
    {
        MajorObjectIDComposer = majorObjectIDComposer;
    }

    OriginObjectIdentifier IOriginObjectComposer<MajorObject>.Compose(MajorObject obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return MajorObjectIDComposer.Compose(obj.ID);
    }
}

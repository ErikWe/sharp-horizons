﻿namespace SharpHorizons.Query.Arguments.Composers.Origin;

using SharpHorizons.Query.Origin;

/// <summary>Composes <see cref="OriginObjectIdentifier"/> that describe <see cref="MajorObjectName"/>.</summary>
internal sealed class MajorObjectNameComposer : IOriginObjectComposer<MajorObjectName>
{
    OriginObjectIdentifier IOriginObjectComposer<MajorObjectName>.Compose(MajorObjectName obj)
    {
        MajorObjectName.Validate(obj);

        return new(obj.Value);
    }
}

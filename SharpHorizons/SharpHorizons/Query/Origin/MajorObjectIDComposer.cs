﻿namespace SharpHorizons.Query.Origin;

using SharpHorizons.Identification;
using SharpHorizons.Query.Arguments;

using System.Globalization;

/// <summary>Composes <see cref="OriginObjectIdentifier"/> that describe <see cref="MajorObjectID"/>.</summary>
internal sealed class MajorObjectIDComposer : IOriginObjectComposer<MajorObjectID>
{
    OriginObjectIdentifier IOriginObjectComposer<MajorObjectID>.Compose(MajorObjectID obj) => obj.Value.ToString(CultureInfo.InvariantCulture);
}

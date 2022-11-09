namespace SharpHorizons.Composers.Arguments.Origin;

using SharpHorizons.Identity;
using SharpHorizons.Query.Origin;

/// <summary>Composes <see cref="OriginObjectIdentifier"/> that describe <see cref="MajorObjectName"/>.</summary>
internal sealed class MajorObjectNameComposer : IOriginObjectComposer<MajorObjectName>
{
    OriginObjectIdentifier IOriginObjectComposer<MajorObjectName>.Compose(MajorObjectName obj) => obj.Value;
}

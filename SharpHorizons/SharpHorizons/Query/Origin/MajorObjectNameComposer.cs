namespace SharpHorizons.Query.Origin;

using SharpHorizons.Identification;

/// <summary>Composes <see cref="OriginObjectIdentifier"/> that describe <see cref="MajorObjectName"/>.</summary>
internal sealed class MajorObjectNameComposer : IOriginObjectComposer<MajorObjectName>
{
    OriginObjectIdentifier IOriginObjectComposer<MajorObjectName>.Compose(MajorObjectName obj) => obj.Value;
}

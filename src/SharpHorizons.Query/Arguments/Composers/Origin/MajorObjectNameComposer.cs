namespace SharpHorizons.Query.Arguments.Composers.Origin;

using SharpHorizons.Query.Origin;

using System.Diagnostics.CodeAnalysis;

/// <summary>Composes <see cref="OriginObjectIdentifier"/> that describe <see cref="MajorObjectName"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class MajorObjectNameComposer : IOriginObjectComposer<MajorObjectName>
{
    OriginObjectIdentifier IOriginObjectComposer<MajorObjectName>.Compose(MajorObjectName obj)
    {
        MajorObjectName.Validate(obj);

        return new(obj.Value);
    }
}

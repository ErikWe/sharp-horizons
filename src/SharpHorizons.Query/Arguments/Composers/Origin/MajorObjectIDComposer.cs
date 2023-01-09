namespace SharpHorizons.Query.Arguments.Composers.Origin;

using SharpHorizons.Query.Origin;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

/// <summary>Composes <see cref="OriginObjectIdentifier"/> that describe <see cref="MajorObjectID"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class MajorObjectIDComposer : IOriginObjectComposer<MajorObjectID>
{
    OriginObjectIdentifier IOriginObjectComposer<MajorObjectID>.Compose(MajorObjectID obj) => new(obj.ToString(CultureInfo.InvariantCulture));
}

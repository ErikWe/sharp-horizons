namespace SharpHorizons.Composers.Arguments.Target;

using SharpHorizons.Identification;
using SharpHorizons.Query;
using SharpHorizons.Query.Target;

/// <summary>Composes <see cref="ITargetArgument"/> and <see cref="TargetSiteObjectIdentifier"/> that describe <see cref="MajorObjectName"/>.</summary>
internal sealed class MajorObjectNameComposer : ITargetComposer<MajorObjectName>, ITargetSiteObjectComposer<MajorObjectName>
{
    ITargetArgument IArgumentComposer<ITargetArgument, MajorObjectName>.Compose(MajorObjectName obj) => new QueryArgument(Compose(obj));
    TargetSiteObjectIdentifier ITargetSiteObjectComposer<MajorObjectName>.Compose(MajorObjectName obj) => Compose(obj);

    /// <summary>Composes a <see cref="string"/> describing <paramref name="name"/>.</summary>
    /// <param name="name">The composed <see cref="string"/> describes this <see cref="MajorObjectName"/>.</param>
    private static string Compose(MajorObjectName name) => name.Value;
}

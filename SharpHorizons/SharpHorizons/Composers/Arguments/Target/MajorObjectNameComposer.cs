namespace SharpHorizons.Composers.Arguments.Target;

using SharpHorizons.Identity;
using SharpHorizons.Query;
using SharpHorizons.Query.Target;

/// <summary>Composes <see cref="ICommandArgument"/> and <see cref="TargetSiteObjectIdentifier"/> that describe <see cref="MajorObjectName"/>.</summary>
internal sealed class MajorObjectNameComposer : ICommandComposer<MajorObjectName>, ITargetSiteObjectComposer<MajorObjectName>
{
    ICommandArgument IArgumentComposer<ICommandArgument, MajorObjectName>.Compose(MajorObjectName obj) => new QueryArgument(Compose(obj));
    TargetSiteObjectIdentifier ITargetSiteObjectComposer<MajorObjectName>.Compose(MajorObjectName obj) => Compose(obj);

    /// <summary>Composes a <see cref="string"/> describing <paramref name="name"/>.</summary>
    /// <param name="name">The composed <see cref="string"/> describes this <see cref="MajorObjectName"/>.</param>
    private static string Compose(MajorObjectName name) => name.Value;
}

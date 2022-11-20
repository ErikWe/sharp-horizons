namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.Identity;
using SharpHorizons.Query.Target;

using System.Globalization;

/// <summary>Composes <see cref="ITargetArgument"/> and <see cref="TargetSiteObjectIdentifier"/> that describe <see cref="MajorObjectID"/>.</summary>
internal sealed class MajorObjectIDComposer : ITargetComposer<MajorObjectID>, ITargetSiteObjectComposer<MajorObjectID>
{
    ITargetArgument IArgumentComposer<ITargetArgument, MajorObjectID>.Compose(MajorObjectID obj) => new QueryArgument(Compose(obj));
    ICommandArgument IArgumentComposer<ICommandArgument, MajorObjectID>.Compose(MajorObjectID obj) => ((IArgumentComposer<ITargetArgument, MajorObjectID>)this).Compose(obj);
    TargetSiteObjectIdentifier ITargetSiteObjectComposer<MajorObjectID>.Compose(MajorObjectID obj) => Compose(obj);

    /// <summary>Composes a <see cref="string"/> describing <paramref name="ID"/>.</summary>
    /// <param name="ID">The composed <see cref="string"/> describes this <see cref="MajorObjectID"/>.</param>
    private static string Compose(MajorObjectID ID) => ID.ToString(CultureInfo.InvariantCulture);
}

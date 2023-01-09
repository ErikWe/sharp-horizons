namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.Query.Target;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

/// <summary>Composes <see cref="ITargetArgument"/> and <see cref="TargetObjectIdentifier"/> that describe <see cref="MajorObjectID"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class MajorObjectIDComposer : ITargetComposer<MajorObjectID>, ITargetObjectComposer<MajorObjectID>
{
    ITargetArgument IArgumentComposer<ITargetArgument, MajorObjectID>.Compose(MajorObjectID obj) => new QueryArgument(Compose(obj));
    ICommandArgument IArgumentComposer<ICommandArgument, MajorObjectID>.Compose(MajorObjectID obj) => ((IArgumentComposer<ITargetArgument, MajorObjectID>)this).Compose(obj);
    TargetObjectIdentifier ITargetObjectComposer<MajorObjectID>.Compose(MajorObjectID obj) => new(Compose(obj));

    /// <summary>Composes a <see cref="string"/> describing <paramref name="ID"/>.</summary>
    /// <param name="ID">The composed <see cref="string"/> describes this <see cref="MajorObjectID"/>.</param>
    private static string Compose(MajorObjectID ID) => ID.ToString(CultureInfo.InvariantCulture);
}

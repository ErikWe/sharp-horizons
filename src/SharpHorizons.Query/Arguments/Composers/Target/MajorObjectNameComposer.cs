namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.Query.Target;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Composes <see cref="ITargetArgument"/> and <see cref="TargetObjectIdentifier"/> that describe <see cref="MajorObjectName"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class MajorObjectNameComposer : ITargetComposer<MajorObjectName>, ITargetObjectComposer<MajorObjectName>
{
    ITargetArgument IArgumentComposer<ITargetArgument, MajorObjectName>.Compose(MajorObjectName obj) => new QueryArgument(Compose(obj));
    ICommandArgument IArgumentComposer<ICommandArgument, MajorObjectName>.Compose(MajorObjectName obj) => ((IArgumentComposer<ITargetArgument, MajorObjectName>)this).Compose(obj);
    TargetObjectIdentifier ITargetObjectComposer<MajorObjectName>.Compose(MajorObjectName obj) => new(Compose(obj));

    /// <summary>Composes a <see cref="string"/> describing <paramref name="name"/>.</summary>
    /// <param name="name">The composed <see cref="string"/> describes this <see cref="MajorObjectName"/>.</param>
    /// <exception cref="ArgumentException"/>
    private static string Compose(MajorObjectName name)
    {
        MajorObjectName.Validate(name);

        return name.Value;
    }
}

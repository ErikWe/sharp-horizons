﻿namespace SharpHorizons.Query.Target;

using SharpHorizons.Composers;
using SharpHorizons.Identification;

/// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by a <see cref="MajorObjectName"/>.</summary>
internal sealed record class MajorObjectNameTarget : ITarget
{
    /// <summary>The <see cref="MajorObjectName"/> of an object, the center of which represents the <see cref="ITarget"/> in a query.</summary>
    private MajorObjectName Name { get; }

    /// <summary>Used to compose a <see cref="ITargetArgument"/> describing <see langword="this"/>.</summary>
    private ITargetComposer<MajorObjectName> Composer { get; }

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by <paramref name="name"/>.</summary>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    public MajorObjectNameTarget(MajorObjectName name, ITargetComposer<MajorObjectName> composer)
    {
        Name = name;

        Composer = composer;
    }

    ITargetArgument ITarget.ComposeArgument() => Composer.Compose(Name);
}

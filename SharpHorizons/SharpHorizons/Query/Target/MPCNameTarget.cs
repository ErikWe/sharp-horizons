namespace SharpHorizons.Query.Target;

using SharpHorizons.Identity;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by an <see cref="MPCName"/>.</summary>
internal sealed record class MPCNameTarget : ITarget
{
    /// <summary>The <see cref="MPCName"/> of an object, the center of which represents the <see cref="ITarget"/> in a query.</summary>
    public required MPCName Name { private get; init; }

    /// <summary>Used to compose a <see cref="ITargetArgument"/> describing <see langword="this"/>.</summary>
    public required ITargetComposer<MPCName> Composer { private get; init; }

    /// <inheritdoc cref="MPCNameTarget"/>
    public MPCNameTarget() { }

    /// <inheritdoc cref="MPCNameTarget"/>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public MPCNameTarget(MPCName name, ITargetComposer<MPCName> composer)
    {
        Name = name;

        Composer = composer;
    }

    ITargetArgument ITarget.ComposeArgument() => ((IArgumentComposer<ITargetArgument, MPCName>)Composer).Compose(Name);
}

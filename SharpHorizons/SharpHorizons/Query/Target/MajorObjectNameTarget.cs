namespace SharpHorizons.Query.Target;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <summary>Describes the <see cref="ITarget"/> in a query as the center of an object identified by a <see cref="ObjectRadiiInterpretation"/>.</summary>
internal sealed record class MajorObjectNameTarget : ITarget
{
    /// <summary>The <see cref="ObjectRadiiInterpretation"/> of an object, the center of which represents the <see cref="ITarget"/> in a query.</summary>
    public required ObjectRadiiInterpretation Name { private get; init; }

    /// <summary>Used to compose a <see cref="ITargetArgument"/> describing <see langword="this"/>.</summary>
    public required ITargetComposer<ObjectRadiiInterpretation> Composer { private get; init; }

    /// <inheritdoc cref="MajorObjectNameTarget"/>
    public MajorObjectNameTarget() { }

    /// <inheritdoc cref="MajorObjectNameTarget"/>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    /// <param name="composer"><inheritdoc cref="Composer" path="/summary"/></param>
    [SetsRequiredMembers]
    public MajorObjectNameTarget(ObjectRadiiInterpretation name, ITargetComposer<ObjectRadiiInterpretation> composer)
    {
        Name = name;

        Composer = composer;
    }

    ITargetArgument ITarget.ComposeArgument() => ((IArgumentComposer<ITargetArgument, ObjectRadiiInterpretation>)Composer).Compose(Name);
}

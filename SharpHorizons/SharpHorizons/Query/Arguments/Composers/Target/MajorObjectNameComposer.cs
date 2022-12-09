namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.Query.Target;

using System;

/// <summary>Composes <see cref="ITargetArgument"/> and <see cref="TargetSiteObjectIdentifier"/> that describe <see cref="ObjectRadiiInterpretation"/>.</summary>
internal sealed class MajorObjectNameComposer : ITargetComposer<ObjectRadiiInterpretation>, ITargetSiteObjectComposer<ObjectRadiiInterpretation>
{
    ITargetArgument IArgumentComposer<ITargetArgument, ObjectRadiiInterpretation>.Compose(ObjectRadiiInterpretation obj) => new QueryArgument(Compose(obj));
    ICommandArgument IArgumentComposer<ICommandArgument, ObjectRadiiInterpretation>.Compose(ObjectRadiiInterpretation obj) => ((IArgumentComposer<ITargetArgument, ObjectRadiiInterpretation>)this).Compose(obj);
    TargetSiteObjectIdentifier ITargetSiteObjectComposer<ObjectRadiiInterpretation>.Compose(ObjectRadiiInterpretation obj) => new(Compose(obj));

    /// <summary>Composes a <see cref="string"/> describing <paramref name="name"/>.</summary>
    /// <param name="name">The composed <see cref="string"/> describes this <see cref="ObjectRadiiInterpretation"/>.</param>
    /// <exception cref="ArgumentException"/>
    private static string Compose(ObjectRadiiInterpretation name)
    {
        ObjectRadiiInterpretation.Validate(name);

        return name.Value;
    }
}

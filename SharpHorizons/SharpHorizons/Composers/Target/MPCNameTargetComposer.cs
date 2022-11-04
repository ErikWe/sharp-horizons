namespace SharpHorizons.Composers.Target;

using SharpHorizons.Identification;
using SharpHorizons.Query;

/// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCName"/>.</summary>
internal sealed class MPCNameTargetComposer : ITargetComposer<MPCName>
{
    ITargetArgument IArgumentComposer<ITargetArgument, MPCName>.Compose(MPCName obj) => new QueryArgument($"{obj.Value};");
}

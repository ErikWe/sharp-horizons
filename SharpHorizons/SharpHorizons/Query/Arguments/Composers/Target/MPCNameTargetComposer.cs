namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.Identity;

/// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCName"/>.</summary>
internal sealed class MPCNameTargetComposer : ITargetComposer<MPCName>
{
    ITargetArgument IArgumentComposer<ITargetArgument, MPCName>.Compose(MPCName obj) => new QueryArgument($"{obj.Value};");
    ICommandArgument IArgumentComposer<ICommandArgument, MPCName>.Compose(MPCName obj) => ((IArgumentComposer<ITargetArgument, MPCName>)this).Compose(obj);
}

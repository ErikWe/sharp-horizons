namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.Identity;

/// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCCometName"/>.</summary>
internal sealed class MPCCometNameTargetComposer : ITargetComposer<MPCCometName>
{
    ITargetArgument IArgumentComposer<ITargetArgument, MPCCometName>.Compose(MPCCometName obj) => new QueryArgument($"{obj.Name};");
    ICommandArgument IArgumentComposer<ICommandArgument, MPCCometName>.Compose(MPCCometName obj) => ((IArgumentComposer<ITargetArgument, MPCCometName>)this).Compose(obj);
}

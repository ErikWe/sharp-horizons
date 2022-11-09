namespace SharpHorizons.Composers.Arguments.Target;

using SharpHorizons.Identity;
using SharpHorizons.Query;

/// <summary>Composes <see cref="ICommandArgument"/> that describe <see cref="MPCName"/>.</summary>
internal sealed class MPCNameTargetComposer : ICommandComposer<MPCName>
{
    ICommandArgument IArgumentComposer<ICommandArgument, MPCName>.Compose(MPCName obj) => new QueryArgument($"{obj.Value};");
}

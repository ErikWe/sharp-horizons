namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.MPC;

using System.Diagnostics.CodeAnalysis;

/// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCName"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class MPCNameTargetComposer : ITargetComposer<MPCName>
{
    ITargetArgument IArgumentComposer<ITargetArgument, MPCName>.Compose(MPCName obj)
    {
        MPCName.Validate(obj);

        return new QueryArgument($"{obj.Value};");
    }

    ICommandArgument IArgumentComposer<ICommandArgument, MPCName>.Compose(MPCName obj) => ((IArgumentComposer<ITargetArgument, MPCName>)this).Compose(obj);
}

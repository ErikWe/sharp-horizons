﻿namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.MPC;

using System.Diagnostics.CodeAnalysis;

/// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCCometName"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class MPCCometNameTargetComposer : ITargetComposer<MPCCometName>
{
    ITargetArgument IArgumentComposer<ITargetArgument, MPCCometName>.Compose(MPCCometName obj)
    {
        MPCCometName.Validate(obj);

        return new QueryArgument($"{obj.Value};");
    }

    ICommandArgument IArgumentComposer<ICommandArgument, MPCCometName>.Compose(MPCCometName obj) => ((IArgumentComposer<ITargetArgument, MPCCometName>)this).Compose(obj);
}

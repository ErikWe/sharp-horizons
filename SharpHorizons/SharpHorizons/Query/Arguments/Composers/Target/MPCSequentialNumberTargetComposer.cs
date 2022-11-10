﻿namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.Identity;

using System.Globalization;

/// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCSequentialNumber"/>.</summary>
internal sealed class MPCSequentialNumberTargetComposer : ITargetComposer<MPCSequentialNumber>
{
    ITargetArgument IArgumentComposer<ITargetArgument, MPCSequentialNumber>.Compose(MPCSequentialNumber obj) => new QueryArgument($"{obj.Value.ToString(CultureInfo.InvariantCulture)};");
    ICommandArgument IArgumentComposer<ICommandArgument, MPCSequentialNumber>.Compose(MPCSequentialNumber obj) => ((IArgumentComposer<ITargetArgument, MPCSequentialNumber>)this).Compose(obj);
}

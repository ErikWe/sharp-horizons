namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.MPC;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

/// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCSequentialNumber"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class MPCSequentialNumberTargetComposer : ITargetComposer<MPCSequentialNumber>
{
    ITargetArgument IArgumentComposer<ITargetArgument, MPCSequentialNumber>.Compose(MPCSequentialNumber obj) => new QueryArgument($"{obj.ToString(CultureInfo.InvariantCulture)};");
    ICommandArgument IArgumentComposer<ICommandArgument, MPCSequentialNumber>.Compose(MPCSequentialNumber obj) => ((IArgumentComposer<ITargetArgument, MPCSequentialNumber>)this).Compose(obj);
}

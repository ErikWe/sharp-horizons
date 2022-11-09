namespace SharpHorizons.Composers.Arguments.Target;

using SharpHorizons.Identity;
using SharpHorizons.Query;

using System.Globalization;

/// <summary>Composes <see cref="ICommandArgument"/> that describe <see cref="MPCSequentialNumber"/>.</summary>
internal sealed class MPCSequentialNumberTargetComposer : ICommandComposer<MPCSequentialNumber>
{
    ICommandArgument IArgumentComposer<ICommandArgument, MPCSequentialNumber>.Compose(MPCSequentialNumber obj) => new QueryArgument($"{obj.Value.ToString(CultureInfo.InvariantCulture)};");
}

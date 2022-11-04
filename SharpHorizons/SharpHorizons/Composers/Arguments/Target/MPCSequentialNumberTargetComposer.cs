namespace SharpHorizons.Composers.Arguments.Target;

using SharpHorizons.Identification;
using SharpHorizons.Query;

using System.Globalization;

/// <summary>Composes <see cref="ITargetArgument"/> that describe <see cref="MPCSequentialNumber"/>.</summary>
internal sealed class MPCSequentialNumberTargetComposer : ITargetComposer<MPCSequentialNumber>
{
    ITargetArgument IArgumentComposer<ITargetArgument, MPCSequentialNumber>.Compose(MPCSequentialNumber obj) => new QueryArgument($"{obj.Value.ToString(CultureInfo.InvariantCulture)};");
}

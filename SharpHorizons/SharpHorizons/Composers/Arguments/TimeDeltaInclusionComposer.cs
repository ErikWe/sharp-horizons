namespace SharpHorizons.Composers.Arguments;

using SharpHorizons.Query;

using System.ComponentModel;

/// <inheritdoc cref="ITimeDeltaInclusionComposer"/>
internal sealed class TimeDeltaInclusionComposer : ITimeDeltaInclusionComposer
{
    ITimeDeltaInclusionArgument IArgumentComposer<ITimeDeltaInclusionArgument, TimeDeltaInclusion>.Compose(TimeDeltaInclusion obj) => new QueryArgument(obj switch
    {
        TimeDeltaInclusion.Disable => "NO",
        TimeDeltaInclusion.Enable => "YES",
        _ => throw new InvalidEnumArgumentException(nameof(obj), (int)obj, typeof(TimeDeltaInclusion))
    });
}

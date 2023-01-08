namespace SharpHorizons.Query.Arguments.Composers;

/// <inheritdoc cref="ITimeDeltaInclusionComposer"/>
internal sealed class TimeDeltaInclusionComposer : ITimeDeltaInclusionComposer
{
    ITimeDeltaInclusionArgument IArgumentComposer<ITimeDeltaInclusionArgument, TimeDeltaInclusion>.Compose(TimeDeltaInclusion obj) => new QueryArgument(obj switch
    {
        TimeDeltaInclusion.Disable => "NO",
        TimeDeltaInclusion.Enable => "YES",
        _ => throw InvalidEnumArgumentExceptionFactory.Create(obj)
    });
}

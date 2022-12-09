namespace SharpHorizons.Query.Arguments.Composers;

/// <inheritdoc cref="ITimePrecisionComposer"/>
internal sealed class TimePrecisionComposer : ITimePrecisionComposer
{
    ITimePrecisionArgument IArgumentComposer<ITimePrecisionArgument, TimePrecision>.Compose(TimePrecision obj) => new QueryArgument(obj switch
    {
        TimePrecision.Unknown => throw ArgumentExceptionFactory.UnsupportedEnumValue(obj),
        TimePrecision.Minute => "M",
        TimePrecision.Second => "S",
        TimePrecision.Millisecond => "F",
        _ => throw InvalidEnumArgumentExceptionFactory.Create(obj)
    });
}

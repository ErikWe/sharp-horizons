namespace SharpHorizons.Query.Arguments.Composers;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="ITimePrecisionComposer"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
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

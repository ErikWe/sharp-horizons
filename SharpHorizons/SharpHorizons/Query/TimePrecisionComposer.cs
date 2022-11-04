namespace SharpHorizons.Query;

using SharpHorizons.Query.Arguments;

using System.ComponentModel;

/// <inheritdoc cref="ITimePrecisionComposer"/>
internal sealed class TimePrecisionComposer : ITimePrecisionComposer
{
    ITimePrecisionArgument IArgumentComposer<ITimePrecisionArgument, TimePrecision>.Compose(TimePrecision obj) => new QueryArgument(obj switch
    {
        TimePrecision.Minute => "M",
        TimePrecision.Second => "S",
        TimePrecision.Millisecond => "F",
        _ => throw new InvalidEnumArgumentException(nameof(obj), (int)obj, typeof(TimePrecision))
    });
}

namespace SharpHorizons.Query.Arguments.Composers.Epoch;

using SharpHorizons.Query.Epoch;

internal sealed class TimeSystemComposer : ITimeSystemComposer
{
    ITimeSystemArgument IArgumentComposer<ITimeSystemArgument, TimeSystem>.Compose(TimeSystem obj) => new QueryArgument(obj switch
    {
        TimeSystem.Unknown => throw ArgumentExceptionFactory.UnsupportedEnumValue(obj),
        TimeSystem.UT => "UT",
        TimeSystem.TT => "TT",
        TimeSystem.TDB => "TDB",
        _ => throw InvalidEnumArgumentExceptionFactory.Create(obj)
    });
}

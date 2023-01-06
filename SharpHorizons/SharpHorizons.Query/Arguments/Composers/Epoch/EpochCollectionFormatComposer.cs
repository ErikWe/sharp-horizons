namespace SharpHorizons.Query.Arguments.Composers.Epoch;

using SharpHorizons.Query.Epoch;

/// <summary>Composes <see cref="IEpochCollectionFormatArgument"/> that describe <see cref="EpochFormat"/>.</summary>
internal sealed class EpochCollectionFormatComposer : IEpochCollectionFormatComposer
{
    IEpochCollectionFormatArgument IArgumentComposer<IEpochCollectionFormatArgument, EpochFormat>.Compose(EpochFormat obj) => new QueryArgument(obj switch
    {
        EpochFormat.Unknown => throw ArgumentExceptionFactory.UnsupportedEnumValue(obj),
        EpochFormat.JulianDays => "JD",
        EpochFormat.ModifiedJulianDays => "MJD",
        EpochFormat.CalendarDates => "CAL",
        _ => throw InvalidEnumArgumentExceptionFactory.Create(obj)
    });
}

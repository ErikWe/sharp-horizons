namespace SharpHorizons.Query.Arguments;

using SharpHorizons.Calendars;

using System.ComponentModel;

/// <inheritdoc cref="IEpochCollectionFormatArgument"/>
internal sealed record class EpochCollectionFormatArgument : IEpochCollectionFormatArgument
{
    /// <inheritdoc/>
    public QueryArgument Value { get; }

    /// <summary><inheritdoc cref="EpochCollectionArgument" path="/summary"/></summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    private EpochCollectionFormatArgument(QueryArgument value)
    {
        Value = value;
    }

    /// <summary>Composes an <see cref="IEpochCollectionFormatArgument"/> describing <paramref name="epochCollectionFormat"/>.</summary>
    /// <param name="epochCollectionFormat">An <see cref="IEpochCollectionFormatArgument"/> is composed based on this <see cref="EpochCollectionFormat"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public static IEpochCollectionFormatArgument Compose(EpochCollectionFormat epochCollectionFormat) => new EpochCollectionFormatArgument(epochCollectionFormat switch
    {
        EpochCollectionFormat.JulianDays => "JD",
        EpochCollectionFormat.ModifiedJulianDays => "MJD",
        EpochCollectionFormat.CalendarDates => "CAL",
        _ => throw new InvalidEnumArgumentException(nameof(epochCollectionFormat), (int)epochCollectionFormat, typeof(EpochCollectionFormat))
    });
}
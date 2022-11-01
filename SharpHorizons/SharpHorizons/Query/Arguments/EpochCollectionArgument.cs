namespace SharpHorizons.Query.Arguments;

using SharpHorizons.Calendars;
using SharpHorizons.Query.Epoch;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

/// <inheritdoc cref="IEpochCollectionArgument"/>
internal sealed record class EpochCollectionArgument : IEpochCollectionArgument
{
    /// <inheritdoc/>
    public QueryArgument Value { get; }

    /// <summary><inheritdoc cref="EpochCollectionArgument" path="/summary"/></summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    private EpochCollectionArgument(QueryArgument value)
    {
        Value = value;
    }

    /// <summary>Composes an <see cref="IEpochCollectionArgument"/> describing <paramref name="epochCollection"/>, with the individual <see cref="IEpoch"/> formatted according to <paramref name="epochCollectionFormat"/>.</summary>
    /// <param name="epochCollection">An <see cref="IEpochCollectionArgument"/> is composed based on these <see cref="IEpoch"/>, with the individual <see cref="IEpoch"/> formatted according to <paramref name="epochCollectionFormat"/>.</param>
    /// <param name="epochCollectionFormat">The <see cref="EpochCollectionFormat"/> of the invididual <see cref="IEpoch"/> in <paramref name="epochCollection"/> in the composed <see cref="IEpochCollectionArgument"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public static IEpochCollectionArgument Compose(IEnumerable<IEpoch> epochCollection, EpochCollectionFormat epochCollectionFormat) => epochCollectionFormat switch
    {
        EpochCollectionFormat.JulianDays => ComposeWithDayNumbers(epochCollection, (epoch) => epoch.ToJulianDay().Day),
        EpochCollectionFormat.ModifiedJulianDays => ComposeWithDayNumbers(epochCollection, (epoch) => epoch.ToEpoch<ModifiedJulianDay>().Day),
        EpochCollectionFormat.CalendarDates => ComposeWithCalendarDates(epochCollection),
        _ => throw new InvalidEnumArgumentException(nameof(epochCollectionFormat), (int)epochCollectionFormat, typeof(EpochCollectionFormat))
    };

    /// <summary>Composes an <see cref="IEpochCollectionArgument"/> describing <paramref name="epochCollection"/>, with the individual <see cref="IEpoch"/> formatted according to the day numbers provided by <paramref name="dayNumberDelegate"/>.</summary>
    /// <param name="epochCollection">An <see cref="IEpochCollectionArgument"/> is composed based on these <see cref="IEpoch"/>, with the individual <see cref="IEpoch"/> formatted according to the day numbers provided by <paramref name="dayNumberDelegate"/>.</param>
    /// <param name="dayNumberDelegate">Extracts a <see cref="double"/> representing the day number of an <see cref="IEpoch"/>, in some day-number-based calendar.</param>
    private static IEpochCollectionArgument ComposeWithDayNumbers(IEnumerable<IEpoch> epochCollection, Func<IEpoch, double> dayNumberDelegate)
    {
        StringBuilder builder = new();

        foreach (var epoch in epochCollection)
        {
            if (builder.Length > 0)
            {
                builder.Append(',');
            }

            builder.Append(CultureInfo.InvariantCulture, $"{dayNumberDelegate(epoch).ToString("F9", CultureInfo.InvariantCulture)}");
        }

        return new EpochCollectionArgument(builder.ToString());
    }

    /// <summary>Composes an <see cref="IEpochCollectionArgument"/> describing <paramref name="epochCollection"/>, with the individual <see cref="IEpoch"/> formatted as calendar dates.</summary>
    /// <param name="epochCollection">An <see cref="IEpochCollectionArgument"/> is composed based on these <see cref="IEpoch"/>, with the individual <see cref="IEpoch"/> formatted as calendar dates.</param>
    /// <remarks><see cref="IEpoch"/> prior to the <see cref="GregorianCalendarEpoch"/> { October 15th, 1582 CE 0:00:00 } are formatted as <see cref="JulianCalendarEpoch"/>, and later <see cref="IEpoch"/> are formatted as <see cref="GregorianCalendarEpoch"/>.</remarks>
    private static IEpochCollectionArgument ComposeWithCalendarDates(IEnumerable<IEpoch> epochCollection)
    {
        StringBuilder builder = new();

        foreach (var epoch in epochCollection)
        {
            var (Year, Month, Day, Hour, Minute, Second) = formatEpoch(epoch);

            var era = Year < 0 ? "BC" : "AD";
            var year = Year.ToString(CultureInfo.InvariantCulture);
            var month = Month.ToString();
            var day = Day.ToString(CultureInfo.InvariantCulture);
            var hour = Hour.ToString(CultureInfo.InvariantCulture);
            var minute = Minute.ToString(CultureInfo.InvariantCulture);
            var second = Second.ToString("F4", CultureInfo.InvariantCulture);

            builder.Append(CultureInfo.InvariantCulture, $"'{era} {year} {month} {day} {hour}:{minute}:{second}'");
        }

        return new EpochCollectionArgument(builder.ToString());

        static (int Year, JulianCalendarMonth Month, int Day, int Hour, int Minute, double Second) formatEpoch(IEpoch epoch) 
        {
            if (epoch.ToJulianDay().Day < 2299160.5)
            {
                var julianDate = epoch.ToEpoch<JulianCalendarEpoch>();

                return (julianDate.Year, julianDate.Month, julianDate.Day, julianDate.Hour, julianDate.Minute, julianDate.Second);
            }

            var gregorianDate = epoch.ToEpoch<GregorianCalendarEpoch>();

            return (gregorianDate.Year, gregorianDate.Month, gregorianDate.Day, gregorianDate.Hour, gregorianDate.Minute, gregorianDate.Second);
        }
    }
}
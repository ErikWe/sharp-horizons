namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Calendars;
using SharpHorizons.Query.Arguments;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

/// <summary>Composes <see cref="IEpochCollectionArgument"/> that describe <see cref="IEpochCollection"/>.</summary>
internal sealed class EpochCollectionComposer : IEpochCollectionComposer<IEpochCollection>
{
    IEpochCollectionArgument IArgumentComposer<IEpochCollectionArgument, IEpochCollection>.Compose(IEpochCollection obj)
    {
        ArgumentNullException.ThrowIfNull(obj);

        return new QueryArgument(Compose(obj));
    }

    /// <summary>Composes a <see cref="string"/> describing <paramref name="epochCollection"/>.</summary>
    /// <param name="epochCollection">The composed <see cref="string"/> describes this <see cref="IEpochCollection"/>.</param>
    /// <exception cref="NotSupportedException"></exception>
    private static string Compose(IEpochCollection epochCollection) => epochCollection.Format switch
    {
        EpochCollectionFormat.JulianDays => ComposeWithDayNumbers(epochCollection, (epoch) => epoch.ToJulianDay().Day),
        EpochCollectionFormat.ModifiedJulianDays => ComposeWithDayNumbers(epochCollection, (epoch) => epoch.ToEpoch<ModifiedJulianDay>().Day),
        EpochCollectionFormat.CalendarDates => ComposeWithCalendarDates(epochCollection),
        _ => throw new NotSupportedException($"{epochCollection.Format} was not of a supported {typeof(EpochCollectionFormat).FullName}.")
    };

    /// <summary>Composes a <see cref="string"/> describing <paramref name="epochCollection"/>, with the individual <see cref="IEpoch"/> formatted according to the day numbers provided by <paramref name="dayNumberDelegate"/>.</summary>
    /// <param name="epochCollection">The composed <see cref="string"/> describes these <see cref="IEpoch"/>, with the individual <see cref="IEpoch"/> formatted according to the day numbers provided by <paramref name="dayNumberDelegate"/>.</param>
    /// <param name="dayNumberDelegate">Extracts a <see cref="double"/> representing the day number of an <see cref="IEpoch"/>, in some day-number-based calendar.</param>
    private static string ComposeWithDayNumbers(IEnumerable<IEpoch> epochCollection, Func<IEpoch, double> dayNumberDelegate)
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

        return builder.ToString();
    }

    /// <summary>Composes a <see cref="string"/> describing <paramref name="epochCollection"/>, with the individual <see cref="IEpoch"/> formatted as calendar dates.</summary>
    /// <param name="epochCollection">The composed <see cref="string"/> describes these <see cref="IEpoch"/>, with the individual <see cref="IEpoch"/> formatted as calendar dates.</param>
    /// <remarks><see cref="IEpoch"/> prior to the <see cref="GregorianCalendarEpoch"/> { October 15th, 1582 CE 0:00:00 } are formatted as <see cref="JulianCalendarEpoch"/>, and later <see cref="IEpoch"/> are formatted as <see cref="GregorianCalendarEpoch"/>.</remarks>
    private static string ComposeWithCalendarDates(IEnumerable<IEpoch> epochCollection)
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

        return builder.ToString();

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

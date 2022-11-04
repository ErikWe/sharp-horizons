namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;

using System;

/// <summary>Composes <see cref="IEpochCollectionFormatArgument"/> that describe <see cref="EpochCollectionFormat"/>.</summary>
internal sealed class EpochCollectionFormatComposer : IEpochCollectionFormatComposer
{
    IEpochCollectionFormatArgument IArgumentComposer<IEpochCollectionFormatArgument, EpochCollectionFormat>.Compose(EpochCollectionFormat obj)
    {
        return new QueryArgument(Compose(obj));
    }

    /// <summary>Composes a <see cref="string"/> describing <paramref name="epochCollectionFormat"/>.</summary>
    /// <param name="epochCollectionFormat">The composed <see cref="string"/> describes this <see cref="EpochCollectionFormat"/>.</param>
    /// <exception cref="NotSupportedException"></exception>
    private static string Compose(EpochCollectionFormat epochCollectionFormat) => epochCollectionFormat switch
    {
        EpochCollectionFormat.JulianDays => "JD",
        EpochCollectionFormat.ModifiedJulianDays => "MJD",
        EpochCollectionFormat.CalendarDates => "CAL",
        _ => throw new NotSupportedException($"{epochCollectionFormat} was not of a supported {typeof(EpochCollectionFormat).FullName}.")
    };
}

namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;
using SharpHorizons.Query.Arguments.Composers.Epoch;

using SharpMeasures;

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

/// <inheritdoc cref="IEpochRangeFactory"/>
internal sealed class SimpleEpochRangeFactory : IEpochRangeFactory
{
    /// <summary>Composes <see cref="IStartEpochArgument"/> that describe <see cref="IEpoch"/>.</summary>
    private IStartEpochComposer<IEpochRange> StartEpochComposer { get; }

    /// <summary>Composes <see cref="IStopEpochArgument"/> that describe <see cref="IEpoch"/>.</summary>
    private IStopEpochComposer<IEpochRange> StopEpochComposer { get; }

    /// <summary>The <see cref="EpochFormat"/> of the constructed <see cref="IEpochRange"/>.</summary>
    private EpochFormat Format { get; set; }

    /// <summary>The <see cref="CalendarType"/> of the constructed <see cref="IEpochRange"/>.</summary>
    private CalendarType Calendar { get; set; }

    /// <summary>The <see cref="TimeSystem"/> of the constructed <see cref="IEpochRange"/>.</summary>
    private TimeSystem TimeSystem { get; set; }

    /// <summary>The <see cref="Time"/> offset to UTC of the constructed <see cref="IEpochRange"/>.</summary>
    private Time UTCOffset { get; set; }

    /// <inheritdoc cref="SimpleEpochRangeFactory"/>
    /// <param name="startEpochComposer"><inheritdoc cref="StartEpochComposer" path="/summary"/></param>
    /// <param name="stopEpochComposer"><inheritdoc cref="StopEpochComposer" path="/summary"/></param>
    public SimpleEpochRangeFactory(IStartEpochComposer<IEpochRange>? startEpochComposer = null, IStopEpochComposer<IEpochRange>? stopEpochComposer = null)
    {
        EpochRangeEpochComposer? defaultEpochComposer = null;

        if (startEpochComposer is null || stopEpochComposer is null)
        {
            defaultEpochComposer = new EpochRangeEpochComposer();
        }

        StartEpochComposer = startEpochComposer ?? defaultEpochComposer!;
        StopEpochComposer = stopEpochComposer ?? defaultEpochComposer!;
    }

    IEpochRange IEpochRangeFactory.Create(IEpoch startEpoch, IEpoch stopEpoch, IStepSize stepSize)
    {
        ArgumentNullException.ThrowIfNull(startEpoch);
        ArgumentNullException.ThrowIfNull(stopEpoch);
        ArgumentNullException.ThrowIfNull(stepSize);

        if (startEpoch.CompareTo(stopEpoch) >= 0)
        {
            throw new ArgumentException($"The {nameof(startEpoch)} should represent a later {nameof(IEpoch)} than the {nameof(stopEpoch)}.");
        }

        return new EpochRange(new EphemerisBoundaryEpoch(startEpoch), new EphemerisBoundaryEpoch(stopEpoch), stepSize, StartEpochComposer, StopEpochComposer)
        {
            Format = Format,
            Calendar = Calendar,
            TimeSystem = TimeSystem,
            UTCOffset = UTCOffset
        };
    }

    IEpochRangeFactory IEpochRangeFactory.WithFormat(EpochFormat format)
    {
        ValidateFormat(format);

        Format = format;

        return this;
    }

    IEpochRangeFactory IEpochRangeFactory.WithCalendar(CalendarType calendar)
    {
        ValidateCalendar(calendar);

        Calendar = calendar;

        return this;
    }

    IEpochRangeFactory IEpochRangeFactory.WithTimeSystem(TimeSystem timeSystem)
    {
        ValidateTimeSystem(timeSystem);

        TimeSystem = timeSystem;

        return this;
    }

    IEpochRangeFactory IEpochRangeFactory.WithUTCOffset(Time utcOffset)
    {
        ValidateUTCOffset(utcOffset);

        UTCOffset = utcOffset;

        return this;
    }

    /// <summary>Validates the <see cref="EpochFormat"/> <paramref name="format"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="format">This <see cref="EpochFormat"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="format"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void ValidateFormat(EpochFormat format, [CallerArgumentExpression(nameof(format))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(format, argumentExpression);

        if (format is EpochFormat.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(format, argumentExpression);
        }
    }

    /// <summary>Validates the <see cref="CalendarType"/> <paramref name="calendar"/>, throwing an <see cref="InvalidEnumArgumentException"/> if invalid.</summary>
    /// <param name="calendar">This <see cref="CalendarType"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="calendar"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void ValidateCalendar(CalendarType calendar, [CallerArgumentExpression(nameof(calendar))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(calendar, argumentExpression);

        if (calendar is CalendarType.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(calendar, argumentExpression);
        }
    }

    /// <summary>Validates the <see cref="Epoch.TimeSystem"/> <paramref name="timeSystem"/>, throwing an <see cref="InvalidEnumArgumentException"/> if invalid.</summary>
    /// <param name="timeSystem">This <see cref="Epoch.TimeSystem"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="timeSystem"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void ValidateTimeSystem(TimeSystem timeSystem, [CallerArgumentExpression(nameof(timeSystem))] string? argumentExpression = null)
    {
        InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(timeSystem, argumentExpression);

        if (timeSystem is TimeSystem.Unknown)
        {
            throw ArgumentExceptionFactory.UnsupportedEnumValue(timeSystem, argumentExpression);
        }
    }

    /// <summary>Validates the <see cref="Time"/> <paramref name="utcOffset"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="utcOffset">This <see cref="Time"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="utcOffset"/>.</param>
    /// <exception cref="ArgumentException"/>
    private static void ValidateUTCOffset(Time utcOffset, [CallerArgumentExpression(nameof(utcOffset))] string? argumentExpression = null)
    {
        SharpMeasuresValidation.Validate(utcOffset, argumentExpression);
    }
}

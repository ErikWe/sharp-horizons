namespace SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Describes a <see cref="IEpoch"/> that is part of a query.</summary>
public sealed record class QueryEpoch
{
    /// <summary>The <see cref="IEpoch"/>.</summary>
    /// <exception cref="ArgumentNullException"/>
    public required IEpoch Epoch
    {
        get => epochField;
        init
        {
            ValidateEpoch(value);

            epochField = value;
        }
    }

    /// <summary>The <see cref="EpochFormat"/> of the <see cref="IEpoch"/> in a query.</summary>
    /// <exception cref="InvalidEnumArgumentException"/>
    public EpochFormat Format
    {
        get => formatField;
        init
        {
            ValidateEpochFormat(value);

            formatField = value;
        }
    }

    /// <summary>The <see cref="CalendarType"/> used to express the <see cref="IEpoch"/> in a query.</summary>
    /// <exception cref="InvalidEnumArgumentException"/>
    public CalendarType Calendar
    {
        get => calendarField;
        init
        {
            ValidateCalendarType(value);

            calendarField = value;
        }
    }

    /// <summary>The <see cref="Epoch.TimeSystem"/> used to express the <see cref="IEpoch"/> in a query.</summary>
    /// <exception cref="InvalidEnumArgumentException"/>
    public TimeSystem TimeSystem
    {
        get => timeSystemField;
        init
        {
            ValidateTimeSystem(value);

            timeSystemField = value;
        }
    }

    /// <summary>The <see cref="Time"/> offset to UTC used to express the <see cref="IEpoch"/> in a query.</summary>
    /// <exception cref="ArgumentException"/>
    public Time Offset
    {
        get => offsetField;
        init
        {
            Validate(value);

            offsetField = value;
        }
    }

    /// <inheritdoc cref="QueryEpoch"/>
    public QueryEpoch() { }

    /// <inheritdoc cref="QueryEpoch"/>
    /// <param name="epoch"><inheritdoc cref="Epoch" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    [SetsRequiredMembers]
    public QueryEpoch(IEpoch epoch)
    {
        ArgumentNullException.ThrowIfNull(epoch);

        Epoch = epoch;
    }

    /// <summary>Backing field for <see cref="Epoch"/>. Should not be used elsewhere.</summary>
    private readonly IEpoch epochField = null!;
    /// <summary>Backing field for <see cref="Format"/>. Should not be used elsewhere.</summary>
    private readonly EpochFormat formatField = EpochFormat.JulianDays;
    /// <summary>Backing field for <see cref="Calendar"/>. Should not be used elsewhere.</summary>
    private readonly CalendarType calendarField = CalendarType.Mixed;
    /// <summary>Backing field for <see cref="TimeSystem"/>. Should not be used elsewhere.</summary>
    private readonly TimeSystem timeSystemField = TimeSystem.UT;
    /// <summary>Backing field for <see cref="Time"/>. Should not be used elsewhere.</summary>
    private readonly Time offsetField = Time.Zero;

    /// <summary>Validates that the <see cref="IEpoch"/> <paramref name="epoch"/> can represent the <see cref="Epoch"/>, throwing an <see cref="ArgumentNullException"/> otherwise.</summary>
    /// <param name="epoch">This <see cref="IEpoch"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="epoch"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    private static void ValidateEpoch(IEpoch epoch, [CallerArgumentExpression(nameof(epoch))] string? argumentExpression = null) => ArgumentNullException.ThrowIfNull(epoch, argumentExpression);

    /// <summary>Validates that the <see cref="EpochFormat"/> <paramref name="format"/> can represent the <see cref="Format"/>, throwing an <see cref="InvalidEnumArgumentException"/> otherwise.</summary>
    /// <param name="format">This <see cref="EpochFormat"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="format"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void ValidateEpochFormat(EpochFormat format, [CallerArgumentExpression(nameof(format))] string? argumentExpression = null) => InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(format, argumentExpression);

    /// <summary>Validates that the <see cref="CalendarType"/> <paramref name="calendar"/> can represent the <see cref="Calendar"/>, throwing an <see cref="InvalidEnumArgumentException"/> otherwise.</summary>
    /// <param name="calendar">This <see cref="CalendarType"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="calendar"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void ValidateCalendarType(CalendarType calendar, [CallerArgumentExpression(nameof(calendar))] string? argumentExpression = null) => InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(calendar, argumentExpression);

    /// <summary>Validates that the <see cref="Epoch.TimeSystem"/> <paramref name="timeSystem"/> can represent the <see cref="TimeSystem"/>, throwing an <see cref="InvalidEnumArgumentException"/> otherwise.</summary>
    /// <param name="timeSystem">This <see cref="Epoch.TimeSystem"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="timeSystem"/>.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    private static void ValidateTimeSystem(TimeSystem timeSystem, [CallerArgumentExpression(nameof(timeSystem))] string? argumentExpression = null) => InvalidEnumArgumentExceptionUtility.ThrowIfUnlisted(timeSystem, argumentExpression);

    /// <summary>Validates that the <see cref="Time"/> <paramref name="offset"/> can represent the <see cref="Offset"/>, throwing an <see cref="ArgumentException"/> otherwise.</summary>
    /// <param name="offset">This <see cref="Time"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="offset"/>.</param>
    /// <exception cref="ArgumentException"/>
    private static void Validate(Time offset, [CallerArgumentExpression(nameof(offset))] string? argumentExpression = null) => SharpMeasuresValidation.Validate(offset, argumentExpression);
}

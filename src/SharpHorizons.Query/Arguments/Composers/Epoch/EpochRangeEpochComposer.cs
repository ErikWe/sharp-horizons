namespace SharpHorizons.Query.Arguments.Composers.Epoch;

using SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>Composes <see cref="IStartEpochArgument"/> and <see cref="IStopEpochArgument"/> that describe <see cref="IEpochRange"/>.</summary>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class EpochRangeEpochComposer : IStartEpochComposer<IEpochRange>, IStopEpochComposer<IEpochRange>
{
    /// <inheritdoc cref="IQueryEpochComposer"/>
    private IQueryEpochComposer QueryEpochComposer { get; }

    /// <inheritdoc cref="EpochCalendarComposer"/>
    /// <param name="queryEpochComposer"><inheritdoc cref="QueryEpochComposer" path="/summary"/></param>
    public EpochRangeEpochComposer(IQueryEpochComposer? queryEpochComposer = null)
    {
        QueryEpochComposer = queryEpochComposer ?? new QueryEpochComposer();
    }

    IStartEpochArgument IArgumentComposer<IStartEpochArgument, IEpochRange>.Compose(IEpochRange obj)
    {
        ValidateStartEpoch(obj);

        return new QueryArgument(Compose(obj, obj.StartEpoch.Epoch));
    }

    IStopEpochArgument IArgumentComposer<IStopEpochArgument, IEpochRange>.Compose(IEpochRange obj)
    {
        ValidateStopEpoch(obj);

        return new QueryArgument(Compose(obj, obj.StopEpoch.Epoch));
    }

    /// <summary>Composes a <see cref="string"/> describing <paramref name="epoch"/>.</summary>
    /// <param name="epochRange">Provides the <see cref="EpochFormat"/> and related information about how to compose the <see cref="string"/>.</param>
    /// <param name="epoch">The composed <see cref="string"/> describes this <see cref="IEpoch"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidOperationException"/>
    private string Compose(IEpochRange epochRange, IEpoch epoch)
    {
        try
        {
            return Compose(epoch, epochRange.Format, epochRange.Calendar, epochRange.TimeSystem, epochRange.Offset);
        }
        catch (ArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<IEpochRange>(nameof(epochRange), e);
        }
    }

    /// <summary>Composes a <see cref="string"/> describing <paramref name="epoch"/>.</summary>
    /// <param name="epoch">The composed <see cref="string"/> describes this <see cref="IEpoch"/>.</param>
    /// <param name="format">The <see cref="EpochFormat"/> of the <paramref name="epoch"/>.</param>
    /// <param name="calendar">The <see cref="CalendarType"/> used to express the <paramref name="epoch"/>.</param>
    /// <param name="timeSystem">The <see cref="TimeSystem"/> in which the adjusted <see cref="IEpoch"/> is expressed in, with some <paramref name="offset"/>.</param>
    /// <param name="offset">The <see cref="Time"/> offset from <paramref name="timeSystem"/> of the adjusted <see cref="IEpoch"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    /// <exception cref="InvalidOperationException"/>
    private string Compose(IEpoch epoch, EpochFormat format, CalendarType calendar, TimeSystem timeSystem, Time offset)
    {
        QueryEpoch queryEpoch = new(epoch) { Format = format, Calendar = calendar, TimeSystem = timeSystem, Offset = offset };

        var formattedEpoch = Compose(queryEpoch);

        if (format is EpochFormat.JulianDays)
        {
            formattedEpoch = $"JD{formattedEpoch}";
        }

        return formattedEpoch;
    }

    /// <summary>Composes a <see cref="string"/> describing <paramref name="queryEpoch"/>.</summary>
    /// <param name="queryEpoch">The composed <see cref="string"/> describes this <see cref="QueryEpoch"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidOperationException"/>
    private string Compose(QueryEpoch queryEpoch)
    {
        var composed = QueryEpochComposer.Compose(queryEpoch);

        if (string.IsNullOrEmpty(composed))
        {
            throw new InvalidOperationException($"The {nameof(IQueryEpochComposer)} provided an invalid {nameof(String)}.");
        }

        return composed;
    }

    /// <summary>Validate the <see cref="IEpochRange.StartEpoch"/> of the <see cref="IEpochRange"/> <paramref name="epochRange"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="epochRange">This <see cref="IEpochRange"/> is validated, together with the <see cref="IStartEpoch"/> of the <see cref="IEpochRange"/>.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="epochRange"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void ValidateStartEpoch(IEpochRange epochRange, [CallerArgumentExpression(nameof(epochRange))] string? argumentExpression = null)
    {
        ArgumentNullException.ThrowIfNull(epochRange, argumentExpression);

        try
        {
            Validate(epochRange.StartEpoch);
        }
        catch (ArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<IEpochRange>(argumentExpression, e);
        }
    }

    /// <summary>Validates the <see cref="IEpochRange.StopEpoch"/> of the <see cref="IEpochRange"/> <paramref name="epochRange"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="epochRange">This <see cref="IEpochRange"/> is validated, together with the <see cref="IStopEpoch"/> of the <see cref="IEpochRange"/>.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="epochRange"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void ValidateStopEpoch(IEpochRange epochRange, [CallerArgumentExpression(nameof(epochRange))] string? argumentExpression = null)
    {
        ArgumentNullException.ThrowIfNull(epochRange, argumentExpression);

        try
        {
            Validate(epochRange.StopEpoch);
        }
        catch (ArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<IEpochRange>(argumentExpression, e);
        }
    }

    /// <summary>Validates the <see cref="IStartEpoch"/> <paramref name="startEpoch"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="startEpoch">This <see cref="IStartEpoch"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="startEpoch"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void Validate(IStartEpoch startEpoch, [CallerArgumentExpression(nameof(startEpoch))] string? argumentExpression = null)
    {
        ArgumentNullException.ThrowIfNull(startEpoch, argumentExpression);

        try
        {
            ArgumentNullException.ThrowIfNull(startEpoch.Epoch);
        }
        catch (ArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<IStartEpoch>(argumentExpression, e);
        }
    }

    /// <summary>Validates the <see cref="IStopEpoch"/> <paramref name="stopEpoch"/>, throwing an <see cref="ArgumentException"/> if invalid.</summary>
    /// <param name="stopEpoch">This <see cref="IStopEpoch"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="stopEpoch"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    private static void Validate(IStopEpoch stopEpoch, [CallerArgumentExpression(nameof(stopEpoch))] string? argumentExpression = null)
    {
        ArgumentNullException.ThrowIfNull(stopEpoch, argumentExpression);

        try
        {
            ArgumentNullException.ThrowIfNull(stopEpoch.Epoch);
        }
        catch (ArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<IStartEpoch>(argumentExpression, e);
        }
    }
}

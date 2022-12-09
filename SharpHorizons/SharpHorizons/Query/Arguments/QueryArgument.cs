namespace SharpHorizons.Query.Arguments;

using System;
using System.Runtime.CompilerServices;

/// <inheritdoc cref="IQueryArgument"/>
internal sealed record class QueryArgument : IQueryArgument, ICommandArgument, IElementLabelsArgument, IEphemerisTypeArgument, ICalendarTypeArgument, IEpochCollectionArgument, IEpochCollectionFormatArgument, IGenerateEphemeridesArgument,
    IObjectDataInclusionArgument, IOriginArgument, IOriginCoordinateArgument, IOriginCoordinateTypeArgument, IOutputFormatArgument, IOutputUnitsArgument, IReferencePlaneArgument, IReferenceSystemArgument,
    IStartEpochArgument, IStepSizeArgument, IStopEpochArgument, ITargetArgument, ITimeDeltaInclusionArgument, ITimePrecisionArgument, ITimeSystemArgument, ITimeZoneArgument, IValueSeparationArgument, IVectorCorrectionArgument, IVectorLabelsArgument, IVectorTableContentArgument
{
    public string Value { get; }

    /// <inheritdoc cref="QueryArgument"/>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    public QueryArgument(string value)
    {
        Value = value;
    }

    /// <summary>Validates the <see cref="IQueryArgument"/> <paramref name="argument"/>, and throws an <see cref="ArgumentException"/> if invalid.</summary>
    /// <typeparam name="TArgument">The type of the validated <see cref="IQueryArgument"/>, <paramref name="argument"/>.</typeparam>
    /// <param name="argument">This <see cref="IQueryArgument"/> is validated.</param>
    /// <param name="argumentExpression">The expression used as the argument for <paramref name="argument"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public static void Validate<TArgument>(TArgument argument, [CallerArgumentExpression(nameof(argument))] string? argumentExpression = null) where TArgument : IQueryArgument
    {
        ArgumentNullException.ThrowIfNull(argument, argumentExpression);

        try
        {
            ArgumentException.ThrowIfNullOrEmpty(argument.Value);
        }
        catch (ArgumentException e)
        {
            throw ArgumentExceptionFactory.InvalidState<TArgument>(argumentExpression, e);
        }
    }
}
namespace SharpHorizons.Composers.Arguments;

using System;

/// <summary>Describes the value of a parameter in a query.</summary>
internal sealed record class QueryArgument : IQueryArgument, IEphemerisTypeArgument, IEpochCollectionArgument, IEpochCollectionFormatArgument, IGenerateEphemeridesArgument, IObjectDataInclusionArgument, IOriginArgument,
    IOriginCoordinateArgument, IOriginCoordinateTypeArgument, IOutputFormatArgument, IOutputLabelsArgument, IOutputUnitsArgument, IReferencePlaneArgument, IReferenceSystemArgument, IStartEpochArgument, IStepSizeArgument,
    IStopEpochArgument, ITargetArgument, ITimeDeltaInclusionArgument, ITimePrecisionArgument, IVectorCorrectionArgument, IVectorTableContentArgument
{
    /// <summary>The value of a parameter in a query.</summary>
    public string Value { get; }

    /// <summary>Uses { <paramref name="value"/> } to describe the value of a parameter in a query.</summary>
    /// <param name="value"><inheritdoc cref="Value" path="/summary"/></param>
    public QueryArgument(string value)
    {
        Value = value;
    }

    /// <summary>Retrieves the identifier represented by <see langword="this"/>.</summary>
    public override string ToString() => Value;
    /// <summary>Retrieves the identifier represented by <see langword="this"/>, formatted according to <paramref name="provider"/>.</summary>
    /// <param name="provider">Provides culture-specific formatting information.</param>
    public string ToString(IFormatProvider? provider) => Value.ToString(provider);

    /// <inheritdoc cref="QueryArgument(string)"/>
    public static implicit operator QueryArgument(string value) => new(value);

    /// <summary>Retrieves the identifier represented by <paramref name="identifier"/>.</summary>
    /// <param name="identifier"><inheritdoc cref="QueryArgument" path="/summary"/></param>
    public static implicit operator string(QueryArgument identifier) => identifier.Value;
}
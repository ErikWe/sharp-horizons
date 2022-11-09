namespace SharpHorizons.Composers.Parameters;

/// <inheritdoc cref="ICommandParameterIdentifier"/>
internal sealed record class CommandParameterIdentifier : ICommandParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "COMMAND";
}

/// <inheritdoc cref="IElementLabelsParameterIdentifier"/>
internal sealed record class ElementLabelsParameterIdentifier : IElementLabelsParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "ELM_LABELS";
}

/// <inheritdoc cref="IEphemerisTypeParameterIdentifier"/>
internal sealed record class EphemerisTypeParameterIdentifier : IEphemerisTypeParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "EPHEM_TYPE";
}

/// <inheritdoc cref="IEpochCollectionParameterIdentifier"/>
internal sealed record class EpochCollectionParameterIdentifier : IEpochCollectionParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "TLIST";
}

/// <inheritdoc cref="IEpochCollectionParameterIdentifier"/>
internal sealed record class EpochCollectionFormatParameterIdentifier : IEpochCollectionFormatParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "TLIST_TYPE";
}

/// <inheritdoc cref="IGenerateEphemeridesParameterIdentifier"/>
internal sealed record class GenerateEphemeridesParameterIdentifier : IGenerateEphemeridesParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "MAKE_EPHEM";
}

/// <inheritdoc cref="IObjectDataInclusionParameterIdentifier"/>
internal sealed record class ObjectDataInclusionParameterIdentifier : IObjectDataInclusionParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "OBJ_DATA";
}

/// <inheritdoc cref="IOriginParameterIdentifier"/>
internal sealed record class OriginParameterIdentifier : IOriginParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "CENTER";
}

/// <inheritdoc cref="IOriginCoordinateParameterIdentifier"/>
internal sealed record class OriginCoordinateParameterIdentifier : IOriginCoordinateParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "SITE_COORD";
}

/// <inheritdoc cref="IOriginCoordinateTypeParameterIdentifier"/>
internal sealed record class OriginCoordinateTypeParameterIdentifier : IOriginCoordinateTypeParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "COORD_TYPE";
}

/// <inheritdoc cref="IOutputFormatParameterIdentifier"/>
internal sealed record class OutputFormatParameterIdentifier : IOutputFormatParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "format";
}

/// <inheritdoc cref="IOutputUnitsParameterIdentifier"/>
internal sealed record class OutputUnitsParameterIdentifier : IOutputUnitsParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "OUT_UNITS";
}

/// <inheritdoc cref="IReferencePlaneParameterIdentifier"/>
internal sealed record class ReferencePlaneParameterIdentifier : IReferencePlaneParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "REF_PLANE";
}

/// <inheritdoc cref="IReferenceSystemParameterIdentifier"/>
internal sealed record class ReferenceSystemParameterIdentifier : IReferenceSystemParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "REF_SYSTEM";
}

/// <inheritdoc cref="IStartEpochParameterIdentifier"/>
internal sealed record class StartEpochParameterIdentifier : IStartEpochParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "START_TIME";
}

/// <inheritdoc cref="IStepSizeParameterIdentifier"/>
internal sealed record class StepSizeParameterIdentifier : IStepSizeParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "STEP_SIZE";
}

/// <inheritdoc cref="IStopEpochParameterIdentifier"/>
internal sealed record class StopEpochParameterIdentifier : IStopEpochParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "STOP_TIME";
}

/// <inheritdoc cref="ITimeDeltaInclusionParameterIdentifier"/>
internal sealed record class TimeDeltaInclusionParameterIdentifier : ITimeDeltaInclusionParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "VEC_DELTA_T";
}

/// <inheritdoc cref="ITimePrecisionParameterIdentifier"/>
internal sealed record class TimePrecisionParameterIdentifier : ITimePrecisionParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "TIME_DIGITS";
}

/// <inheritdoc cref="IValueSeparationParameterIdentifier"/>
internal sealed record class ValueSeparationParameterIdentifier : IValueSeparationParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "CSV_FORMAT";
}

/// <inheritdoc cref="IVectorCorrectionParameterIdentifier"/>
internal sealed record class VectorCorrectionParameterIdentifier : IVectorCorrectionParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "VEC_CORR";
}

/// <inheritdoc cref="IVectorLabelsParameterIdentifier"/>
internal sealed record class VectorLabelsIdentifier : IVectorLabelsParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "VEC_LABELS";
}

/// <inheritdoc cref="IVectorTableContentParameterIdentifier"/>
internal sealed record class VectorTableContentIdentifier : IVectorTableContentParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "VEC_TABLE";
}

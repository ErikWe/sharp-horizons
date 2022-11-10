namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="ITimeDeltaInclusionParameterIdentifier"/>
internal sealed record class TimeDeltaInclusionParameterIdentifier : ITimeDeltaInclusionParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "VEC_DELTA_T";
}

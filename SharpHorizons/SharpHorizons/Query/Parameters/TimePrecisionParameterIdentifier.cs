namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="ITimePrecisionParameterIdentifier"/>
internal sealed record class TimePrecisionParameterIdentifier : ITimePrecisionParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "TIME_DIGITS";
}

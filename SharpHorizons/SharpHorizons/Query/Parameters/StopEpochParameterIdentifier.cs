namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="IStopEpochParameterIdentifier"/>
internal sealed record class StopEpochParameterIdentifier : IStopEpochParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "STOP_TIME";
}

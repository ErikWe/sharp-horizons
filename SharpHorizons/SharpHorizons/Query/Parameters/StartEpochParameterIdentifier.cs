namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="IStartEpochParameterIdentifier"/>
internal sealed record class StartEpochParameterIdentifier : IStartEpochParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "START_TIME";
}

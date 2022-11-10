namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="IOutputUnitsParameterIdentifier"/>
internal sealed record class OutputUnitsParameterIdentifier : IOutputUnitsParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "OUT_UNITS";
}

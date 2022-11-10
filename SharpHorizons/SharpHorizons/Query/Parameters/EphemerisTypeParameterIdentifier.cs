namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="IEphemerisTypeParameterIdentifier"/>
internal sealed record class EphemerisTypeParameterIdentifier : IEphemerisTypeParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "EPHEM_TYPE";
}

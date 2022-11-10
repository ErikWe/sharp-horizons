namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="IReferenceSystemParameterIdentifier"/>
internal sealed record class ReferenceSystemParameterIdentifier : IReferenceSystemParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "REF_SYSTEM";
}

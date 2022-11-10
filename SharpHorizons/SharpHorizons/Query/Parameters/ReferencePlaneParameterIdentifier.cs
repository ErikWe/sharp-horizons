namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="IReferencePlaneParameterIdentifier"/>
internal sealed record class ReferencePlaneParameterIdentifier : IReferencePlaneParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "REF_PLANE";
}

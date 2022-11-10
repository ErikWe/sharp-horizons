namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="IObjectDataInclusionParameterIdentifier"/>
internal sealed record class ObjectDataInclusionParameterIdentifier : IObjectDataInclusionParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "OBJ_DATA";
}

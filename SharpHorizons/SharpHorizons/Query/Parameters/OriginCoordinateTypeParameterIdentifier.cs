namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="IOriginCoordinateTypeParameterIdentifier"/>
internal sealed record class OriginCoordinateTypeParameterIdentifier : IOriginCoordinateTypeParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "COORD_TYPE";
}

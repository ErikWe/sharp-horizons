namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="IOriginCoordinateParameterIdentifier"/>
internal sealed record class OriginCoordinateParameterIdentifier : IOriginCoordinateParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "SITE_COORD";
}

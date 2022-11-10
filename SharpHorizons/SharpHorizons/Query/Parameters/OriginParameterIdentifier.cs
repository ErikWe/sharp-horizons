namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="IOriginParameterIdentifier"/>
internal sealed record class OriginParameterIdentifier : IOriginParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "CENTER";
}

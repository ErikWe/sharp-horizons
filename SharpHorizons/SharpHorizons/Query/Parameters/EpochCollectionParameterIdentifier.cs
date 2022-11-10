namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="IEpochCollectionParameterIdentifier"/>
internal sealed record class EpochCollectionParameterIdentifier : IEpochCollectionParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "TLIST";
}

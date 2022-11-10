namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="IEpochCollectionParameterIdentifier"/>
internal sealed record class EpochCollectionFormatParameterIdentifier : IEpochCollectionFormatParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "TLIST_TYPE";
}

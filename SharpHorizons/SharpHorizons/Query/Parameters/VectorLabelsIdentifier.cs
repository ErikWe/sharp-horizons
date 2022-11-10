namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="IVectorLabelsParameterIdentifier"/>
internal sealed record class VectorLabelsIdentifier : IVectorLabelsParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "VEC_LABELS";
}

namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="IVectorTableContentParameterIdentifier"/>
internal sealed record class VectorTableContentIdentifier : IVectorTableContentParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "VEC_TABLE";
}

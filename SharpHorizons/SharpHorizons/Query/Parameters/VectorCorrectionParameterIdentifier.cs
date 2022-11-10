namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="IVectorCorrectionParameterIdentifier"/>
internal sealed record class VectorCorrectionParameterIdentifier : IVectorCorrectionParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "VEC_CORR";
}

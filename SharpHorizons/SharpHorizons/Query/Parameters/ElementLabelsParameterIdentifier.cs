namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="IElementLabelsParameterIdentifier"/>
internal sealed record class ElementLabelsParameterIdentifier : IElementLabelsParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "ELM_LABELS";
}

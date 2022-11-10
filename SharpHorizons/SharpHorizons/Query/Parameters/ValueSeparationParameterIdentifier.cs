namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="IValueSeparationParameterIdentifier"/>
internal sealed record class ValueSeparationParameterIdentifier : IValueSeparationParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "CSV_FORMAT";
}

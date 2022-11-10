namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="IOutputFormatParameterIdentifier"/>
internal sealed record class OutputFormatParameterIdentifier : IOutputFormatParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "format";
}

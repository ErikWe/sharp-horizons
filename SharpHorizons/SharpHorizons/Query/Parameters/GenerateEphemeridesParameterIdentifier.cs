namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="IGenerateEphemeridesParameterIdentifier"/>
internal sealed record class GenerateEphemeridesParameterIdentifier : IGenerateEphemeridesParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "MAKE_EPHEM";
}

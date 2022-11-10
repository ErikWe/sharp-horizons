namespace SharpHorizons.Query.Parameters;

/// <inheritdoc cref="ICommandParameterIdentifier"/>
internal sealed record class CommandParameterIdentifier : ICommandParameterIdentifier
{
    string IQueryParameterIdentifier.Identifier => "COMMAND";
}

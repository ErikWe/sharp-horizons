namespace SharpHorizons.Query.Parameters;

using SharpHorizons.Query.Arguments;

/// <summary>Represents a <see cref="ICommandParameterIdentifier"/> with an associated <see cref="ICommandArgument"/>.</summary>
public interface ICommandParameter : IQueryParameter<ICommandParameterIdentifier, ICommandArgument> { }
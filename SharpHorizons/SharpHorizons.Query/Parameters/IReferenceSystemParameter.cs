namespace SharpHorizons.Query.Parameters;

using SharpHorizons.Query.Arguments;

/// <summary>Represents a <see cref="IReferenceSystemParameterIdentifier"/> with an associated <see cref="IReferenceSystemArgument"/>.</summary>
public interface IReferenceSystemParameter : IQueryParameter<IReferenceSystemParameterIdentifier, IReferenceSystemArgument> { }
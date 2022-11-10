namespace SharpHorizons.Query.Parameters;

using SharpHorizons.Query.Arguments;

/// <summary>Represents a <see cref="IEphemerisTypeParameterIdentifier"/> with an associated <see cref="IEphemerisTypeArgument"/>.</summary>
public interface IEphemerisTypeParameter : IQueryParameter<IEphemerisTypeParameterIdentifier, IEphemerisTypeArgument> { }
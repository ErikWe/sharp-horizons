namespace SharpHorizons.Query.Parameters;

using SharpHorizons.Query.Arguments;

/// <summary>Represents a <see cref="IQueryParameterIdentifier"/> with an associated <see cref="IQueryArgument"/>.</summary>
/// <typeparam name="TIdentifier">The type of the <see cref="IQueryParameterIdentifier"/>.</typeparam>
/// <typeparam name="TArgument">The type of the <see cref="IQueryArgument"/>.</typeparam>
public interface IQueryParameter<TIdentifier, TArgument> where TIdentifier : IQueryParameterIdentifier where TArgument : IQueryArgument
{
    /// <summary>The <see cref="IQueryParameterIdentifier"/> of the <see cref="IQueryParameter{TIdentifier, TArgument}"/>.</summary>
    public abstract TIdentifier ParameterIdentifier { get; }

    /// <summary>The <see cref="IQueryArgument"/> of the <see cref="IQueryParameter{TIdentifier, TArgument}"/>.</summary>
    public abstract TArgument Argument { get; }
}

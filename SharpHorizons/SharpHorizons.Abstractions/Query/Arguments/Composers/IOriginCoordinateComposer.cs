namespace SharpHorizons.Query.Arguments.Composers;

/// <summary>Composes <see cref="IOriginCoordinateArgument"/> that describe <typeparamref name="T"/>.</summary>
/// <typeparam name="T">The composed <see cref="IOriginCoordinateArgument"/> describe instances of this type.</typeparam>
public interface IOriginCoordinateComposer<T> : IArgumentComposer<IOriginCoordinateArgument, T> { }

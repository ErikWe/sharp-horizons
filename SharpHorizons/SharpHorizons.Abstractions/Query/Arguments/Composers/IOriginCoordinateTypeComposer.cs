namespace SharpHorizons.Query.Arguments.Composers;

/// <summary>Composes <see cref="IOriginCoordinateTypeArgument"/> that describe <typeparamref name="T"/>.</summary>
/// <typeparam name="T">The composed <see cref="IOriginCoordinateTypeArgument"/> describe instances of this type.</typeparam>
public interface IOriginCoordinateTypeComposer<T> : IArgumentComposer<IOriginCoordinateTypeArgument, T> { }

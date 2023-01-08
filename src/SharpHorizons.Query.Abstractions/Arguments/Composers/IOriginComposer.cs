namespace SharpHorizons.Query.Arguments.Composers;

/// <summary>Composes <see cref="IOriginArgument"/> that describe <typeparamref name="T"/>.</summary>
/// <typeparam name="T">The composed <see cref="IOriginArgument"/> describe instances of this type.</typeparam>
public interface IOriginComposer<T> : IArgumentComposer<IOriginArgument, T> { }

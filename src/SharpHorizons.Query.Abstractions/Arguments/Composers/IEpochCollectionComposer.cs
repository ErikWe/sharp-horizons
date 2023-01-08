namespace SharpHorizons.Query.Arguments.Composers;

/// <summary>Composes <see cref="IEpochCollectionArgument"/> that describe <typeparamref name="T"/>.</summary>
/// <typeparam name="T">The composed <see cref="IEpochCollectionArgument"/> describe instances of this type.</typeparam>
public interface IEpochCollectionComposer<T> : IArgumentComposer<IEpochCollectionArgument, T> { }

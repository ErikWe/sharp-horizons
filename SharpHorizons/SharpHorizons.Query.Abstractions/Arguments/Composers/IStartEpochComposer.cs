namespace SharpHorizons.Query.Arguments.Composers;

/// <summary>Composes <see cref="IStartEpochArgument"/> that describe <typeparamref name="T"/>.</summary>
/// <typeparam name="T">The composed <see cref="IStartEpochArgument"/> describe instances of this type.</typeparam>
public interface IStartEpochComposer<T> : IArgumentComposer<IStartEpochArgument, T> { }

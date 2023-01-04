namespace SharpHorizons.Query.Arguments.Composers;

/// <summary>Composes <see cref="IStopEpochArgument"/> that describe <typeparamref name="T"/>.</summary>
/// <typeparam name="T">The composed <see cref="IStopEpochArgument"/> describe instances of this type.</typeparam>
public interface IStopEpochComposer<T> : IArgumentComposer<IStopEpochArgument, T> { }

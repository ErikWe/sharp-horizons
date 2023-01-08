namespace SharpHorizons.Query.Arguments.Composers;

/// <summary>Composes <see cref="IStepSizeArgument"/> that describe <typeparamref name="T"/>.</summary>
/// <typeparam name="T">The composed <see cref="IStepSizeArgument"/> describe instances of this type.</typeparam>
public interface IStepSizeComposer<T> : IArgumentComposer<IStepSizeArgument, T> { }

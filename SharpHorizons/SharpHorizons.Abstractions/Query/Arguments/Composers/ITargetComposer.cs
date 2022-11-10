namespace SharpHorizons.Query.Arguments.Composers;

/// <summary>Composes <see cref="ITargetArgument"/> that describe <typeparamref name="T"/>.</summary>
/// <typeparam name="T">The composed <see cref="ITargetArgument"/> describe instances of this type.</typeparam>
public interface ITargetComposer<T> : IArgumentComposer<ITargetArgument, T>, ICommandComposer<T> { }

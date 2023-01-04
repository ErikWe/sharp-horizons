namespace SharpHorizons.Query.Arguments.Composers;

/// <summary>Composes <see cref="ICommandArgument"/> that describe <typeparamref name="T"/>.</summary>
/// <typeparam name="T">The composed <see cref="ICommandArgument"/> describe instances of this type.</typeparam>
public interface ICommandComposer<T> : IArgumentComposer<ICommandArgument, T> { }

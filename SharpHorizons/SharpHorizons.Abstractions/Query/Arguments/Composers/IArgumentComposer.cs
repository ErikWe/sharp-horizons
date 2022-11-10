namespace SharpHorizons.Query.Arguments.Composers;

using System;

/// <summary>Composes <typeparamref name="TArgument"/> that describe <typeparamref name="T"/>.</summary>
/// <typeparam name="TArgument">The composed <see cref="IQueryArgument"/> is of this type.</typeparam>
/// <typeparam name="T">The composed <typeparamref name="TArgument"/> describe instances of this type.</typeparam>
public interface IArgumentComposer<TArgument, T> where TArgument : IQueryArgument
{
    /// <summary>Composes a <typeparamref name="TArgument"/> describing <paramref name="obj"/>.</summary>
    /// <param name="obj">The composed <typeparamref name="TArgument"/> describes this <typeparamref name="T"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract TArgument Compose(T obj);
}

namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.Query.Target;

using System;

/// <summary>Composes <see cref="TargetObjectIdentifier"/> that describe <typeparamref name="T"/>.</summary>
/// <typeparam name="T">The composed <see cref="TargetObjectIdentifier"/> describe instances of this type.</typeparam>
public interface ITargetObjectComposer<T>
{
    /// <summary>Composes a <see cref="TargetObjectIdentifier"/> describing <paramref name="obj"/>.</summary>
    /// <param name="obj">The composed <see cref="TargetObjectIdentifier"/> describes this <typeparamref name="T"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    public abstract TargetObjectIdentifier Compose(T obj);
}

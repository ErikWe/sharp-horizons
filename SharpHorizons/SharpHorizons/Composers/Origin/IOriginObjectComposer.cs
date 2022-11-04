namespace SharpHorizons.Composers.Origin;

using SharpHorizons.Query.Origin;

using System;

/// <summary>Composes <see cref="OriginObjectIdentifier"/> that describe <typeparamref name="T"/>.</summary>
/// <typeparam name="T">The composed <see cref="OriginObjectIdentifier"/> describe instances of this type.</typeparam>
public interface IOriginObjectComposer<T>
{
    /// <summary>Composes a <see cref="OriginObjectIdentifier"/> describing <paramref name="obj"/>.</summary>
    /// <param name="obj">The composed <see cref="OriginObjectIdentifier"/> describes this <typeparamref name="T"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract OriginObjectIdentifier Compose(T obj);
}

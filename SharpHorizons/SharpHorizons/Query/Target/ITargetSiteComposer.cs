namespace SharpHorizons.Query.Target;

using System;

/// <summary>Composes <see cref="TargetSiteIdentifier"/> that describe <typeparamref name="T"/>.</summary>
/// <typeparam name="T">The composed <see cref="TargetSiteIdentifier"/> describe instances of this type.</typeparam>
public interface ITargetSiteComposer<T>
{
    /// <summary>Composes a <see cref="TargetSiteIdentifier"/> describing <paramref name="obj"/>.</summary>
    /// <param name="obj">The composed <see cref="TargetSiteIdentifier"/> describes this <typeparamref name="T"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract TargetSiteIdentifier Compose(T obj);
}

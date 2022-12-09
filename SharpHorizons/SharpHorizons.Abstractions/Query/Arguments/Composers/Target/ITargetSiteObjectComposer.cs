namespace SharpHorizons.Query.Arguments.Composers.Target;

using SharpHorizons.Query.Target;

using System;

/// <summary>Composes <see cref="TargetSiteObjectIdentifier"/> that describe <typeparamref name="T"/>.</summary>
/// <typeparam name="T">The composed <see cref="TargetSiteObjectIdentifier"/> describe instances of this type.</typeparam>
public interface ITargetSiteObjectComposer<T>
{
    /// <summary>Composes a <see cref="TargetSiteObjectIdentifier"/> describing <paramref name="obj"/>.</summary>
    /// <param name="obj">The composed <see cref="TargetSiteObjectIdentifier"/> describes this <typeparamref name="T"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    public abstract TargetSiteObjectIdentifier Compose(T obj);
}

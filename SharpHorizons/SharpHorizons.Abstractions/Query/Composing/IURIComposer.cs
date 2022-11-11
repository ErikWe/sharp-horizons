namespace SharpHorizons.Query.Composing;

using System;

/// <summary>Composes <see cref="Uri"/> describing <see cref="HorizonsQueryString"/>.</summary>
public interface IURIComposer
{
    /// <summary>Composes a <see cref="Uri"/> describing <paramref name="query"/>.</summary>
    /// <param name="query">The composed <see cref="Uri"/> describes this <see cref="HorizonsQueryString"/>.</param>
    public abstract Uri Compose(HorizonsQueryString query);
}

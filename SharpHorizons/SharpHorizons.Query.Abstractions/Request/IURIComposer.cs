namespace SharpHorizons.Query.Request;

using System;

/// <summary>Composes <see cref="HorizonsQueryURI"/> describing <see cref="HorizonsQueryString"/>.</summary>
public interface IURIComposer
{
    /// <summary>Composes a <see cref="HorizonsQueryURI"/> describing <paramref name="query"/>.</summary>
    /// <param name="query">The composed <see cref="HorizonsQueryURI"/> describes this <see cref="HorizonsQueryString"/>.</param>
    /// <exception cref="ArgumentException"/>
    public abstract HorizonsQueryURI Compose(HorizonsQueryString query);
}

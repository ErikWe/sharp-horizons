namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Query.Request;

using System;

/// <summary>Composes <see cref="HorizonsQueryURI"/> describing <see cref="IVectorsQuery"/>.</summary>
public interface IVectorsQueryComposer
{
    /// <summary>Composes a <see cref="HorizonsQueryURI"/> describing <paramref name="query"/>.</summary>
    /// <param name="query">The composed <see cref="HorizonsQueryURI"/> describes these <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract HorizonsQueryURI Compose(IVectorsQuery query);
}

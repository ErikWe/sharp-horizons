namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Query.Request;

using System;

/// <summary>Composes <see cref="HorizonsQueryString"/> describing <see cref="IVectorsQuery"/>.</summary>
public interface IVectorsQueryComposer
{
    /// <summary>Composes a <see cref="HorizonsQueryString"/> describing the <see cref="IVectorsQuery"/> <paramref name="query"/>.</summary>
    /// <param name="query">The composed <see cref="HorizonsQueryString"/> describes this <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract HorizonsQueryString Compose(IVectorsQuery query);
}

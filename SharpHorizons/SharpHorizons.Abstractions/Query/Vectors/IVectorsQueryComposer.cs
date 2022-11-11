namespace SharpHorizons.Query.Vectors;

using System;

/// <summary>Composes <see cref="Uri"/> describing <see cref="IVectorsQuery"/>.</summary>
public interface IVectorsQueryComposer
{
    /// <summary>Composes a <see cref="Uri"/> describing <paramref name="query"/>.</summary>
    /// <param name="query">The composed <see cref="Uri"/> describes these <see cref="IVectorsQuery"/>.</param>
    public abstract Uri Compose(IVectorsQuery query);
}

namespace SharpHorizons.Query.Vectors;

/// <summary>Composes <see cref="HorizonsQueryString"/> describing <see cref="IVectorsQuery"/>.</summary>
public interface IVectorsQueryComposer
{
    /// <summary>Composes a <see cref="HorizonsQueryString"/> describing <paramref name="query"/>.</summary>
    /// <param name="query">The composed <see cref="HorizonsQueryString"/> describes these <see cref="IVectorsQuery"/>.</param>
    public abstract HorizonsQueryString Compose(IVectorsQuery query);
}

namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Query.Arguments;

/// <summary>Composes <see cref="IQueryArgumentSet"/> describing <see cref="IVectorsQuery"/>.</summary>
public interface IVectorsQueryArgumentComposer
{
    /// <summary>Composes the <see cref="IQueryArgumentSet"/> describing <paramref name="query"/>.</summary>
    /// <param name="query">The composed <see cref="IQueryArgumentSet"/> describes this <see cref="IVectorsQuery"/>.</param>
    public abstract IQueryArgumentSet Compose(IVectorsQuery query);
}

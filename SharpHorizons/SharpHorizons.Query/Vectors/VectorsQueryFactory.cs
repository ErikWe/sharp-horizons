namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

/// <inheritdoc cref="IVectorsQueryFactory"/>
public sealed class VectorsQueryFactory : IVectorsQueryFactory
{
    /// <inheritdoc cref="IVectorsQueryValidator"/>
    private IVectorsQueryValidator VectorsQueryValidator { get; }

    /// <inheritdoc cref="VectorsQueryFactory"/>
    /// <param name="vectorsQueryValidator"><inheritdoc cref="VectorsQueryValidator" path="/summary"/></param>
    public VectorsQueryFactory(IVectorsQueryValidator? vectorsQueryValidator = null)
    {
        VectorsQueryValidator = vectorsQueryValidator ?? new VectorsQueryValidator();
    }

    /// <inheritdoc/>
    public IVectorsQuery Create(ITarget target, IOrigin origin, IEpochSelection epochSelection)
    {
        VectorsQueryValidator.ValidateTarget(target);
        VectorsQueryValidator.ValidateOrigin(origin);
        VectorsQueryValidator.ValidateEpochSelection(epochSelection);

        return new VectorsQuery(target, origin, epochSelection);
    }

    /// <inheritdoc/>
    public IVectorsQueryBuilder CreateBuilder(ITarget target, IOrigin origin, IEpochSelection epochSelection)
    {
        VectorsQueryValidator.ValidateTarget(target);
        VectorsQueryValidator.ValidateOrigin(origin);
        VectorsQueryValidator.ValidateEpochSelection(epochSelection);

        return new VectorsQueryBuilder(VectorsQueryValidator, target, origin, epochSelection);
    }

    /// <inheritdoc/>
    public IVectorsQueryBuilder CreateBuilder(IVectorsQuery vectorsQuery)
    {
        VectorsQueryValidator.Validate(vectorsQuery);

        return new VectorsQueryBuilder(VectorsQueryValidator, vectorsQuery);
    }
}

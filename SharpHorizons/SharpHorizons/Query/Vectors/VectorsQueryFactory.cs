namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors.Fluency;

using System;

/// <inheritdoc cref="IVectorsQueryFactory"/>
public sealed class VectorsQueryFactory : IVectorsQueryFactory
{
    /// <inheritdoc cref="ITargetStageFactory"/>
    private ITargetStageFactory TargetStageFactory { get; }

    /// <inheritdoc cref="Vectors.VectorsQueryInstantiation"/>
    private VectorsQueryInstantiation VectorsQueryInstantiation { get; }

    /// <inheritdoc cref="VectorsQueryFactory"/>
    /// <param name="targetStageFactory"><inheritdoc cref="TargetStageFactory" path="/summary"/></param>
    /// <param name="vectorsQueryInstantiation"><inheritdoc cref="VectorsQueryInstantiation" path="/summary"/></param>
    public VectorsQueryFactory(ITargetStageFactory? targetStageFactory = null, VectorsQueryInstantiation? vectorsQueryInstantiation = null)
    {
        TargetStageFactory = targetStageFactory ?? new TargetStageFactory();

        VectorsQueryInstantiation = vectorsQueryInstantiation ?? VectorsQuery.Instantiation;
    }

    /// <inheritdoc/>
    public IVectorsQuery Build(ITarget target, IOrigin origin, IEpochSelection epochs)
    {
        ArgumentNullException.ThrowIfNull(target);
        ArgumentNullException.ThrowIfNull(origin);
        ArgumentNullException.ThrowIfNull(epochs);

        return VectorsQueryInstantiation(target, origin, epochs);
    }

    /// <inheritdoc/>
    public ITargetStage Fluent() => TargetStageFactory.Create();
}

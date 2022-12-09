namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors.Fluency;
using SharpHorizons.Query.Vectors.Table;

using System;

/// <inheritdoc cref="IVectorsQueryFactory"/>
public sealed class VectorsQueryFactory : IVectorsQueryFactory
{
    /// <inheritdoc cref="ITargetStageFactory"/>
    private ITargetStageFactory TargetStageFactory { get; }

    /// <inheritdoc cref="IVectorTableContentValidator"/>
    private IVectorTableContentValidator VectorTableContentValidator { get; }

    /// <inheritdoc cref="VectorsQueryFactory"/>
    /// <param name="targetStageFactory"><inheritdoc cref="TargetStageFactory" path="/summary"/></param>
    /// <param name="vectorTableContentValidator"><inheritdoc cref="VectorTableContentValidator" path="/summary"/></param>
    public VectorsQueryFactory(ITargetStageFactory? targetStageFactory = null, IVectorTableContentValidator? vectorTableContentValidator = null)
    {
        TargetStageFactory = targetStageFactory ?? new TargetStageFactory();

        VectorTableContentValidator = vectorTableContentValidator ?? new VectorTableContentValidator();
    }

    /// <inheritdoc/>
    public IVectorsQuery Build(ITarget target, IOrigin origin, IEpochSelection epochs)
    {
        ArgumentNullException.ThrowIfNull(target);
        ArgumentNullException.ThrowIfNull(origin);
        ArgumentNullException.ThrowIfNull(epochs);

        return new VectorsQuery(VectorTableContentValidator, target, origin, epochs);
    }

    /// <inheritdoc/>
    public ITargetStage Fluent() => TargetStageFactory.Create();
}

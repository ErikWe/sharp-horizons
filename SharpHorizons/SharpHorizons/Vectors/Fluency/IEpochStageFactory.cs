namespace SharpHorizons.Vectors.Fluency;

using SharpHorizons.Calendars;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

/// <summary>Handles construction of <see cref="IEpochStage"/>.</summary>
internal interface IEpochStageFactory
{
    /// <summary>Uses <paramref name="target"/> and <paramref name="origin"/> as the <see cref="ITarget"/> and <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/>, and provides means of selecting the <see cref="IEpoch"/>.</summary>
    /// <param name="target"><inheritdoc cref="EpochStage.Target" path="/summary"/></param>
    /// <param name="origin"><inheritdoc cref="EpochStage.Origin" path="/summary"/></param>
    IEpochStage Create(ITarget target, IOrigin origin);
}
namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Calendars;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

/// <summary>Handles construction of <see cref="IEpochStage"/>.</summary>
public interface IEpochStageFactory
{
    /// <summary>Uses <paramref name="target"/> and <paramref name="origin"/> as the <see cref="ITarget"/> and <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/>, and provides means of selecting the <see cref="IEpoch"/>.</summary>
    /// <param name="target">The <see cref="ITarget"/> selected for the <see cref="IVectorsQuery"/>.</param>
    /// <param name="origin">The <see cref="IOrigin"/> selected for the <see cref="IVectorsQuery"/>.</param>
    public abstract IEpochStage Create(ITarget target, IOrigin origin);
}
namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

using System;

/// <summary>Handles construction of <see cref="IOriginStage"/>.</summary>
public interface IOriginStageFactory
{
    /// <summary>Uses <paramref name="target"/> as the <see cref="ITarget"/> of the <see cref="IVectorsQuery"/>, and provides means of selecting the <see cref="IOrigin"/>.</summary>
    /// <param name="target">The <see cref="ITarget"/> selected for the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOriginStage Create(ITarget target);
}
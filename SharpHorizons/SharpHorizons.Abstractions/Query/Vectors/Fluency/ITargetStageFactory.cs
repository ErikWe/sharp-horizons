namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Query.Target;

/// <summary>Handles construction of <see cref="ITargetStage"/>.</summary>
public interface ITargetStageFactory
{
    /// <summary>Constructs a <see cref="ITargetStage"/>, providing means of selecting the <see cref="ITarget"/> of the <see cref="IVectorsQuery"/>.</summary>
    public abstract ITargetStage Create();
}
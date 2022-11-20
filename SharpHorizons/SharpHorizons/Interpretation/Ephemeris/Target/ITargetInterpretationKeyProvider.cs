namespace SharpHorizons.Interpretation.Ephemeris.Target;

/// <summary>Provides the keys present in the result of queries related to the <see cref="ITargetDataInterpretation"/>.</summary>
public interface ITargetInterpretationKeyProvider
{
    /// <inheritdoc cref="TargetInterpretationKeyOptions.BodyName"/>
    public abstract string BodyName { get; }

    /// <inheritdoc cref="TargetInterpretationKeyOptions.GeodeticCoordinate"/>
    public abstract string GeodeticCoordinate { get; }

    /// <inheritdoc cref="TargetInterpretationKeyOptions.CylindricalCoordinate"/>
    public abstract string CylindricalCoordinate { get; }

    /// <inheritdoc cref="TargetInterpretationKeyOptions.ReferenceEllipsoid"/>
    public abstract string ReferenceEllipsoid { get; }

    /// <inheritdoc cref="TargetInterpretationKeyOptions.Radii"/>
    public abstract string Radii { get; }
}

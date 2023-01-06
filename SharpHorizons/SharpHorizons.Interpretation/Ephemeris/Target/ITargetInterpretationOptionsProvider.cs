namespace SharpHorizons.Interpretation.Ephemeris.Target;

using SharpHorizons.Settings.Interpretation.Ephemeris.Target;

/// <summary>Provides options related to the interpretation of <see cref="IEphemerisTargetHeader"/>.</summary>
public interface ITargetInterpretationOptionsProvider
{
    /// <inheritdoc cref="TargetInterpretationOptions.BodyName"/>
    public abstract string BodyName { get; }

    /// <inheritdoc cref="TargetInterpretationOptions.GeodeticCoordinate"/>
    public abstract string GeodeticCoordinate { get; }

    /// <inheritdoc cref="TargetInterpretationOptions.CylindricalCoordinate"/>
    public abstract string CylindricalCoordinate { get; }

    /// <inheritdoc cref="TargetInterpretationOptions.ReferenceEllipsoid"/>
    public abstract string ReferenceEllipsoid { get; }

    /// <inheritdoc cref="TargetInterpretationOptions.Radii"/>
    public abstract string Radii { get; }
}

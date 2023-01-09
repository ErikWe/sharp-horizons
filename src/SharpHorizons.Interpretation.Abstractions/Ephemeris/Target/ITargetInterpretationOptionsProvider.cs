namespace SharpHorizons.Interpretation.Ephemeris.Target;

using SharpHorizons.Query.Target;

/// <summary>Provides options related to the interpretation of <see cref="IEphemerisTargetHeader"/>.</summary>
public interface ITargetInterpretationOptionsProvider
{
    /// <summary>The key corresponding to the name of the <see cref="ITarget"/>.</summary>
    public abstract string BodyName { get; }

    /// <summary>The key corresponding to the <see cref="SharpMeasures.Astronomy.GeodeticCoordinate"/> of the <see cref="ITarget"/>.</summary>
    public abstract string GeodeticCoordinate { get; }

    /// <summary>The key corresponding to the <see cref="SharpMeasures.Astronomy.CylindricalCoordinate"/> of the <see cref="ITarget"/>.</summary>
    public abstract string CylindricalCoordinate { get; }

    /// <summary>The key corresponding to the <see cref="ReferenceEllipsoidInterpretation"/> of the <see cref="ITarget"/>.</summary>
    public abstract string ReferenceEllipsoid { get; }

    /// <summary>The key corresponding to the <see cref="ObjectRadiiInterpretation"/> of the <see cref="ITarget"/>.</summary>
    public abstract string Radii { get; }
}

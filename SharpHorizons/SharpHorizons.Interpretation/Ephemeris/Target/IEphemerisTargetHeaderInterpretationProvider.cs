namespace SharpHorizons.Interpretation.Ephemeris.Target;

/// <summary>Provides the <see cref="IPartInterpreter{TInterpretation}"/> related to interpreting a <see cref="IEphemerisTargetHeader"/>.</summary>
public interface IEphemerisTargetHeaderInterpretationProvider
{
    /// <inheritdoc cref="ITargetInterpreter"/>
    public abstract ITargetInterpreter TargetInterpreter { get; }

    /// <inheritdoc cref="ITargetGeodeticCoordinateInterpreter"/>
    public abstract ITargetGeodeticCoordinateInterpreter GeodeticCoordinateInterpreter { get; }

    /// <inheritdoc cref="ITargetCylindricalCoordinateInterpreter"/>
    public abstract ITargetCylindricalCoordinateInterpreter CylindricalCoordinateInterpreter { get; }

    /// <inheritdoc cref="ITargetReferenceEllipsoidInterpreter"/>
    public abstract ITargetReferenceEllipsoidInterpreter ReferenceEllipsoidInterpreter { get; }

    /// <inheritdoc cref="ITargetRadiiInterpreter"/>
    public abstract ITargetRadiiInterpreter RadiiInterpreter { get; }
}

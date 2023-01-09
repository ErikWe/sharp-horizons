namespace SharpHorizons.Interpretation.Ephemeris.Target;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IEphemerisTargetHeaderInterpretationProvider"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class EphemerisTargetHeaderInterpretationProvider : IEphemerisTargetHeaderInterpretationProvider
{
    public ITargetInterpreter TargetInterpreter { get; }
    public ITargetGeodeticCoordinateInterpreter GeodeticCoordinateInterpreter { get; }
    public ITargetCylindricalCoordinateInterpreter CylindricalCoordinateInterpreter { get; }
    public ITargetReferenceEllipsoidInterpreter ReferenceEllipsoidInterpreter { get; }
    public ITargetRadiiInterpreter RadiiInterpreter { get; }

    /// <inheritdoc cref="EphemerisTargetHeaderInterpretationProvider"/>
    /// <param name="targetInterpreter"><inheritdoc cref="TargetInterpreter" path="/summary"/></param>
    /// <param name="geodeticCoordinateInterpreter"><inheritdoc cref="GeodeticCoordinateInterpreter" path="/summary"/></param>
    /// <param name="cylindricalCoordinateInterpreter"><inheritdoc cref="CylindricalCoordinateInterpreter" path="/summary"/></param>
    /// <param name="referenceEllipsoidInterpreter"><inheritdoc cref="ReferenceEllipsoidInterpreter" path="/summary"/></param>
    /// <param name="radiiInterpreter"><inheritdoc cref="RadiiInterpreter" path="/summary"/></param>
    public EphemerisTargetHeaderInterpretationProvider(ITargetInterpreter targetInterpreter, ITargetGeodeticCoordinateInterpreter geodeticCoordinateInterpreter,
        ITargetCylindricalCoordinateInterpreter cylindricalCoordinateInterpreter, ITargetReferenceEllipsoidInterpreter referenceEllipsoidInterpreter, ITargetRadiiInterpreter radiiInterpreter)
    {
        TargetInterpreter = targetInterpreter;
        GeodeticCoordinateInterpreter = geodeticCoordinateInterpreter;
        CylindricalCoordinateInterpreter = cylindricalCoordinateInterpreter;
        ReferenceEllipsoidInterpreter = referenceEllipsoidInterpreter;
        RadiiInterpreter = radiiInterpreter;
    }
}

namespace SharpHorizons.Interpretation.Ephemeris.Target;

/// <inheritdoc cref="IEphemerisTargetHeaderInterpretationProvider"/>
internal sealed class EphemerisTargetHeaderInterpretationProvider : IEphemerisTargetHeaderInterpretationProvider
{
    public ITargetInterpreter TargetInterpreter { get; private init; }
    public ITargetGeodeticCoordinateInterpreter GeodeticCoordinateInterpreter { get; private init; }
    public ITargetCylindricalCoordinateInterpreter CylindricalCoordinateInterpreter { get; private init; }
    public ITargetReferenceEllipsoidInterpreter ReferenceEllipsoidInterpreter { get; private init; }
    public ITargetRadiiInterpreter RadiiInterpreter { get; private init; }

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

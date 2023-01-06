namespace SharpHorizons.Interpretation.Ephemeris.Origin;

/// <inheritdoc cref="IEphemerisOriginHeaderInterpretationProvider"/>
internal sealed class EphemerisOriginHeaderInterpretationProvider : IEphemerisOriginHeaderInterpretationProvider
{
    public IOriginInterpreter OriginInterpreter { get; private init; }
    public IOriginGeodeticCoordinateInterpreter GeodeticCoordinateInterpreter { get; private init; }
    public IOriginCylindricalCoordinateInterpreter CylindricalCoordinateInterpreter { get; private init; }
    public IOriginSiteNameInterpreter SiteNameInterpreter { get; private init; }
    public IOriginReferenceEllipsoidInterpreter ReferenceEllipsoidInterpreter { get; private init; }
    public IOriginRadiiInterpreter RadiiInterpreter { get; private init; }

    /// <inheritdoc cref="EphemerisOriginHeaderInterpretationProvider"/>
    /// <param name="originInterpreter"><inheritdoc cref="OriginInterpreter" path="/summary"/></param>
    /// <param name="geodeticCoordinateInterpreter"><inheritdoc cref="GeodeticCoordinateInterpreter" path="/summary"/></param>
    /// <param name="cylindricalCoordinateInterpreter"><inheritdoc cref="CylindricalCoordinateInterpreter" path="/summary"/></param>
    /// <param name="siteNameInterpreter"><inheritdoc cref="SiteNameInterpreter" path="/summary"/></param>
    /// <param name="referenceEllipsoidInterpreter"><inheritdoc cref="ReferenceEllipsoidInterpreter" path="/summary"/></param>
    /// <param name="radiiInterpreter"><inheritdoc cref="RadiiInterpreter" path="/summary"/></param>
    public EphemerisOriginHeaderInterpretationProvider(IOriginInterpreter originInterpreter, IOriginGeodeticCoordinateInterpreter geodeticCoordinateInterpreter, IOriginCylindricalCoordinateInterpreter cylindricalCoordinateInterpreter,
        IOriginSiteNameInterpreter siteNameInterpreter, IOriginReferenceEllipsoidInterpreter referenceEllipsoidInterpreter, IOriginRadiiInterpreter radiiInterpreter)
    {
        OriginInterpreter = originInterpreter;
        GeodeticCoordinateInterpreter = geodeticCoordinateInterpreter;
        CylindricalCoordinateInterpreter = cylindricalCoordinateInterpreter;
        SiteNameInterpreter = siteNameInterpreter;
        ReferenceEllipsoidInterpreter = referenceEllipsoidInterpreter;
        RadiiInterpreter = radiiInterpreter;
    }
}

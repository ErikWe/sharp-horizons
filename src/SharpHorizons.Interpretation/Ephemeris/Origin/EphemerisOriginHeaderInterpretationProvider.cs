namespace SharpHorizons.Interpretation.Ephemeris.Origin;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IEphemerisOriginHeaderInterpretationProvider"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class EphemerisOriginHeaderInterpretationProvider : IEphemerisOriginHeaderInterpretationProvider
{
    public IOriginInterpreter OriginInterpreter { get; }
    public IOriginGeodeticCoordinateInterpreter GeodeticCoordinateInterpreter { get; }
    public IOriginCylindricalCoordinateInterpreter CylindricalCoordinateInterpreter { get; }
    public IOriginSiteNameInterpreter SiteNameInterpreter { get; }
    public IOriginReferenceEllipsoidInterpreter ReferenceEllipsoidInterpreter { get; }
    public IOriginRadiiInterpreter RadiiInterpreter { get; }

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

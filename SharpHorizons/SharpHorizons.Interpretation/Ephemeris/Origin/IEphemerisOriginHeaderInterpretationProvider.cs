namespace SharpHorizons.Interpretation.Ephemeris.Origin;

/// <summary>Provides the <see cref="IInterpreter{TInterpretation}"/> related to interpreting an <see cref="IEphemerisOriginHeader"/>.</summary>
public interface IEphemerisOriginHeaderInterpretationProvider
{
    /// <inheritdoc cref="IOriginInterpreter"/>
    public abstract IOriginInterpreter OriginInterpreter { get; }

    /// <inheritdoc cref="IOriginGeodeticCoordinateInterpreter"/>
    public abstract IOriginGeodeticCoordinateInterpreter GeodeticCoordinateInterpreter { get; }

    /// <inheritdoc cref="IOriginCylindricalCoordinateInterpreter"/>
    public abstract IOriginCylindricalCoordinateInterpreter CylindricalCoordinateInterpreter { get; }

    /// <inheritdoc cref="IOriginSiteNameInterpreter"/>
    public abstract IOriginSiteNameInterpreter SiteNameInterpreter { get; }

    /// <inheritdoc cref="IOriginReferenceEllipsoidInterpreter"/>
    public abstract IOriginReferenceEllipsoidInterpreter ReferenceEllipsoidInterpreter { get; }

    /// <inheritdoc cref="IOriginRadiiInterpreter"/>
    public abstract IOriginRadiiInterpreter RadiiInterpreter { get; }
}

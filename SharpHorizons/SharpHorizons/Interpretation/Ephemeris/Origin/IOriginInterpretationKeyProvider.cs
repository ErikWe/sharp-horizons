namespace SharpHorizons.Interpretation.Ephemeris.Origin;

/// <summary>Provides the keys present in the result of queries related to the <see cref="IOriginDataInterpretation"/>.</summary>
public interface IOriginInterpretationKeyProvider
{
    /// <inheritdoc cref="OriginInterpretationKeyOptions.BodyName"/>
    public abstract string BodyName { get; }

    /// <inheritdoc cref="OriginInterpretationKeyOptions.GeodeticCoordinate"/>
    public abstract string GeodeticCoordinate { get; }

    /// <inheritdoc cref="OriginInterpretationKeyOptions.CylindricalCoordinate"/>
    public abstract string CylindricalCoordinate { get; }

    /// <inheritdoc cref="OriginInterpretationKeyOptions.ReferenceEllipsoid"/>
    public abstract string ReferenceEllipsoid { get; }

    /// <inheritdoc cref="OriginInterpretationKeyOptions.Radii"/>
    public abstract string Radii { get; }
}

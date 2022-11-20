namespace SharpHorizons.Interpretation.Ephemeris.Origin;

using Microsoft.Extensions.Options;

/// <inheritdoc cref="IOriginInterpretationKeyProvider"/>
internal sealed class OriginInterpretationKeyProvider : IOriginInterpretationKeyProvider
{
    /// <summary><inheritdoc cref="OriginInterpretationKeyOptions" path="/summary"/></summary>
    private OriginInterpretationKeyOptions Options { get; }

    /// <inheritdoc cref="OriginInterpretationKeyProvider"/>
    /// <param name="options"><inheritdoc cref="Options" path="/summary"/></param>
    public OriginInterpretationKeyProvider(IOptions<OriginInterpretationKeyOptions> options)
    {
        Options = options.Value;
    }

    string IOriginInterpretationKeyProvider.BodyName => Options.BodyName;
    string IOriginInterpretationKeyProvider.GeodeticCoordinate => Options.GeodeticCoordinate;
    string IOriginInterpretationKeyProvider.CylindricalCoordinate => Options.CylindricalCoordinate;
    string IOriginInterpretationKeyProvider.ReferenceEllipsoid => Options.ReferenceEllipsoid;
    string IOriginInterpretationKeyProvider.Radii => Options.Radii;
}

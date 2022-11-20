namespace SharpHorizons.Interpretation.Ephemeris.Target;

using Microsoft.Extensions.Options;

/// <inheritdoc cref="ITargetInterpretationKeyProvider"/>
internal sealed class TargetInterpretationKeyProvider : ITargetInterpretationKeyProvider
{
    /// <summary><inheritdoc cref="TargetInterpretationKeyOptions" path="/summary"/></summary>
    private TargetInterpretationKeyOptions Options { get; }

    /// <inheritdoc cref="TargetInterpretationKeyProvider"/>
    /// <param name="options"><inheritdoc cref="Options" path="/summary"/></param>
    public TargetInterpretationKeyProvider(IOptions<TargetInterpretationKeyOptions> options)
    {
        Options = options.Value;
    }

    string ITargetInterpretationKeyProvider.BodyName => Options.BodyName;
    string ITargetInterpretationKeyProvider.GeodeticCoordinate => Options.GeodeticCoordinate;
    string ITargetInterpretationKeyProvider.CylindricalCoordinate => Options.CylindricalCoordinate;
    string ITargetInterpretationKeyProvider.ReferenceEllipsoid => Options.ReferenceEllipsoid;
    string ITargetInterpretationKeyProvider.Radii => Options.Radii;
}

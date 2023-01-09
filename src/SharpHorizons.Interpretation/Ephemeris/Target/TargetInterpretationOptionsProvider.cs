namespace SharpHorizons.Interpretation.Ephemeris.Target;

using Microsoft.Extensions.Options;

using SharpHorizons.Settings.Interpretation.Ephemeris.Target;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="ITargetInterpretationOptionsProvider"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class TargetInterpretationOptionsProvider : ITargetInterpretationOptionsProvider
{
    /// <inheritdoc cref="TargetInterpretationOptions"/>
    private TargetInterpretationOptions Options { get; }

    /// <inheritdoc cref="TargetInterpretationOptionsProvider"/>
    /// <param name="options"><inheritdoc cref="Options" path="/summary"/></param>
    public TargetInterpretationOptionsProvider(IOptions<TargetInterpretationOptions> options)
    {
        Options = options.Value;
    }

    string ITargetInterpretationOptionsProvider.BodyName => Options.BodyName;
    string ITargetInterpretationOptionsProvider.GeodeticCoordinate => Options.GeodeticCoordinate;
    string ITargetInterpretationOptionsProvider.CylindricalCoordinate => Options.CylindricalCoordinate;
    string ITargetInterpretationOptionsProvider.ReferenceEllipsoid => Options.ReferenceEllipsoid;
    string ITargetInterpretationOptionsProvider.Radii => Options.Radii;
}

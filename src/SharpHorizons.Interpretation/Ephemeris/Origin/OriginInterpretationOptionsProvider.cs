﻿namespace SharpHorizons.Interpretation.Ephemeris.Origin;

using Microsoft.Extensions.Options;

using SharpHorizons.Settings.Interpretation.Ephemeris.Origin;

using System.Diagnostics.CodeAnalysis;

/// <inheritdoc cref="IOriginInterpretationOptionsProvider"/>
[SuppressMessage("Performance", "CA1812: Avoid uninstantiated internal classes", Justification = "Used in DI.")]
internal sealed class OriginInterpretationOptionsProvider : IOriginInterpretationOptionsProvider
{
    /// <inheritdoc cref="OriginInterpretationOptions"/>
    private OriginInterpretationOptions Options { get; }

    /// <inheritdoc cref="OriginInterpretationOptionsProvider"/>
    /// <param name="options"><inheritdoc cref="Options" path="/summary"/></param>
    public OriginInterpretationOptionsProvider(IOptions<OriginInterpretationOptions> options)
    {
        Options = options.Value;
    }

    string IOriginInterpretationOptionsProvider.BodyName => Options.BodyName;
    string IOriginInterpretationOptionsProvider.SiteName => Options.SiteName;
    string IOriginInterpretationOptionsProvider.GeocentricSite => Options.GeocentricSite;
    string IOriginInterpretationOptionsProvider.CustomSite => Options.CustomSite;
    string IOriginInterpretationOptionsProvider.GeodeticCoordinate => Options.GeodeticCoordinate;
    string IOriginInterpretationOptionsProvider.CylindricalCoordinate => Options.CylindricalCoordinate;
    string IOriginInterpretationOptionsProvider.ReferenceEllipsoid => Options.ReferenceEllipsoid;
    string IOriginInterpretationOptionsProvider.Radii => Options.Radii;
}

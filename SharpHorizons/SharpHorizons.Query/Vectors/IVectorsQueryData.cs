namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Epoch;
using SharpHorizons.Ephemeris;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

using SharpMeasures;
using SharpMeasures.Astronomy;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents general information about the result of a <see cref="IVectorsQuery"/>.</summary>
public interface IVectorsQueryData
{
    /// <summary>The <see cref="DateTime"/> describing when the <see cref="IVectorsQuery"/> was executed by Horizons.</summary>
    public abstract DateTime QueryTime { get; }

    /// <summary>The <see cref="ITarget"/> of the <see cref="IVectorsQuery"/>, or the object relative to which the <see cref="ITarget"/> is expressed.</summary>
    public abstract ITarget Target { get; }

    /// <summary>Indicates whether the center of <see cref="Target"/> represented the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>. If <see langword="false"/>, <see cref="TargetGeodetic"/> and <see cref="TargetCylindrical"/> describe the <see cref="ITarget"/>.</summary>
    [MemberNotNullWhen(false, nameof(TargetGeodetic), nameof(TargetCylindrical))]
    public virtual bool GeocentricTarget => TargetCylindrical is null || TargetCylindrical.Value.Height.Absolute() < Height.OneMetre && TargetCylindrical.Value.RadialDistance.Absolute() < Distance.OneMetre;

    /// <summary>The <see cref="GeodeticCoordinate"/>, relative to <see cref="Target"/>, describing the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/> - or <see langword="null"/> if no coordinate was used.</summary>
    public abstract GeodeticCoordinate? TargetGeodetic { get; }

    /// <summary>The <see cref="CylindricalCoordinate"/>, relative to <see cref="Target"/>, describing the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/> - or <see langword="null"/> if no coordinate was used.</summary>
    public abstract CylindricalCoordinate? TargetCylindrical { get; }

    /// <summary>The <see cref="IOrigin"/> of the <see cref="IVectorsQuery"/>, or the object relative to which the <see cref="IOrigin"/> is expressed.</summary>
    public abstract IOrigin Origin { get; }

    /// <summary>Indicates whether the center of <see cref="Origin"/> represented the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/>. If <see langword="false"/>, <see cref="OriginGeodetic"/> and <see cref="OriginCylindrical"/> describe the <see cref="IOrigin"/>.</summary>
    [MemberNotNullWhen(false, nameof(OriginGeodetic), nameof(OriginCylindrical))]
    public virtual bool GeocentricOrigin => OriginCylindrical is null || OriginCylindrical.Value.Height.Absolute() < Height.OneMetre && OriginCylindrical.Value.RadialDistance.Absolute() < Distance.OneMetre;

    /// <summary>The name of the origin site - or <see langword="null"/> if no origin site was used.</summary>
    public abstract string? OriginSiteName { get; }

    /// <summary>The <see cref="GeodeticCoordinate"/>, relative to <see cref="Origin"/>, describing the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/> - or <see langword="null"/> if no coordinate was used.</summary>
    public abstract GeodeticCoordinate? OriginGeodetic { get; }

    /// <summary>The <see cref="CylindricalCoordinate"/>, relative to <see cref="Origin"/>, describing the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/> - or <see langword="null"/> if no coordinate was used.</summary>
    public abstract CylindricalCoordinate? OriginCylindrical { get; }

    /// <summary>The <see cref="IEpoch"/> of the first <see cref="IEphemerisEntry"/>.</summary>
    public abstract IEpoch StartTime { get; }

    /// <summary>The <see cref="IEpoch"/> of the last <see cref="IEphemerisEntry"/>.</summary>
    public abstract IEpoch StopTime { get; }
}

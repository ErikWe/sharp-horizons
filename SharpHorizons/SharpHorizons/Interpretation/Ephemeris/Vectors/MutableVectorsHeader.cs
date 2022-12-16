namespace SharpHorizons.Interpretation.Ephemeris.Vectors;

using SharpHorizons.Interpretation.Ephemeris.Origin;
using SharpHorizons.Interpretation.Ephemeris.Target;
using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Vectors;
using SharpHorizons.Query.Vectors.Table;

using SharpMeasures;

/// <summary>A mutable <see cref="IVectorsHeader"/>.</summary>
internal sealed class MutableVectorsHeader : IVectorsHeader
{
    public IEpoch QueryEpoch { get; set; } = null!;

    /// <inheritdoc cref="IEphemerisHeader.TargetHeader"/>
    public MutableEphemerisTargetHeader TargetHeader { get; } = new();
    IEphemerisTargetHeader IEphemerisHeader.TargetHeader => TargetHeader;

    /// <inheritdoc cref="IEphemerisHeader.OriginHeader"/>
    public MutableEphemerisOriginHeader OriginHeader { get; } = new();
    IEphemerisOriginHeader IEphemerisHeader.OriginHeader => OriginHeader;

    public IEpoch StartEpoch { get; set; } = null!;
    public IEpoch StopEpoch { get; set; } = null!;
    public IStepSize? StepSize { get; set; }

    public TimeSystem TimeSystem { get; set; }
    public Time TimeZoneOffset { get; set; }

    public bool SmallPerturbers { get; set; }

    public OutputUnits OutputUnits { get; set; }
    public VectorCorrection Correction { get; set; }
    public VectorTableContent TableContent { get; set; }
    public ReferencePlane ReferencePlane { get; set; }
    public ReferenceSystem ReferenceSystem { get; set; }

    public EphemerisQuantityTable Quantities { get; set; } = null!;

    /// <summary>Validates that <paramref name="header"/> represents a valid <see cref="IVectorsHeader"/>.</summary>
    /// <param name="header">This <see cref="IVectorsHeader"/> is validated.</param>
    public static bool Validate(MutableVectorsHeader header) => header.QueryEpoch is not null && header.TargetHeader.Target is not null && header.OriginHeader.Origin is not null && header.StartEpoch is not null && header.StopEpoch is not null && header.Quantities is not null;
}

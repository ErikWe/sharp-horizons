namespace SharpHorizons.Query.Vectors;

using SharpHorizons.Ephemeris;
using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors.Table;

using SharpMeasures;

using System;
using System.ComponentModel;

/// <summary>Describes a query for an <see cref="IEphemeris{TEntry}"/> of <see cref="IOrbitalStateVectors"/>-related properties, such as <see cref="Position3"/> and <see cref="Velocity3"/>, of a <see cref="ITarget"/> relative to an <see cref="IOrigin"/>.</summary>
public interface IVectorsQuery
{
    /// <summary>The <see cref="ITarget"/>, which the resulting <see cref="IEphemeris{TEntry}"/> describes.</summary>
    public abstract ITarget Target { get; }

    /// <summary>The <see cref="IOrigin"/>, relative to which the <see cref="ITarget"/> is described in the resulting <see cref="IEphemeris{TEntry}"/>.</summary>
    public abstract IOrigin Origin { get; }

    /// <summary>The <see cref="IEpochSelection"/>, describing the <see cref="IEpoch"/> of the individual <see cref="IEphemerisEntry"/> in the resulting <see cref="IEphemeris{TEntry}"/>.</summary>
    public abstract IEpochSelection EpochSelection { get; }

    /// <summary>Determines how the result of the <see cref="IVectorsQuery"/> is formatted.</summary>
    public abstract OutputFormat OutputFormat { get; }

    /// <summary>Determines whether object data is included in the result of the <see cref="IVectorsQuery"/>.</summary>
    public abstract ObjectDataInclusion ObjectDataInclusion { get; }

    /// <summary>Used together with <see cref="ReferenceSystem"/> to determine the coordinate basis used in the resulting <see cref="IEphemeris{TEntry}"/>.</summary>
    public abstract ReferencePlane ReferencePlane { get; }

    /// <summary>Used together with <see cref="ReferencePlane"/> to determine the coordinate basis used in the resulting <see cref="IEphemeris{TEntry}"/>.</summary>
    public abstract ReferenceSystem ReferenceSystem { get; }

    /// <summary>Determines what <see cref="UnitOfLength"/> and <see cref="UnitOfTime"/> are used in the resulting <see cref="IEphemeris{TEntry}"/>.</summary>
    public abstract OutputUnits OutputUnits { get; }

    /// <summary>Determines what quantities and associated uncertainties are included in the result of the query.</summary>
    public abstract VectorTableContent TableContent { get; }

    /// <summary>Determines what corrections to apply to the result of the query.</summary>
    public abstract VectorCorrection Correction { get; }

    /// <summary>Determines with what precision time is expressed in the query and in the result of the query.</summary>
    public abstract TimePrecision TimePrecision { get; }

    /// <summary>Determines how values are separated in the result of the query.</summary>
    public abstract ValueSeparation ValueSeparation { get; }

    /// <summary>Determines whether the individual values in the result of the query are labelled.</summary>
    public abstract OutputLabels OutputLabels { get; }

    /// <summary>Determines whether the <see cref="Time"/> difference between <see cref="TimeSystem.TDB"/> and <see cref="TimeSystem.UT"/> is included in the result of the query.</summary>
    public abstract TimeDeltaInclusion TimeDeltaInclusion { get; }

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with modified <see cref="Target"/>.</summary>
    /// <param name="target"><inheritdoc cref="Target" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IVectorsQuery WithTarget(ITarget target);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with modified <see cref="Origin"/>.</summary>
    /// <param name="origin"><inheritdoc cref="Origin" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IVectorsQuery WithOrigin(IOrigin origin);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with modified <see cref="EpochSelection"/>.</summary>
    /// <param name="epochSelection"><inheritdoc cref="EpochSelection" path="/summary"/></param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IVectorsQuery WithEpochSelection(IEpochSelection epochSelection);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with modified <see cref="OutputFormat"/>.</summary>
    /// <param name="outputFormat"><inheritdoc cref="OutputFormat" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IVectorsQuery WithConfiguration(OutputFormat outputFormat);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with modified <see cref="ObjectDataInclusion"/>.</summary>
    /// <param name="objectDataInclusion"><inheritdoc cref="ObjectDataInclusion" path="/summary"/></param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IVectorsQuery WithConfiguration(ObjectDataInclusion objectDataInclusion);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with modified <see cref="ReferencePlane"/>.</summary>
    /// <param name="referencePlane"><inheritdoc cref="ReferencePlane" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IVectorsQuery WithConfiguration(ReferencePlane referencePlane);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with modified <see cref="ReferenceSystem"/>.</summary>
    /// <param name="referenceSystem"><inheritdoc cref="ReferenceSystem" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IVectorsQuery WithConfiguration(ReferenceSystem referenceSystem);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with modified <see cref="OutputUnits"/>.</summary>
    /// <param name="outputUnits"><inheritdoc cref="OutputUnits" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IVectorsQuery WithConfiguration(OutputUnits outputUnits);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with modified <see cref="TableContent"/>.</summary>
    /// <param name="tableContent"><inheritdoc cref="TableContent" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    public abstract IVectorsQuery WithConfiguration(VectorTableContent tableContent);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with modified <see cref="Correction"/>.</summary>
    /// <param name="correction"><inheritdoc cref="Correction" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IVectorsQuery WithConfiguration(VectorCorrection correction);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with modified <see cref="TimePrecision"/>.</summary>
    /// <param name="timePrecision"><inheritdoc cref="TimePrecision" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IVectorsQuery WithConfiguration(TimePrecision timePrecision);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with modified <see cref="ValueSeparation"/>.</summary>
    /// <param name="valueSeparation"><inheritdoc cref="ValueSeparation" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IVectorsQuery WithConfiguration(ValueSeparation valueSeparation);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with modified <see cref="OutputLabels"/>.</summary>
    /// <param name="outputLabels"><inheritdoc cref="OutputLabels" path="/summary"/></param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IVectorsQuery WithConfiguration(OutputLabels outputLabels);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with modified <see cref="TimeDeltaInclusion"/>.</summary>
    /// <param name="timeDeltaInclusion"><inheritdoc cref="TimeDeltaInclusion" path="/summary"/></param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract IVectorsQuery WithConfiguration(TimeDeltaInclusion timeDeltaInclusion);

    /// <summary>Constructs a new <see cref="IVectorsQuery"/> with the new configuration. Properties that correspond to a <see langword="null"/> parameter are not modified.</summary>
    /// <param name="outputFormat"><inheritdoc cref="OutputFormat" path="/summary"/></param>
    /// <param name="objectDataInclusion"><inheritdoc cref="ObjectDataInclusion" path="/summary"/></param>
    /// <param name="referencePlane"><inheritdoc cref="ReferencePlane" path="/summary"/></param>
    /// <param name="referenceSystem"><inheritdoc cref="ReferenceSystem" path="/summary"/></param>
    /// <param name="outputUnits"><inheritdoc cref="OutputUnits" path="/summary"/></param>
    /// <param name="tableContent"><inheritdoc cref="TableContent" path="/summary"/></param>
    /// <param name="correction"><inheritdoc cref="Correction" path="/summary"/></param>
    /// <param name="timePrecision"><inheritdoc cref="TimePrecision" path="/summary"/></param>
    /// <param name="valueSeparation"><inheritdoc cref="ValueSeparation" path="/summary"/></param>
    /// <param name="outputLabels"><inheritdoc cref="OutputLabels" path="/summary"/></param>
    /// <param name="timeDeltaInclusion"><inheritdoc cref="TimeDeltaInclusion" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="InvalidEnumArgumentException"/>
    /// <exception cref="UnsupportedVectorTableContentException"/>
    public abstract IVectorsQuery WithConfiguration(OutputFormat? outputFormat = null, ObjectDataInclusion? objectDataInclusion = null, ReferencePlane? referencePlane = null, ReferenceSystem? referenceSystem = null, OutputUnits? outputUnits = null,
        VectorTableContent? tableContent = null, VectorCorrection? correction = null, TimePrecision? timePrecision = null, ValueSeparation? valueSeparation = null, OutputLabels? outputLabels = null, TimeDeltaInclusion? timeDeltaInclusion = null);
}

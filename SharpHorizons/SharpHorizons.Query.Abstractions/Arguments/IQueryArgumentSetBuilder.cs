namespace SharpHorizons.Query.Arguments;

using System;

/// <summary>Handles incremental construction of <see cref="IQueryArgumentSet"/>.</summary>
public interface IQueryArgumentSetBuilder
{
    /// <summary>Constructs the <see cref="IQueryArgumentSet"/>.</summary>
    /// <remarks>Repeated invokation of <see cref="Build"/> will result in separate instances of <see cref="IQueryArgumentSet"/>.</remarks>
    /// <exception cref="InvalidOperationException"/>
    public abstract IQueryArgumentSet Build();

    /// <summary>Specifies the <see cref="IQueryArgumentSet.Command"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="command">The <see cref="IQueryArgumentSet.Command"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyCommand(ICommandArgument command);

    /// <summary>Specifies the <see cref="IQueryArgumentSet.EphemerisType"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="ephemerisType">The <see cref="IQueryArgumentSet.EphemerisType"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <remarks>To unspecify the <see cref="IQueryArgumentSet.EphemerisType"/>, use <see cref="UnspecifyEphemerisType"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyEphemerisType(IEphemerisTypeArgument ephemerisType);

    /// <summary>Unspecifies the <see cref="IQueryArgumentSet.EphemerisType"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    public abstract IQueryArgumentSetBuilder UnspecifyEphemerisType();

    /// <summary>Specifies the <see cref="IQueryArgumentSet.GenerateEphemeris"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="generateEphemeris">The <see cref="IQueryArgumentSet.GenerateEphemeris"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <remarks>To unspecify the <see cref="IQueryArgumentSet.GenerateEphemeris"/>, use <see cref="UnspecifyGenerateEphemeris"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyGenerateEphemeris(IGenerateEphemerisArgument generateEphemeris);

    /// <summary>Unspecifies the <see cref="IQueryArgumentSet.GenerateEphemeris"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    public abstract IQueryArgumentSetBuilder UnspecifyGenerateEphemeris();

    /// <summary>Specifies the <see cref="IQueryArgumentSet.OutputFormat"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="outputFormat">The <see cref="IQueryArgumentSet.OutputFormat"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <remarks>To unspecify the <see cref="IQueryArgumentSet.OutputFormat"/>, use <see cref="UnspecifyOutputFormat"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyOutputFormat(IOutputFormatArgument outputFormat);

    /// <summary>Unspecifies the <see cref="IQueryArgumentSet.OutputFormat"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    public abstract IQueryArgumentSetBuilder UnspecifyOutputFormat();

    /// <summary>Specifies the <see cref="IQueryArgumentSet.ObjectDataInclusion"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="objectDataInclusion">The <see cref="IQueryArgumentSet.ObjectDataInclusion"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <remarks>To unspecify the <see cref="IQueryArgumentSet.ObjectDataInclusion"/>, use <see cref="UnspecifyObjectDataInclusion"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyObjectDataInclusion(IObjectDataInclusionArgument objectDataInclusion);

    /// <summary>Unspecifies the <see cref="IQueryArgumentSet.ObjectDataInclusion"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    public abstract IQueryArgumentSetBuilder UnspecifyObjectDataInclusion();

    /// <summary>Specifies the <see cref="IQueryArgumentSet.Origin"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="origin">The <see cref="IQueryArgumentSet.Origin"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <remarks>To unspecify the <see cref="IQueryArgumentSet.Origin"/>, use <see cref="UnspecifyOrigin"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyOrigin(IOriginArgument origin);

    /// <summary>Unspecifies the <see cref="IQueryArgumentSet.Origin"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    public abstract IQueryArgumentSetBuilder UnspecifyOrigin();

    /// <summary>Specifies the <see cref="IQueryArgumentSet.OriginCoordinate"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="originCoordinate">The <see cref="IQueryArgumentSet.OriginCoordinate"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <remarks>To unspecify the <see cref="IQueryArgumentSet.OriginCoordinate"/>, use <see cref="UnspecifyOriginCoordinate"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyOriginCoordinate(IOriginCoordinateArgument originCoordinate);

    /// <summary>Unspecifies the <see cref="IQueryArgumentSet.OriginCoordinate"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    public abstract IQueryArgumentSetBuilder UnspecifyOriginCoordinate();

    /// <summary>Specifies the <see cref="IQueryArgumentSet.OriginCoordinateType"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="originCoordinateType">The <see cref="IQueryArgumentSet.OriginCoordinateType"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <remarks>To unspecify the <see cref="IQueryArgumentSet.OriginCoordinateType"/>, use <see cref="UnspecifyOriginCoordinateType"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyOriginCoordinateType(IOriginCoordinateTypeArgument originCoordinateType);

    /// <summary>Unspecifies the <see cref="IQueryArgumentSet.OriginCoordinateType"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    public abstract IQueryArgumentSetBuilder UnspecifyOriginCoordinateType();

    /// <summary>Specifies the <see cref="IQueryArgumentSet.EpochCollection"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="epochCollection">The <see cref="IQueryArgumentSet.EpochCollection"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <remarks>To unspecify the <see cref="IQueryArgumentSet.EpochCollection"/>, use <see cref="UnspecifyEpochCollection"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyEpochCollection(IEpochCollectionArgument epochCollection);

    /// <summary>Unspecifies the <see cref="IQueryArgumentSet.EpochCollection"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    public abstract IQueryArgumentSetBuilder UnspecifyEpochCollection();

    /// <summary>Specifies the <see cref="IQueryArgumentSet.EpochCollectionFormat"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="epochCollectionFormat">The <see cref="IQueryArgumentSet.EpochCollectionFormat"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <remarks>To unspecify the <see cref="IQueryArgumentSet.EpochCollectionFormat"/>, use <see cref="UnspecifyEpochCollectionFormat"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyEpochCollectionFormat(IEpochCollectionFormatArgument epochCollectionFormat);

    /// <summary>Unspecifies the <see cref="IQueryArgumentSet.EpochCollectionFormat"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    public abstract IQueryArgumentSetBuilder UnspecifyEpochCollectionFormat();

    /// <summary>Specifies the <see cref="IQueryArgumentSet.CalendarType"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="calendarType">The <see cref="IQueryArgumentSet.CalendarType"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <remarks>To unspecify the <see cref="IQueryArgumentSet.CalendarType"/>, use <see cref="UnspecifyCalendarType"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyCalendarType(ICalendarTypeArgument calendarType);

    /// <summary>Unspecifies the <see cref="IQueryArgumentSet.CalendarType"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    public abstract IQueryArgumentSetBuilder UnspecifyCalendarType();

    /// <summary>Specifies the <see cref="IQueryArgumentSet.TimeSystem"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="timeSystem">The <see cref="IQueryArgumentSet.TimeSystem"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <remarks>To unspecify the <see cref="IQueryArgumentSet.TimeSystem"/>, use <see cref="UnspecifyTimeSystem"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyTimeSystem(ITimeSystemArgument timeSystem);

    /// <summary>Unspecifies the <see cref="IQueryArgumentSet.TimeSystem"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    public abstract IQueryArgumentSetBuilder UnspecifyTimeSystem();

    /// <summary>Specifies the <see cref="IQueryArgumentSet.TimeZone"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="timeZone">The <see cref="IQueryArgumentSet.TimeZone"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <remarks>To unspecify the <see cref="IQueryArgumentSet.TimeZone"/>, use <see cref="UnspecifyTimeZone"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyTimeZone(ITimeZoneArgument timeZone);

    /// <summary>Unspecifies the <see cref="IQueryArgumentSet.TimeZone"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    public abstract IQueryArgumentSetBuilder UnspecifyTimeZone();

    /// <summary>Specifies the <see cref="IQueryArgumentSet.StartEpoch"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="startEpoch">The <see cref="IQueryArgumentSet.StartEpoch"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <remarks>To unspecify the <see cref="IQueryArgumentSet.StartEpoch"/>, use <see cref="UnspecifyStartEpoch"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyStartEpoch(IStartEpochArgument startEpoch);

    /// <summary>Unspecifies the <see cref="IQueryArgumentSet.StartEpoch"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    public abstract IQueryArgumentSetBuilder UnspecifyStartEpoch();

    /// <summary>Specifies the <see cref="IQueryArgumentSet.StopEpoch"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="stopEpoch">The <see cref="IQueryArgumentSet.StopEpoch"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <remarks>To unspecify the <see cref="IQueryArgumentSet.StopEpoch"/>, use <see cref="UnspecifyStopEpoch"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyStopEpoch(IStopEpochArgument stopEpoch);

    /// <summary>Unspecifies the <see cref="IQueryArgumentSet.StopEpoch"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    public abstract IQueryArgumentSetBuilder UnspecifyStopEpoch();

    /// <summary>Specifies the <see cref="IQueryArgumentSet.StepSize"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="stepSize">The <see cref="IQueryArgumentSet.StepSize"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <remarks>To unspecify the <see cref="IQueryArgumentSet.StepSize"/>, use <see cref="UnspecifyStepSize"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyStepSize(IStepSizeArgument stepSize);

    /// <summary>Unspecifies the <see cref="IQueryArgumentSet.StepSize"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    public abstract IQueryArgumentSetBuilder UnspecifyStepSize();

    /// <summary>Specifies the <see cref="IQueryArgumentSet.ReferencePlane"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="referencePlane">The <see cref="IQueryArgumentSet.ReferencePlane"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <remarks>To unspecify the <see cref="IQueryArgumentSet.ReferencePlane"/>, use <see cref="UnspecifyRwferencePlane"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyReferencePlane(IReferencePlaneArgument referencePlane);

    /// <summary>Unspecifies the <see cref="IQueryArgumentSet.ReferencePlane"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    public abstract IQueryArgumentSetBuilder UnspecifyRwferencePlane();

    /// <summary>Specifies the <see cref="IQueryArgumentSet.ReferenceSystem"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="referenceSystem">The <see cref="IQueryArgumentSet.ReferenceSystem"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <remarks>To unspecify the <see cref="IQueryArgumentSet.ReferenceSystem"/>, use <see cref="UnspecifyReferenceSystem"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyReferenceSystem(IReferenceSystemArgument referenceSystem);

    /// <summary>Unspecifies the <see cref="IQueryArgumentSet.ReferenceSystem"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    public abstract IQueryArgumentSetBuilder UnspecifyReferenceSystem();

    /// <summary>Specifies the <see cref="IQueryArgumentSet.TimePrecision"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="timePrecision">The <see cref="IQueryArgumentSet.TimePrecision"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <remarks>To unspecify the <see cref="IQueryArgumentSet.TimePrecision"/>, use <see cref="UnspecifyTimePrecision"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyTimePrecision(ITimePrecisionArgument timePrecision);

    /// <summary>Unspecifies the <see cref="IQueryArgumentSet.TimePrecision"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    public abstract IQueryArgumentSetBuilder UnspecifyTimePrecision();

    /// <summary>Specifies the <see cref="IQueryArgumentSet.VectorCorrection"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="vectorCorrection">The <see cref="IQueryArgumentSet.VectorCorrection"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <remarks>To unspecify the <see cref="IQueryArgumentSet.VectorCorrection"/>, use <see cref="UnspecifyVectorCorrection"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyVectorCorrection(IVectorCorrectionArgument vectorCorrection);

    /// <summary>Unspecifies the <see cref="IQueryArgumentSet.VectorCorrection"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    public abstract IQueryArgumentSetBuilder UnspecifyVectorCorrection();

    /// <summary>Specifies the <see cref="IQueryArgumentSet.TimeDeltaInclusion"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="timeDeltaInclusion">The <see cref="IQueryArgumentSet.TimeDeltaInclusion"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <remarks>To unspecify the <see cref="IQueryArgumentSet.TimeDeltaInclusion"/>, use <see cref="UnspecifyTimeDeltaInclusion"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyTimeDeltaInclusion(ITimeDeltaInclusionArgument timeDeltaInclusion);

    /// <summary>Unspecifies the <see cref="IQueryArgumentSet.TimeDeltaInclusion"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    public abstract IQueryArgumentSetBuilder UnspecifyTimeDeltaInclusion();

    /// <summary>Specifies the <see cref="IQueryArgumentSet.VectorTableContent"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="vectorTableContent">The <see cref="IQueryArgumentSet.VectorTableContent"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <remarks>To unspecify the <see cref="IQueryArgumentSet.VectorTableContent"/>, use <see cref="UnspecifyVectorTableContent"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyVectorTableContent(IVectorTableContentArgument vectorTableContent);

    /// <summary>Unspecifies the <see cref="IQueryArgumentSet.VectorTableContent"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    public abstract IQueryArgumentSetBuilder UnspecifyVectorTableContent();

    /// <summary>Specifies the <see cref="IQueryArgumentSet.OutputUnits"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="outputUnits">The <see cref="IQueryArgumentSet.OutputUnits"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <remarks>To unspecify the <see cref="IQueryArgumentSet.OutputUnits"/>, use <see cref="UnspecifyOutputUnits"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyOutputUnits(IOutputUnitsArgument outputUnits);

    /// <summary>Unspecifies the <see cref="IQueryArgumentSet.OutputUnits"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    public abstract IQueryArgumentSetBuilder UnspecifyOutputUnits();

    /// <summary>Specifies the <see cref="IQueryArgumentSet.VectorLabels"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="vectorLabels">The <see cref="IQueryArgumentSet.VectorLabels"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <remarks>To unspecify the <see cref="IQueryArgumentSet.VectorLabels"/>, use <see cref="UnspecifyVectorLabels"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyVectorLabels(IVectorLabelsArgument vectorLabels);

    /// <summary>Unspecifies the <see cref="IQueryArgumentSet.VectorLabels"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    public abstract IQueryArgumentSetBuilder UnspecifyVectorLabels();

    /// <summary>Specifies the <see cref="IQueryArgumentSet.ValueSeparation"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    /// <param name="valueSeparation">The <see cref="IQueryArgumentSet.ValueSeparation"/> of the <see cref="IQueryArgumentSet"/> under construction.</param>
    /// <remarks>To unspecify the <see cref="IQueryArgumentSet.ValueSeparation"/>, use <see cref="UnspecifyValueSeparation"/>.</remarks>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder SpecifyValueSeparation(IValueSeparationArgument valueSeparation);

    /// <summary>Unspecifies the <see cref="IQueryArgumentSet.ValueSeparation"/> of the <see cref="IQueryArgumentSet"/> under construction.</summary>
    public abstract IQueryArgumentSetBuilder UnspecifyValueSeparation();
}

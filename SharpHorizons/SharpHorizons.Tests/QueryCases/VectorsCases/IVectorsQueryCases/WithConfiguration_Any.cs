namespace SharpHorizons.Tests.QueryCases.VectorsCases.IVectorsQueryCases;

using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;
using SharpHorizons.Query.Vectors.Table;

using System;
using System.ComponentModel;

using Xunit;

public class WithConfiguration_Any
{
    [Fact]
    public void OutputFormat_Invalid_InvalidEnumArgumentException()
    {
        var outputFormat = GetInvalidOutputFormat();

        AnyError_TException<InvalidEnumArgumentException>(outputFormat: outputFormat);
    }

    [Fact]
    public void OutputFormat_Forbidden_ArgumentException()
    {
        var outputFormat = GetForbiddenOutputFormat();

        AnyError_TException<ArgumentException>(outputFormat);
    }

    [Fact]
    public void ObjectDataInclusion_Invalid_InvalidEnumArgumentException()
    {
        var objectDataInclusion = GetInvalidObjectDataInclusion();

        AnyError_TException<InvalidEnumArgumentException>(objectDataInclusion: objectDataInclusion);
    }

    [Fact]
    public void ReferencePlane_Invalid_InvalidEnumArgumentException()
    {
        var referencePlane = GetInvalidReferencePlane();

        AnyError_TException<InvalidEnumArgumentException>(referencePlane: referencePlane);
    }

    [Fact]
    public void ReferencePlane_Forbidden_ArgumentException()
    {
        var referencePlane = GetForbiddenReferencePlane();

        AnyError_TException<ArgumentException>(referencePlane: referencePlane);
    }

    [Fact]
    public void ReferenceSystem_Invalid_InvalidEnumArgumentException()
    {
        var referenceSystem = GetInvalidReferenceSystem();

        AnyError_TException<InvalidEnumArgumentException>(referenceSystem: referenceSystem);
    }

    [Fact]
    public void ReferenceSystem_Forbidden_ArgumentException()
    {
        var referenceSystem = GetForbiddenReferenceSystem();

        AnyError_TException<ArgumentException>(referenceSystem: referenceSystem);
    }

    [Fact]
    public void OutputUnits_Invalid_InvalidEnumArgumentException()
    {
        var outputUnits = GetInvalidOutputUnits();

        AnyError_TException<InvalidEnumArgumentException>(outputUnits: outputUnits);
    }

    [Fact]
    public void OutputUnits_Forbidden_ArgumentException()
    {
        var outputUnits = GetForbiddenOutputUnits();

        AnyError_TException<ArgumentException>(outputUnits: outputUnits);
    }

    [Fact]
    public void VectorTableContent_Invalid_ArgumentException()
    {
        var vectorTableContent = GetInvalidVectorTableContent();

        AnyError_TException<ArgumentException>(vectorTableContent: vectorTableContent);
    }

    [Fact]
    public void VectorCorrection_Invalid_InvalidEnumArgumentException()
    {
        var vectorCorrection = GetInvalidVectorCorrection();

        AnyError_TException<InvalidEnumArgumentException>(vectorCorrection: vectorCorrection);
    }

    [Fact]
    public void VectorCorrection_Forbidden_ArgumentException()
    {
        var vectorCorrection = GetForbiddenVectorCorrection();

        AnyError_TException<ArgumentException>(vectorCorrection: vectorCorrection);
    }

    [Fact]
    public void TimePrecision_Invalid_InvalidEnumArgumentException()
    {
        var timePrecision = GetInvalidTimePrecision();

        AnyError_TException<InvalidEnumArgumentException>(timePrecision: timePrecision);
    }

    [Fact]
    public void TimePrecision_Forbidden_ArgumentException()
    {
        var timePrecision = GetForbiddenTimePrecision();

        AnyError_TException<ArgumentException>(timePrecision: timePrecision);
    }

    [Fact]
    public void ValueSeparation_Invalid_InvalidEnumArgumentException()
    {
        var valueSeparation = GetInvalidValueSeparation();

        AnyError_TException<InvalidEnumArgumentException>(valueSeparation: valueSeparation);
    }

    [Fact]
    public void ValueSeparation_Forbidden_ArgumentException()
    {
        var valueSeparation = GetForbiddenValueSeparation();

        AnyError_TException<ArgumentException>(valueSeparation: valueSeparation);
    }

    [Fact]
    public void OutputLabels_Invalid_InvalidEnumArgumentException()
    {
        var outputLabels = GetInvalidOutputLabels();

        AnyError_TException<InvalidEnumArgumentException>(outputLabels: outputLabels);
    }

    [Fact]
    public void TimeDeltaInclusion_Invalid_InvalidEnumArgumentException()
    {
        var timeDeltaInclusion = GetInvalidTimeDeltaInclusion();

        AnyError_TException<InvalidEnumArgumentException>(timeDeltaInclusion: timeDeltaInclusion);
    }

    private static void AnyError_TException<TException>(OutputFormat? outputFormat = null, ObjectDataInclusion? objectDataInclusion = null, ReferencePlane? referencePlane = null, ReferenceSystem? referenceSystem = null,
        OutputUnits? outputUnits = null, VectorTableContent? vectorTableContent = null, VectorCorrection? vectorCorrection = null, TimePrecision? timePrecision = null, ValueSeparation? valueSeparation = null,
        OutputLabels? outputLabels = null, TimeDeltaInclusion? timeDeltaInclusion = null) where TException : Exception
    {
        var vectorsQuery = GetVectorsQuery();

        var exception = Record.Exception(() => InvokeWithConfiguration(vectorsQuery, outputFormat, objectDataInclusion, referencePlane, referenceSystem, outputUnits, vectorTableContent, vectorCorrection, timePrecision, valueSeparation, outputLabels, timeDeltaInclusion));

        Assert.IsType<TException>(exception);
    }

    [Fact]
    public void All_Null_NoModifications()
    {
        var vectorsQuery = GetVectorsQuery();

        var previousOutputFormat = vectorsQuery.OutputFormat;
        var previousObjectDataInclusion = vectorsQuery.ObjectDataInclusion;
        var previousReferencePlane = vectorsQuery.ReferencePlane;
        var previousReferenceSystem = vectorsQuery.ReferenceSystem;
        var previousOutputUnits = vectorsQuery.OutputUnits;
        var previousVectorTableContent = vectorsQuery.TableContent;
        var previousVectorCorrection = vectorsQuery.Correction;
        var previousTimePrecision = vectorsQuery.TimePrecision;
        var previousValueSeparation = vectorsQuery.ValueSeparation;
        var previousOutputLabels = vectorsQuery.OutputLabels;
        var previousTimeDeltaInclusion = vectorsQuery.TimeDeltaInclusion;

        var actual = InvokeWithConfiguration(vectorsQuery, outputFormat: null, objectDataInclusion: null, referencePlane: null, referenceSystem: null, outputUnits: null, vectorTableContent: null, vectorCorrection: null, timePrecision: null, valueSeparation: null, outputLabels: null, timeDeltaInclusion: null);

        Assert.Equal(previousOutputFormat, actual.OutputFormat);
        Assert.Equal(previousObjectDataInclusion, actual.ObjectDataInclusion);
        Assert.Equal(previousReferencePlane, actual.ReferencePlane);
        Assert.Equal(previousReferenceSystem, actual.ReferenceSystem);
        Assert.Equal(previousOutputUnits, actual.OutputUnits);
        Assert.Equal(previousVectorTableContent, actual.TableContent);
        Assert.Equal(previousVectorCorrection, actual.Correction);
        Assert.Equal(previousTimePrecision, actual.TimePrecision);
        Assert.Equal(previousValueSeparation, actual.ValueSeparation);
        Assert.Equal(previousOutputLabels, actual.OutputLabels);
        Assert.Equal(previousTimeDeltaInclusion, actual.TimeDeltaInclusion);
    }

    [Fact]
    public void All_Valid_ExactMatch()
    {
        var vectorsQuery = GetVectorsQuery();

        var previousOutputFormat = vectorsQuery.OutputFormat;
        var previousObjectDataInclusion = vectorsQuery.ObjectDataInclusion;
        var previousReferencePlane = vectorsQuery.ReferencePlane;
        var previousReferenceSystem = vectorsQuery.ReferenceSystem;
        var previousOutputUnits = vectorsQuery.OutputUnits;
        var previousVectorTableContent = vectorsQuery.TableContent;
        var previousVectorCorrection = vectorsQuery.Correction;
        var previousTimePrecision = vectorsQuery.TimePrecision;
        var previousValueSeparation = vectorsQuery.ValueSeparation;
        var previousOutputLabels = vectorsQuery.OutputLabels;
        var previousTimeDeltaInclusion = vectorsQuery.TimeDeltaInclusion;

        var outputFormat = GetDifferentOutputFormat(previousOutputFormat);
        var objectDataInclusion = GetDifferentObjectDataInclusion(previousObjectDataInclusion);
        var referencePlane = GetDifferentReferencePlane(previousReferencePlane);
        var referenceSystem = GetDifferentReferenceSystem(previousReferenceSystem);
        var outputUnits = GetDifferentOutputUnits(previousOutputUnits);
        var vectorTableContent = GetDifferentVectorTableContent(previousVectorTableContent);
        var vectorCorrection = GetDifferentVectorCorrection(previousVectorCorrection);
        var timePrecision = GetDifferentTimePrecision(previousTimePrecision);
        var valueSeparation = GetDifferentValueSeparation(previousValueSeparation);
        var outputLabels = GetDifferentOutputLabels(previousOutputLabels);
        var timeDeltaInclusion = GetDifferentTimeDeltaInclusion(previousTimeDeltaInclusion);

        var actual = InvokeWithConfiguration(vectorsQuery, outputFormat, objectDataInclusion, referencePlane, referenceSystem, outputUnits, vectorTableContent, vectorCorrection, timePrecision, valueSeparation, outputLabels, timeDeltaInclusion);

        Assert.NotEqual(previousOutputFormat, outputFormat);
        Assert.NotEqual(previousObjectDataInclusion, objectDataInclusion);
        Assert.NotEqual(previousReferencePlane, referencePlane);
        Assert.NotEqual(previousReferenceSystem, referenceSystem);
        Assert.NotEqual(previousOutputUnits, outputUnits);
        Assert.NotEqual(previousVectorTableContent, vectorTableContent);
        Assert.NotEqual(previousVectorCorrection, vectorCorrection);
        Assert.NotEqual(previousTimePrecision, timePrecision);
        Assert.NotEqual(previousValueSeparation, valueSeparation);
        Assert.NotEqual(previousOutputLabels, outputLabels);
        Assert.NotEqual(previousTimeDeltaInclusion, timeDeltaInclusion);

        Assert.Equal(outputFormat, actual.OutputFormat);
        Assert.Equal(objectDataInclusion, actual.ObjectDataInclusion);
        Assert.Equal(referencePlane, actual.ReferencePlane);
        Assert.Equal(referenceSystem, actual.ReferenceSystem);
        Assert.Equal(outputUnits, actual.OutputUnits);
        Assert.Equal(vectorTableContent, actual.TableContent);
        Assert.Equal(vectorCorrection, actual.Correction);
        Assert.Equal(timePrecision, actual.TimePrecision);
        Assert.Equal(valueSeparation, actual.ValueSeparation);
        Assert.Equal(outputLabels, actual.OutputLabels);
        Assert.Equal(timeDeltaInclusion, actual.TimeDeltaInclusion);
    }

    [Fact]
    public void All_Valid_OriginalUnmodified()
    {
        var vectorsQuery = GetVectorsQuery();

        var previousOutputFormat = vectorsQuery.OutputFormat;
        var previousObjectDataInclusion = vectorsQuery.ObjectDataInclusion;
        var previousReferencePlane = vectorsQuery.ReferencePlane;
        var previousReferenceSystem = vectorsQuery.ReferenceSystem;
        var previousOutputUnits = vectorsQuery.OutputUnits;
        var previousVectorTableContent = vectorsQuery.TableContent;
        var previousVectorCorrection = vectorsQuery.Correction;
        var previousTimePrecision = vectorsQuery.TimePrecision;
        var previousValueSeparation = vectorsQuery.ValueSeparation;
        var previousOutputLabels = vectorsQuery.OutputLabels;
        var previousTimeDeltaInclusion = vectorsQuery.TimeDeltaInclusion;

        var outputFormat = GetDifferentOutputFormat(previousOutputFormat);
        var objectDataInclusion = GetDifferentObjectDataInclusion(previousObjectDataInclusion);
        var referencePlane = GetDifferentReferencePlane(previousReferencePlane);
        var referenceSystem = GetDifferentReferenceSystem(previousReferenceSystem);
        var outputUnits = GetDifferentOutputUnits(previousOutputUnits);
        var vectorTableContent = GetDifferentVectorTableContent(previousVectorTableContent);
        var vectorCorrection = GetDifferentVectorCorrection(previousVectorCorrection);
        var timePrecision = GetDifferentTimePrecision(previousTimePrecision);
        var valueSeparation = GetDifferentValueSeparation(previousValueSeparation);
        var outputLabels = GetDifferentOutputLabels(previousOutputLabels);
        var timeDeltaInclusion = GetDifferentTimeDeltaInclusion(previousTimeDeltaInclusion);

        InvokeWithConfiguration(vectorsQuery, outputFormat, objectDataInclusion, referencePlane, referenceSystem, outputUnits, vectorTableContent, vectorCorrection, timePrecision, valueSeparation, outputLabels, timeDeltaInclusion);

        Assert.NotEqual(previousOutputFormat, outputFormat);
        Assert.NotEqual(previousObjectDataInclusion, objectDataInclusion);
        Assert.NotEqual(previousReferencePlane, referencePlane);
        Assert.NotEqual(previousReferenceSystem, referenceSystem);
        Assert.NotEqual(previousOutputUnits, outputUnits);
        Assert.NotEqual(previousVectorTableContent, vectorTableContent);
        Assert.NotEqual(previousVectorCorrection, vectorCorrection);
        Assert.NotEqual(previousTimePrecision, timePrecision);
        Assert.NotEqual(previousValueSeparation, valueSeparation);
        Assert.NotEqual(previousOutputLabels, outputLabels);
        Assert.NotEqual(previousTimeDeltaInclusion, timeDeltaInclusion);

        Assert.Equal(previousOutputFormat, vectorsQuery.OutputFormat);
        Assert.Equal(previousObjectDataInclusion, vectorsQuery.ObjectDataInclusion);
        Assert.Equal(previousReferencePlane, vectorsQuery.ReferencePlane);
        Assert.Equal(previousReferenceSystem, vectorsQuery.ReferenceSystem);
        Assert.Equal(previousOutputUnits, vectorsQuery.OutputUnits);
        Assert.Equal(previousVectorTableContent, vectorsQuery.TableContent);
        Assert.Equal(previousVectorCorrection, vectorsQuery.Correction);
        Assert.Equal(previousTimePrecision, vectorsQuery.TimePrecision);
        Assert.Equal(previousValueSeparation, vectorsQuery.ValueSeparation);
        Assert.Equal(previousOutputLabels, vectorsQuery.OutputLabels);
        Assert.Equal(previousTimeDeltaInclusion, vectorsQuery.TimeDeltaInclusion);
    }

    private static IVectorsQuery InvokeWithConfiguration(IVectorsQuery vectorsQuery, OutputFormat? outputFormat = null, ObjectDataInclusion? objectDataInclusion = null, ReferencePlane? referencePlane = null, ReferenceSystem? referenceSystem = null,
        OutputUnits? outputUnits = null, VectorTableContent? vectorTableContent = null, VectorCorrection? vectorCorrection = null, TimePrecision? timePrecision = null, ValueSeparation? valueSeparation = null,
        OutputLabels? outputLabels = null, TimeDeltaInclusion? timeDeltaInclusion = null)
    {
        return vectorsQuery.WithConfiguration(outputFormat, objectDataInclusion, referencePlane, referenceSystem, outputUnits, vectorTableContent, vectorCorrection, timePrecision, valueSeparation, outputLabels, timeDeltaInclusion);
    }

    private static IVectorsQuery GetVectorsQuery()
    {
        var factory = DependencyInjection.GetRequiredService<IVectorsQueryFactory>();

        return factory.Create(GetValidTarget(), GetValidOrigin(), GetValidEpochSelection());
    }

    private static ITarget GetValidTarget()
    {
        var factory = DependencyInjection.GetRequiredService<ITargetFactory>();

        return factory.Create(new MajorObjectID(301));
    }

    private static IOrigin GetValidOrigin()
    {
        var factory = DependencyInjection.GetRequiredService<IOriginFactory>();

        return factory.Create(new MajorObjectID(399));
    }

    private static IEpochSelection GetValidEpochSelection()
    {
        var factory = DependencyInjection.GetRequiredService<IEpochCollectionFactory>();

        return factory.Create(JulianDay.Epoch);
    }

    private static OutputFormat GetInvalidOutputFormat() => (OutputFormat)(-1);
    private static OutputFormat GetForbiddenOutputFormat() => OutputFormat.Unknown;
    private static OutputFormat GetDifferentOutputFormat(OutputFormat outputFormat) => outputFormat switch
    {
        OutputFormat.JSON => OutputFormat.Text,
        OutputFormat.Text => OutputFormat.JSON,
        _ => throw new InvalidEnumArgumentException()
    };

    private static ObjectDataInclusion GetInvalidObjectDataInclusion() => (ObjectDataInclusion)(-1);
    private static ObjectDataInclusion GetDifferentObjectDataInclusion(ObjectDataInclusion objectDataInclusion) => objectDataInclusion switch
    {
        ObjectDataInclusion.Enable => ObjectDataInclusion.Disable,
        ObjectDataInclusion.Disable => ObjectDataInclusion.Enable,
        _ => throw new InvalidEnumArgumentException()
    };

    private static ReferencePlane GetInvalidReferencePlane() => (ReferencePlane)(-1);
    private static ReferencePlane GetForbiddenReferencePlane() => ReferencePlane.Unknown;
    private static ReferencePlane GetDifferentReferencePlane(ReferencePlane referencePlane) => referencePlane switch
    {
        ReferencePlane.Ecliptic => ReferencePlane.Frame,
        ReferencePlane.Frame => ReferencePlane.BodyEquator,
        ReferencePlane.BodyEquator => ReferencePlane.Ecliptic,
        _ => throw new InvalidEnumArgumentException()
    };

    private static ReferenceSystem GetInvalidReferenceSystem() => (ReferenceSystem)(-1);
    private static ReferenceSystem GetForbiddenReferenceSystem() => ReferenceSystem.Unknown;
    private static ReferenceSystem GetDifferentReferenceSystem(ReferenceSystem referenceSystem) => referenceSystem switch
    {
        ReferenceSystem.ICRF => ReferenceSystem.B1950,
        ReferenceSystem.B1950 => ReferenceSystem.ICRF,
        _ => throw new InvalidEnumArgumentException()
    };

    private static OutputUnits GetInvalidOutputUnits() => (OutputUnits)(-1);
    private static OutputUnits GetForbiddenOutputUnits() => OutputUnits.Unknown;
    private static OutputUnits GetDifferentOutputUnits(OutputUnits outputUnits) => outputUnits switch
    {
        OutputUnits.KilometresAndSeconds => OutputUnits.KilometresAndDays,
        OutputUnits.KilometresAndDays => OutputUnits.AstronomicalUnitsAndDays,
        OutputUnits.AstronomicalUnitsAndDays => OutputUnits.KilometresAndSeconds,
        _ => throw new InvalidEnumArgumentException()
    };

    private static VectorTableContent GetInvalidVectorTableContent() => new(VectorTableQuantities.All, VectorTableUncertainties.XYZ);
    private static VectorTableContent GetDifferentVectorTableContent(VectorTableContent vectorTableContent) => new(GetDifferentVectorTableQuantities(vectorTableContent.Quantities));

    private static VectorTableQuantities GetDifferentVectorTableQuantities(VectorTableQuantities vectorTableQuantities) => vectorTableQuantities switch
    {
        VectorTableQuantities.Position => VectorTableQuantities.Velocity,
        VectorTableQuantities.Velocity => VectorTableQuantities.Distance,
        VectorTableQuantities.Distance => VectorTableQuantities.StateVectors,
        VectorTableQuantities.StateVectors => VectorTableQuantities.Position | VectorTableQuantities.Distance,
        VectorTableQuantities.Position | VectorTableQuantities.Distance => VectorTableQuantities.All,
        VectorTableQuantities.All => VectorTableQuantities.Position,
        _ => throw new InvalidEnumArgumentException()
    };

    private static VectorCorrection GetInvalidVectorCorrection() => (VectorCorrection)(-1);
    private static VectorCorrection GetForbiddenVectorCorrection() => VectorCorrection.Aberration;
    private static VectorCorrection GetDifferentVectorCorrection(VectorCorrection vectorCorrection) => vectorCorrection switch
    {
        VectorCorrection.None => VectorCorrection.LightTime,
        VectorCorrection.LightTime => VectorCorrection.All,
        VectorCorrection.All => VectorCorrection.None,
        _ => throw new InvalidEnumArgumentException()
    };

    private static TimePrecision GetInvalidTimePrecision() => (TimePrecision)(-1);
    private static TimePrecision GetForbiddenTimePrecision() => TimePrecision.Unknown;
    private static TimePrecision GetDifferentTimePrecision(TimePrecision timePrecision) => timePrecision switch
    {
        TimePrecision.Second => TimePrecision.Millisecond,
        TimePrecision.Millisecond => TimePrecision.Minute,
        TimePrecision.Minute => TimePrecision.Second,
        _ => throw new InvalidEnumArgumentException()
    };

    private static ValueSeparation GetInvalidValueSeparation() => (ValueSeparation)(-1);
    private static ValueSeparation GetForbiddenValueSeparation() => ValueSeparation.Unknown;
    private static ValueSeparation GetDifferentValueSeparation(ValueSeparation valueSeparation) => valueSeparation switch
    {
        ValueSeparation.WhitespaceSeparation => ValueSeparation.CommaSeparation,
        ValueSeparation.CommaSeparation => ValueSeparation.WhitespaceSeparation,
        _ => throw new InvalidEnumArgumentException()
    };

    private static OutputLabels GetInvalidOutputLabels() => (OutputLabels)(-1);
    private static OutputLabels GetDifferentOutputLabels(OutputLabels outputLabels) => outputLabels switch
    {
        OutputLabels.Enable => OutputLabels.Disable,
        OutputLabels.Disable => OutputLabels.Enable,
        _ => throw new InvalidEnumArgumentException()
    };

    private static TimeDeltaInclusion GetInvalidTimeDeltaInclusion() => (TimeDeltaInclusion)(-1);
    private static TimeDeltaInclusion GetDifferentTimeDeltaInclusion(TimeDeltaInclusion timeDeltaInclusion) => timeDeltaInclusion switch
    {
        TimeDeltaInclusion.Enable => TimeDeltaInclusion.Disable,
        TimeDeltaInclusion.Disable => TimeDeltaInclusion.Enable,
        _ => throw new InvalidEnumArgumentException()
    };
}

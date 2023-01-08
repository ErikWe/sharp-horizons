namespace SharpHorizons.Tests.QueryCases.VectorsCases;

using Moq;

using SharpHorizons.Query;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;
using SharpHorizons.Query.Vectors.Table;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

public class InvalidVectorsQueries : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new SloppyVectorsQuery() };

        yield return new object[] { GetValidVectorsQuery() with { Target = GetNullTarget() } };
        yield return new object[] { GetValidVectorsQuery() with { Origin = GetNullOrigin() } };
        yield return new object[] { GetValidVectorsQuery() with { EpochSelection = GetNullEpochSelection() } };
        yield return new object[] { GetValidVectorsQuery() with { OutputFormat = GetInvalidOutputFormat() } };
        yield return new object[] { GetValidVectorsQuery() with { OutputFormat = GetForbiddenOutputFormat() } };
        yield return new object[] { GetValidVectorsQuery() with { ObjectDataInclusion = GetInvalidObjectDataInclusion() } };
        yield return new object[] { GetValidVectorsQuery() with { ReferencePlane = GetInvalidReferencePlane() } };
        yield return new object[] { GetValidVectorsQuery() with { ReferencePlane = GetForbiddenReferencePlane() } };
        yield return new object[] { GetValidVectorsQuery() with { ReferenceSystem = GetInvalidReferenceSystem() } };
        yield return new object[] { GetValidVectorsQuery() with { ReferenceSystem = GetForbiddenReferenceSystem() } };
        yield return new object[] { GetValidVectorsQuery() with { OutputUnits = GetInvalidOutputUnits() } };
        yield return new object[] { GetValidVectorsQuery() with { OutputUnits = GetForbiddenOutputUnits() } };
        yield return new object[] { GetValidVectorsQuery() with { TableContent = GetInvalidVectorTableContent() } };
        yield return new object[] { GetValidVectorsQuery() with { Correction = GetInvalidVectorCorrection() } };
        yield return new object[] { GetValidVectorsQuery() with { Correction = GetForbiddenVectorCorrection() } };
        yield return new object[] { GetValidVectorsQuery() with { TimePrecision = GetInvalidTimePrecision() } };
        yield return new object[] { GetValidVectorsQuery() with { TimePrecision = GetForbiddenTimePrecision() } };
        yield return new object[] { GetValidVectorsQuery() with { ValueSeparation = GetInvalidValueSeparation() } };
        yield return new object[] { GetValidVectorsQuery() with { ValueSeparation = GetForbiddenValueSeparation() } };
        yield return new object[] { GetValidVectorsQuery() with { OutputLabels = GetInvalidOutputLabels() } };
        yield return new object[] { GetValidVectorsQuery() with { TimeDeltaInclusion = GetInvalidTimeDeltaInclusion() } };

        yield return new object[] { MockException((vectorsQuery) => vectorsQuery.Target) };
        yield return new object[] { MockException((vectorsQuery) => vectorsQuery.Origin) };
        yield return new object[] { MockException((vectorsQuery) => vectorsQuery.EpochSelection) };
        yield return new object[] { MockException((vectorsQuery) => vectorsQuery.OutputFormat) };
        yield return new object[] { MockException((vectorsQuery) => vectorsQuery.ObjectDataInclusion) };
        yield return new object[] { MockException((vectorsQuery) => vectorsQuery.ReferencePlane) };
        yield return new object[] { MockException((vectorsQuery) => vectorsQuery.ReferenceSystem) };
        yield return new object[] { MockException((vectorsQuery) => vectorsQuery.OutputUnits) };
        yield return new object[] { MockException((vectorsQuery) => vectorsQuery.TableContent) };
        yield return new object[] { MockException((vectorsQuery) => vectorsQuery.Correction) };
        yield return new object[] { MockException((vectorsQuery) => vectorsQuery.TimePrecision) };
        yield return new object[] { MockException((vectorsQuery) => vectorsQuery.ValueSeparation) };
        yield return new object[] { MockException((vectorsQuery) => vectorsQuery.OutputLabels) };
        yield return new object[] { MockException((vectorsQuery) => vectorsQuery.TimeDeltaInclusion) };
    }

    private static IVectorsQuery MockException<T>(Expression<Func<SloppyVectorsQuery, T>> expression)
    {
        var mock = new Mock<SloppyVectorsQuery>();

        mock.Setup(expression).Throws(new Exception());

        return mock.Object;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private static SloppyVectorsQuery GetValidVectorsQuery()
    {
        return new()
        {
            Target = GetValidTarget(),
            Origin = GetValidOrigin(),
            EpochSelection = GetValidEpochSelection(),
            OutputFormat = GetValidOutputFormat(),
            ObjectDataInclusion = GetValidObjectDataInclusion(),
            ReferencePlane = GetValidReferencePlane(),
            ReferenceSystem = GetValidReferenceSystem(),
            OutputUnits = GetValidOutputUnits(),
            TableContent = GetValidVectorTableContent(),
            Correction = GetValidVectorCorrection(),
            TimePrecision = GetValidTimePrecision(),
            ValueSeparation = GetValidValueSeparation(),
            OutputLabels = GetValidOutputLabels(),
            TimeDeltaInclusion = GetValidTimeDeltaInclusion()
        };
    }

    private static ITarget GetNullTarget() => null!;
    private static ITarget GetValidTarget()
    {
        var targetFactory = DependencyInjection.GetRequiredService<ITargetFactory>();

        return targetFactory.Create(new MajorObjectID(301));
    }

    private static IOrigin GetNullOrigin() => null!;
    private static IOrigin GetValidOrigin()
    {
        var originFactory = DependencyInjection.GetRequiredService<IOriginFactory>();

        return originFactory.Create(new MajorObjectID(399));
    }

    private static IEpochSelection GetNullEpochSelection() => null!;
    private static IEpochSelection GetValidEpochSelection()
    {
        var epochSelectionFactory = DependencyInjection.GetRequiredService<IEpochCollectionFactory>();

        return epochSelectionFactory.Create(JulianDay.Epoch);
    }

    private static OutputFormat GetInvalidOutputFormat() => (OutputFormat)(-1);
    private static OutputFormat GetForbiddenOutputFormat() => OutputFormat.Unknown;
    private static OutputFormat GetValidOutputFormat() => OutputFormat.JSON;

    private static ObjectDataInclusion GetInvalidObjectDataInclusion() => (ObjectDataInclusion)(-1);
    private static ObjectDataInclusion GetValidObjectDataInclusion() => ObjectDataInclusion.Enable;

    private static ReferencePlane GetInvalidReferencePlane() => (ReferencePlane)(-1);
    private static ReferencePlane GetForbiddenReferencePlane() => ReferencePlane.Unknown;
    private static ReferencePlane GetValidReferencePlane() => ReferencePlane.Ecliptic;

    private static ReferenceSystem GetInvalidReferenceSystem() => (ReferenceSystem)(-1);
    private static ReferenceSystem GetForbiddenReferenceSystem() => ReferenceSystem.Unknown;
    private static ReferenceSystem GetValidReferenceSystem() => ReferenceSystem.ICRF;

    private static OutputUnits GetInvalidOutputUnits() => (OutputUnits)(-1);
    private static OutputUnits GetForbiddenOutputUnits() => OutputUnits.Unknown;
    private static OutputUnits GetValidOutputUnits() => OutputUnits.KilometresAndSeconds;

    private static VectorTableContent GetInvalidVectorTableContent() => new(VectorTableQuantities.All, VectorTableUncertainties.XYZ);
    private static VectorTableContent GetValidVectorTableContent() => new(VectorTableQuantities.StateVectors);

    private static VectorCorrection GetInvalidVectorCorrection() => (VectorCorrection)(-1);
    private static VectorCorrection GetForbiddenVectorCorrection() => VectorCorrection.Aberration;
    private static VectorCorrection GetValidVectorCorrection() => VectorCorrection.LightTime;

    private static TimePrecision GetInvalidTimePrecision() => (TimePrecision)(-1);
    private static TimePrecision GetForbiddenTimePrecision() => TimePrecision.Unknown;
    private static TimePrecision GetValidTimePrecision() => TimePrecision.Second;

    private static ValueSeparation GetInvalidValueSeparation() => (ValueSeparation)(-1);
    private static ValueSeparation GetForbiddenValueSeparation() => ValueSeparation.Unknown;
    private static ValueSeparation GetValidValueSeparation() => ValueSeparation.CommaSeparation;

    private static OutputLabels GetInvalidOutputLabels() => (OutputLabels)(-1);
    private static OutputLabels GetValidOutputLabels() => OutputLabels.Enable;

    private static TimeDeltaInclusion GetInvalidTimeDeltaInclusion() => (TimeDeltaInclusion)(-1);
    private static TimeDeltaInclusion GetValidTimeDeltaInclusion() => TimeDeltaInclusion.Enable;
}

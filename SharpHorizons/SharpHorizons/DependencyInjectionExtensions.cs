namespace SharpHorizons;

using Microsoft.Extensions.DependencyInjection;

using SharpHorizons.Calendars;
using SharpHorizons.Identification;
using SharpHorizons.Query;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.VectorTable;
using SharpHorizons.Vectors;
using SharpHorizons.Vectors.Fluency;

using SharpMeasures.Astronomy;

/// <summary>Extensions relating to dependency injection.</summary>
public static class DependencyInjectionExtensions
{
    /// <summary>Adds services required by SharpHorizons to <paramref name="services"/>.</summary>
    /// <param name="services">Services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    public static IServiceCollection AddSharpHorizons(this IServiceCollection services)
    {
        services.AddSharpHorizonsTarget();
        services.AddSharpHorizonsOrigin();
        services.AddSharpHorizonsEpoch();
        services.AddSharpHorizonsVectors();
        services.AddSharpHorizonsComposers();

        return services;
    }

    /// <summary>Adds <see cref="ITarget"/>-related services required by SharpHorizons to <paramref name="services"/>.</summary>
    /// <param name="services"><see cref="ITarget"/>-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    private static IServiceCollection AddSharpHorizonsTarget(this IServiceCollection services)
    {
        services.AddSingleton<ITargetFactory, TargetFactory>();

        services.AddSingleton<IMajorObjectTargetFactory, MajorObjectTargetFactory>();
        services.AddSingleton<IMPCTargetFactory, MPCTargetFactory>();

        services.AddSingleton<ITargetSiteFactory, TargetSiteFactory>();
        services.AddSingleton<ITargetSiteObjectFactory, TargetSiteObjectFactory>();

        services.AddSingleton<ITargetSiteComposer<CylindricalCoordinate>, Query.Target.CylindricalCoordinateComposer>();
        services.AddSingleton<ITargetSiteComposer<GeodeticCoordinate>, Query.Target.GeodeticCoordinateComposer>();

        services.AddSingleton<ITargetSiteObjectComposer<MajorObject>, Query.Target.MajorObjectComposer>();
        services.AddSingleton<ITargetSiteObjectComposer<MajorObjectID>, Query.Target.MajorObjectIDComposer>();
        services.AddSingleton<ITargetSiteObjectComposer<MajorObjectName>, Query.Target.MajorObjectNameComposer>();

        services.AddSingleton(VectorsQuery.Instantiation);

        return services;
    }

    /// <summary>Adds <see cref="IOrigin"/>-related services required by SharpHorizons to <paramref name="services"/>.</summary>
    /// <param name="services"><see cref="IOrigin"/>-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    private static IServiceCollection AddSharpHorizonsOrigin(this IServiceCollection services)
    {
        services.AddSingleton<IOriginFactory, OriginFactory>();
        services.AddSingleton<IOriginObjectFactory, OriginObjectFactory>();

        services.AddSingleton<IOriginCoordinateFactory<CylindricalCoordinate>, CylindricalOriginCoordinateFactory>();
        services.AddSingleton<IOriginCoordinateFactory<GeodeticCoordinate>, GeodeticOriginCoordinateFactory>();

        services.AddSingleton<IOriginObjectComposer<MajorObject>, Query.Origin.MajorObjectComposer>();
        services.AddSingleton<IOriginObjectComposer<MajorObjectID>, Query.Origin.MajorObjectIDComposer>();
        services.AddSingleton<IOriginObjectComposer<MajorObjectName>, Query.Origin.MajorObjectNameComposer>();

        return services;
    }

    /// <summary>Adds <see cref="IEpoch"/>-related services required by SharpHorizons to <paramref name="services"/>.</summary>
    /// <param name="services"><see cref="IEpoch"/>-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    private static IServiceCollection AddSharpHorizonsEpoch(this IServiceCollection services)
    {
        services.AddSingleton<IEpochCollectionFactory, EpochCollectionFactory>();

        services.AddSingleton<IFixedEpochRangeFactory, EpochRangeFactory>();
        services.AddSingleton<IUniformEpochRangeFactory, EpochRangeFactory>();
        services.AddSingleton<ICalendarEpochRangeFactory, EpochRangeFactory>();
        services.AddSingleton<IAngularEpochRangeFactory, EpochRangeFactory>();

        services.AddSingleton<IFixedStepSizeFactory, StepSizeFactory>();
        services.AddSingleton<IUniformStepSizeFactory, StepSizeFactory>();
        services.AddSingleton<ICalendarStepSizeFactory, StepSizeFactory>();
        services.AddSingleton<IAngularStepSizeFactory, StepSizeFactory>();

        return services;
    }

    /// <summary>Adds <see cref="OrbitalStateVectors"/>-related services required by SharpHorizons to <paramref name="services"/>.</summary>
    /// <param name="services"><see cref="OrbitalStateVectors"/>-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    private static IServiceCollection AddSharpHorizonsVectors(this IServiceCollection services)
    {
        services.AddSingleton<IVectorsQueryFactory, VectorsQueryFactory>();

        services.AddSingleton<ITargetStageFactory, TargetStageFactory>();
        services.AddSingleton<IOriginStageFactory, OriginStageFactory>();
        services.AddSingleton<IEpochStageFactory, EpochStageFactory>();

        return services;
    }

    /// <summary>Adds <see cref="IArgumentComposer{TArgument, T}"/>-related services required by SharpHorizons to <paramref name="services"/>.</summary>
    /// <param name="services"><see cref="IArgumentComposer{TArgument, T}"/>-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    private static IServiceCollection AddSharpHorizonsComposers(this IServiceCollection services)
    {
        services.AddSingleton<ITargetComposer<MajorObject>, Query.Target.MajorObjectComposer>();
        services.AddSingleton<ITargetComposer<MajorObjectID>, Query.Target.MajorObjectIDComposer>();
        services.AddSingleton<ITargetComposer<MajorObjectName>, Query.Target.MajorObjectNameComposer>();

        services.AddSingleton<ITargetComposer<MPCObject>, MPCObjectTargetComposer>();
        services.AddSingleton<ITargetComposer<MPCProvisionalObject>, MPCProvisionalObjectTargetComposer>();
        services.AddSingleton<ITargetComposer<MPCName>, MPCNameTargetComposer>();
        services.AddSingleton<ITargetComposer<MPCProvisionalDesignation>, MPCProvisionalDesignationTargetComposer>();
        services.AddSingleton<ITargetComposer<MPCSequentialNumber>, MPCSequentialNumberTargetComposer>();

        services.AddSingleton<ITargetComposer<ISiteTarget>, SiteTargetComposer>();

        services.AddSingleton<IOriginComposer<IBodyCentricOrigin>, BodyCentricOriginComposer>();
        services.AddSingleton<IOriginComposer<ICoordinateOrigin>, CoordinateOriginComposer>();
        services.AddSingleton<IOriginComposer<IObservationSiteOrigin>, ObservationSiteOriginComposer>();

        services.AddSingleton<IOriginCoordinateComposer<CylindricalCoordinate>, Query.Origin.CylindricalCoordinateComposer>();
        services.AddSingleton<IOriginCoordinateComposer<GeodeticCoordinate>, Query.Origin.GeodeticCoordinateComposer>();

        services.AddSingleton<IOriginCoordinateTypeComposer<CylindricalCoordinate>, Query.Origin.CylindricalCoordinateComposer>();
        services.AddSingleton<IOriginCoordinateTypeComposer<GeodeticCoordinate>, Query.Origin.GeodeticCoordinateComposer>();

        services.AddSingleton<IEpochCollectionComposer<IEpochCollection>, EpochCollectionComposer>();
        services.AddSingleton<IEpochCollectionFormatComposer, EpochCollectionFormatComposer>();

        services.AddSingleton<IStartEpochComposer<IEpoch>, EpochRangeEpochComposer>();
        services.AddSingleton<IStopEpochComposer<IEpoch>, EpochRangeEpochComposer>();

        services.AddSingleton<IStepSizeComposer<IFixedStepSize>, FixedStepSizeComposer>();
        services.AddSingleton<IStepSizeComposer<IUniformStepSize>, UniformStepSizeComposer>();
        services.AddSingleton<IStepSizeComposer<ICalendarStepSize>, CalendarStepSizeComposer>();
        services.AddSingleton<IStepSizeComposer<IAngularStepSize>, AngularStepSizeComposer>();

        services.AddSingleton<IVectorTableContentComposer, VectorTableContentComposer>();

        services.AddSingleton<IEphemerisTypeComposer, EphemerisTypeComposer>();
        services.AddSingleton<IGenerateEphemeridesComposer, GenerateEphemeridesComposer>();
        services.AddSingleton<IObjectDataInclusionComposer, ObjectDataInclusionComposer>();
        services.AddSingleton<IOutputFormatComposer, OutputFormatComposer>();
        services.AddSingleton<IOutputLabelsComposer, OutputLabelsComposer>();
        services.AddSingleton<IOutputUnitsComposer, OutputUnitsComposer>();
        services.AddSingleton<IReferencePlaneComposer, ReferencePlaneComposer>();
        services.AddSingleton<IReferenceSystemComposer, ReferenceSystemComposer>();
        services.AddSingleton<ITimeDeltaInclusionComposer, TimeDeltaInclusionComposer>();
        services.AddSingleton<ITimePrecisionComposer, TimePrecisionComposer>();
        services.AddSingleton<IVectorCorrectionComposer, VectorCorrectionComposer>();

        return services;
    }
}

namespace SharpHorizons;

using Microsoft.Extensions.DependencyInjection;

using SharpHorizons.Calendars;
using SharpHorizons.Identity;
using SharpHorizons.Query.Arguments.Composers;
using SharpHorizons.Query.Arguments.Composers.Epoch;
using SharpHorizons.Query.Arguments.Composers.Origin;
using SharpHorizons.Query.Arguments.Composers.Target;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;
using SharpHorizons.Query.Vectors.Fluency;

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

        services.AddSingleton<ITargetSiteComposer<CylindricalCoordinate>, Query.Arguments.Composers.Target.CylindricalCoordinateComposer>();
        services.AddSingleton<ITargetSiteComposer<GeodeticCoordinate>, Query.Arguments.Composers.Target.GeodeticCoordinateComposer>();

        services.AddSingleton<ITargetSiteObjectComposer<MajorObject>, Query.Arguments.Composers.Target.MajorObjectComposer>();
        services.AddSingleton<ITargetSiteObjectComposer<MajorObjectID>, Query.Arguments.Composers.Target.MajorObjectIDComposer>();
        services.AddSingleton<ITargetSiteObjectComposer<MajorObjectName>, Query.Arguments.Composers.Target.MajorObjectNameComposer>();

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

        services.AddSingleton<IOriginObjectComposer<MajorObject>, Query.Arguments.Composers.Origin.MajorObjectComposer>();
        services.AddSingleton<IOriginObjectComposer<MajorObjectID>, Query.Arguments.Composers.Origin.MajorObjectIDComposer>();
        services.AddSingleton<IOriginObjectComposer<MajorObjectName>, Query.Arguments.Composers.Origin.MajorObjectNameComposer>();

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
        services.AddSingleton<ICommandComposer<MajorObject>, Query.Arguments.Composers.Target.MajorObjectComposer>();
        services.AddSingleton<ICommandComposer<MajorObjectID>, Query.Arguments.Composers.Target.MajorObjectIDComposer>();
        services.AddSingleton<ICommandComposer<MajorObjectName>, Query.Arguments.Composers.Target.MajorObjectNameComposer>();

        services.AddSingleton<ICommandComposer<MPCObject>, MPCObjectTargetComposer>();
        services.AddSingleton<ICommandComposer<MPCProvisionalObject>, MPCProvisionalObjectTargetComposer>();
        services.AddSingleton<ICommandComposer<MPCName>, MPCNameTargetComposer>();
        services.AddSingleton<ICommandComposer<MPCProvisionalDesignation>, MPCProvisionalDesignationTargetComposer>();
        services.AddSingleton<ICommandComposer<MPCSequentialNumber>, MPCSequentialNumberTargetComposer>();

        services.AddSingleton<ICommandComposer<ISiteTarget>, SiteTargetComposer>();

        services.AddSingleton<IOriginComposer<IBodyCentricOrigin>, BodyCentricOriginComposer>();
        services.AddSingleton<IOriginComposer<ICoordinateOrigin>, CoordinateOriginComposer>();
        services.AddSingleton<IOriginComposer<IObservationSiteOrigin>, ObservationSiteOriginComposer>();

        services.AddSingleton<IOriginCoordinateComposer<CylindricalCoordinate>, Query.Arguments.Composers.Origin.CylindricalCoordinateComposer>();
        services.AddSingleton<IOriginCoordinateComposer<GeodeticCoordinate>, Query.Arguments.Composers.Origin.GeodeticCoordinateComposer>();

        services.AddSingleton<IOriginCoordinateTypeComposer<CylindricalCoordinate>, Query.Arguments.Composers.Origin.CylindricalCoordinateComposer>();
        services.AddSingleton<IOriginCoordinateTypeComposer<GeodeticCoordinate>, Query.Arguments.Composers.Origin.GeodeticCoordinateComposer>();

        services.AddSingleton<IEpochCollectionComposer<IEpochCollection>, EpochCollectionComposer>();
        services.AddSingleton<IEpochCollectionFormatComposer, EpochCollectionFormatComposer>();

        services.AddSingleton<IStartEpochComposer<IEpoch>, EpochRangeEpochComposer>();
        services.AddSingleton<IStopEpochComposer<IEpoch>, EpochRangeEpochComposer>();

        services.AddSingleton<IStepSizeComposer<IFixedStepSize>, FixedStepSizeComposer>();
        services.AddSingleton<IStepSizeComposer<IUniformStepSize>, UniformStepSizeComposer>();
        services.AddSingleton<IStepSizeComposer<ICalendarStepSize>, CalendarStepSizeComposer>();
        services.AddSingleton<IStepSizeComposer<IAngularStepSize>, AngularStepSizeComposer>();

        services.AddSingleton<IEphemerisTypeComposer, EphemerisTypeComposer>();
        services.AddSingleton<IGenerateEphemeridesComposer, GenerateEphemeridesComposer>();
        services.AddSingleton<IObjectDataInclusionComposer, ObjectDataInclusionComposer>();
        services.AddSingleton<IVectorLabelsComposer, OutputLabelsComposer>();
        services.AddSingleton<IOutputUnitsComposer, OutputUnitsComposer>();
        services.AddSingleton<IReferencePlaneComposer, ReferencePlaneComposer>();
        services.AddSingleton<IReferenceSystemComposer, ReferenceSystemComposer>();
        services.AddSingleton<ITimeDeltaInclusionComposer, TimeDeltaInclusionComposer>();
        services.AddSingleton<ITimePrecisionComposer, TimePrecisionComposer>();
        services.AddSingleton<IValueSeparationComposer, ValueSeperationComposer>();
        services.AddSingleton<IVectorCorrectionComposer, VectorCorrectionComposer>();
        services.AddSingleton<IVectorTableContentComposer, VectorTableContentComposer>();

        return services;
    }
}

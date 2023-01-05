namespace SharpHorizons;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using NodaTime;

using SharpHorizons.Ephemeris.Vectors;
using SharpHorizons.Interpretation;
using SharpHorizons.Interpretation.Ephemeris;
using SharpHorizons.Interpretation.Ephemeris.Origin;
using SharpHorizons.Interpretation.Ephemeris.Target;
using SharpHorizons.Interpretation.Ephemeris.Vectors;
using SharpHorizons.MPC;
using SharpHorizons.Query;
using SharpHorizons.Query.Arguments;
using SharpHorizons.Query.Arguments.Composers;
using SharpHorizons.Query.Arguments.Composers.Epoch;
using SharpHorizons.Query.Arguments.Composers.Origin;
using SharpHorizons.Query.Arguments.Composers.Target;
using SharpHorizons.Query.Epoch;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Parameters;
using SharpHorizons.Query.Request;
using SharpHorizons.Query.Request.HTTP;
using SharpHorizons.Query.Result.HTTP;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;
using SharpHorizons.Query.Vectors.Fluency;
using SharpHorizons.Query.Vectors.Table;
using SharpHorizons.Settings.Interpretation;
using SharpHorizons.Settings.Interpretation.Ephemeris;
using SharpHorizons.Settings.Interpretation.Ephemeris.Origin;
using SharpHorizons.Settings.Interpretation.Ephemeris.Target;
using SharpHorizons.Settings.Interpretation.Ephemeris.Vectors;
using SharpHorizons.Settings.Query;
using SharpHorizons.Settings.Query.Parameters;

using SharpMeasures.Astronomy;

/// <summary>Extension methods for <see cref="IServiceCollection"/>.</summary>
public static class IServiceCollectionExtensions
{
    /// <summary>Adds services required by SharpHorizons to <paramref name="services"/>.</summary>
    /// <param name="services">Services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    public static IServiceCollection AddSharpHorizons(this IServiceCollection services)
    {
        services.AddHttpClient();

        services.AddSingleton(DateTimeZoneProviders.Tzdb);

        services.AddTransient<IQueryArgumentSetBuilder, QueryArgumentSetBuilder>();
        services.AddSingleton<IQueryArgumentSetFactory, QueryArgumentSetBuilderFactory>();

        services.AddSingleton<ITimeSystemOffsetProvider, ZeroTimeSystemOffsetProvider>();

        services.AddSharpHorizonsOptions();
        services.AddSharpHorizonsHTTP();
        services.AddSharpHorizonsTarget();
        services.AddSharpHorizonsOrigin();
        services.AddSharpHorizonsEpoch();
        services.AddSharpHorizonsVectors();
        services.AddSharpHorizonsComposers();
        services.AddSharpHorizonsInterpreters();

        return services;
    }

    /// <summary>Adds services required by SharpHorizons to <paramref name="services"/>, with configuration provided by <paramref name="configuration"/>.</summary>
    /// <param name="services">Services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    /// <param name="configuration">Provides configuration of the SharpHorizons services.</param>
    public static IServiceCollection AddSharpHorizons(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSharpHorizons();

        services.Configure<QueryOptions>(configuration.GetSection(QueryOptions.Section));
        services.Configure<ParameterIdentifierOptions>(configuration.GetSection(ParameterIdentifierOptions.Section));
        services.Configure<EphemerisInterpretationOptions>(configuration.GetSection(EphemerisInterpretationOptions.Section));
        services.Configure<TargetInterpretationOptions>(configuration.GetSection(TargetInterpretationOptions.Section));
        services.Configure<OriginInterpretationOptions>(configuration.GetSection(OriginInterpretationOptions.Section));
        services.Configure<VectorsInterpretationOptions>(configuration.GetSection(VectorsInterpretationOptions.Section));

        return services;
    }

    /// <summary>Adds options-related services required by SharpHorizons to <paramref name="services"/>.</summary>
    /// <param name="services">Options-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    private static IServiceCollection AddSharpHorizonsOptions(this IServiceCollection services)
    {
        services.AddOptions<QueryOptions>().Configure(QueryOptions.ApplyDefaults);
        services.AddOptions<ParameterIdentifierOptions>().Configure(ParameterIdentifierOptions.ApplyDefaults);
        services.AddOptions<InterpretationOptions>().Configure(InterpretationOptions.ApplyDefaults);
        services.AddOptions<EphemerisInterpretationOptions>().Configure(EphemerisInterpretationOptions.ApplyDefaults);
        services.AddOptions<TargetInterpretationOptions>().Configure(TargetInterpretationOptions.ApplyDefaults);
        services.AddOptions<OriginInterpretationOptions>().Configure(OriginInterpretationOptions.ApplyDefaults);
        services.AddOptions<VectorsInterpretationOptions>().Configure(VectorsInterpretationOptions.ApplyDefaults);

        services.AddSingleton<IHorizonsHTTPAddressProvider, HorizonsHTTPAddressProvider>();
        services.AddSingleton<IQueryParameterIdentifierProvider, QueryParameterIdentifierProvider>();
        services.AddSingleton<IInterpretationOptionsProvider, InterpretationOptionsProvider>();
        services.AddSingleton<IEphemerisInterpretationOptionsProvider, EphemerisInterpretationOptionsProvider>();
        services.AddSingleton<ITargetInterpretationOptionsProvider, TargetInterpretationOptionsProvider>();
        services.AddSingleton<IOriginInterpretationOptionsProvider, OriginInterpretationOptionsProvider>();
        services.AddSingleton<IVectorsInterpretationOptionsProvider, VectorsInterpretationOptionsProvider>();

        return services;
    }

    /// <summary>Adds HTTP-related services required by SharpHorizons to <paramref name="services"/>.</summary>
    /// <param name="services">HTTP-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    private static IServiceCollection AddSharpHorizonsHTTP(this IServiceCollection services)
    {
        services.AddSingleton<IHTTPQueryHandler, HTTPQueryHandler>();
        services.AddSingleton<IHTTPResultExtractor, HTTPTextExtractor>();

        return services;
    }

    /// <summary>Adds <see cref="ITarget"/>-related services required by SharpHorizons to <paramref name="services"/>.</summary>
    /// <param name="services"><see cref="ITarget"/>-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    private static IServiceCollection AddSharpHorizonsTarget(this IServiceCollection services)
    {
        services.AddSingleton<ITargetFactory, TargetFactory>();
        services.AddSingleton<ITargetSiteFactory, TargetSiteFactory>();
        services.AddSingleton<ITargetObjectFactory, TargetObjectFactory>();

        services.AddSingleton<IMajorObjectTargetFactory, MajorObjectTargetFactory>();
        services.AddSingleton<IMPCTargetFactory, MPCTargetFactory>();
        services.AddSingleton<IMPCCometTargetFactory, MPCCometTargetFactory>();

        services.AddSingleton<ITargetSiteComposer<CylindricalCoordinate>, Query.Arguments.Composers.Target.CylindricalCoordinateComposer>();
        services.AddSingleton<ITargetSiteComposer<GeodeticCoordinate>, Query.Arguments.Composers.Target.GeodeticCoordinateComposer>();

        services.AddSingleton<ITargetObjectComposer<MajorObject>, Query.Arguments.Composers.Target.MajorObjectComposer>();
        services.AddSingleton<ITargetObjectComposer<MajorObjectID>, Query.Arguments.Composers.Target.MajorObjectIDComposer>();
        services.AddSingleton<ITargetObjectComposer<MajorObjectName>, Query.Arguments.Composers.Target.MajorObjectNameComposer>();

        return services;
    }

    /// <summary>Adds <see cref="IOrigin"/>-related services required by SharpHorizons to <paramref name="services"/>.</summary>
    /// <param name="services"><see cref="IOrigin"/>-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    private static IServiceCollection AddSharpHorizonsOrigin(this IServiceCollection services)
    {
        services.AddSingleton<IOriginFactory, OriginFactory>();
        services.AddSingleton<IOriginObjectFactory, OriginObjectFactory>();

        services.AddSingleton<IOriginCoordinateFactory, OriginCoordinateFactory>();

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

        services.AddSingleton<IEpochRangeFactory, EpochRangeFactory>();
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

    /// <summary>Adds <see cref="IOrbitalStateVectors"/>-related services required by SharpHorizons to <paramref name="services"/>.</summary>
    /// <param name="services"><see cref="IOrbitalStateVectors"/>-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    private static IServiceCollection AddSharpHorizonsVectors(this IServiceCollection services)
    {
        services.AddSingleton<IVectorsQueryFactory, VectorsQueryFactory>();
        services.AddSingleton<IVectorsQueryValidator, VectorsQueryValidator>();

        services.AddSingleton<IVectorsQueryArgumentComposer, VectorsQueryArgumentComposer>();
        services.AddSingleton<IVectorsQueryComposer, VectorsQueryComposer>();

        services.AddSingleton<ITargetStageFactory, TargetStageFactory>();
        services.AddSingleton<IOriginStageFactory, OriginStageFactory>();
        services.AddSingleton<IEpochStageFactory, EpochStageFactory>();

        services.AddSingleton<IVectorTableContentValidator, VectorTableContentValidator>();
        services.AddSingleton<IVectorTableQuantitiesValidator, VectorTableQuantitiesValidator>();

        return services;
    }

    /// <summary>Adds <see cref="IArgumentComposer{TArgument, T}"/>-related services required by SharpHorizons to <paramref name="services"/>.</summary>
    /// <param name="services"><see cref="IArgumentComposer{TArgument, T}"/>-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    private static IServiceCollection AddSharpHorizonsComposers(this IServiceCollection services)
    {
        services.AddSingleton<IQueryStringComposer, QueryStringComposer>();
        services.AddSingleton<IURIComposer, URIComposer>();

        services.AddSingleton<ICommandComposer<QueryCommand>, QueryCommandComposer>();

        services.AddSingleton<ITargetComposer<MajorObject>, Query.Arguments.Composers.Target.MajorObjectComposer>();
        services.AddSingleton<ITargetComposer<MajorObjectID>, Query.Arguments.Composers.Target.MajorObjectIDComposer>();
        services.AddSingleton<ITargetComposer<MajorObjectName>, Query.Arguments.Composers.Target.MajorObjectNameComposer>();

        services.AddSingleton<ITargetComposer<MPCObject>, MPCObjectTargetComposer>();
        services.AddSingleton<ITargetComposer<MPCProvisionalObject>, MPCProvisionalObjectTargetComposer>();
        services.AddSingleton<ITargetComposer<MPCName>, MPCNameTargetComposer>();
        services.AddSingleton<ITargetComposer<MPCProvisionalDesignation>, MPCProvisionalDesignationTargetComposer>();
        services.AddSingleton<ITargetComposer<MPCSequentialNumber>, MPCSequentialNumberTargetComposer>();

        services.AddSingleton<ITargetComposer<ISiteTarget>, SiteTargetComposer>();

        services.AddSingleton<IOriginComposer<IBodyCentricOrigin>, BodyCentricOriginComposer>();
        services.AddSingleton<IOriginComposer<ICoordinateOrigin>, CoordinateOriginComposer>();
        services.AddSingleton<IOriginComposer<IObservationSiteOrigin>, ObservationSiteOriginComposer>();

        services.AddSingleton<IOriginCoordinateComposer<CylindricalCoordinate>, Query.Arguments.Composers.Origin.CylindricalCoordinateComposer>();
        services.AddSingleton<IOriginCoordinateComposer<GeodeticCoordinate>, Query.Arguments.Composers.Origin.GeodeticCoordinateComposer>();

        services.AddSingleton<IOriginCoordinateTypeComposer<CylindricalCoordinate>, Query.Arguments.Composers.Origin.CylindricalCoordinateComposer>();
        services.AddSingleton<IOriginCoordinateTypeComposer<GeodeticCoordinate>, Query.Arguments.Composers.Origin.GeodeticCoordinateComposer>();

        services.AddSingleton<IQueryEpochComposer, QueryEpochComposer>();

        services.AddSingleton<IEpochCollectionComposer<IEpochCollection>, EpochCollectionComposer>();
        services.AddSingleton<IEpochCollectionFormatComposer, EpochCollectionFormatComposer>();

        services.AddSingleton<IStartEpochComposer<IEpochRange>, EpochRangeEpochComposer>();
        services.AddSingleton<IStopEpochComposer<IEpochRange>, EpochRangeEpochComposer>();

        services.AddSingleton<IStepSizeComposer<IFixedStepSize>, FixedStepSizeComposer>();
        services.AddSingleton<IStepSizeComposer<IUniformStepSize>, UniformStepSizeComposer>();
        services.AddSingleton<IStepSizeComposer<ICalendarStepSize>, CalendarStepSizeComposer>();
        services.AddSingleton<IStepSizeComposer<IAngularStepSize>, AngularStepSizeComposer>();

        services.AddSingleton<IEphemerisTypeComposer, EphemerisTypeComposer>();
        services.AddSingleton<IGenerateEphemerisComposer, GenerateEphemerisComposer>();
        services.AddSingleton<IObjectDataInclusionComposer, ObjectDataInclusionComposer>();
        services.AddSingleton<IOutputFormatComposer, OutputFormatComposer>();
        services.AddSingleton<IOutputUnitsComposer, OutputUnitsComposer>();
        services.AddSingleton<IReferencePlaneComposer, ReferencePlaneComposer>();
        services.AddSingleton<IReferenceSystemComposer, ReferenceSystemComposer>();
        services.AddSingleton<ITimeDeltaInclusionComposer, TimeDeltaInclusionComposer>();
        services.AddSingleton<ITimePrecisionComposer, TimePrecisionComposer>();
        services.AddSingleton<IValueSeparationComposer, ValueSeperationComposer>();
        services.AddSingleton<IVectorCorrectionComposer, VectorCorrectionComposer>();
        services.AddSingleton<IVectorLabelsComposer, OutputLabelsComposer>();
        services.AddSingleton<IVectorTableContentComposer, VectorTableContentComposer>();

        return services;
    }

    /// <summary>Adds <see cref="IInterpreter{TInterpretation}"/>-related services required by SharpHorizons to <paramref name="services"/>.</summary>
    /// <param name="services"><see cref="IInterpreter{TInterpretation}"/>-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    private static IServiceCollection AddSharpHorizonsInterpreters(this IServiceCollection services)
    {
        services.AddSharpHorizonsVectorInterpreters();

        services.AddSingleton<IEphemerisHeaderInterpretationProvider, EphemerisHeaderInterpretationProvider>();
        services.AddSingleton<IEphemerisTargetHeaderInterpretationProvider, EphemerisTargetHeaderInterpretationProvider>();
        services.AddSingleton<IEphemerisOriginHeaderInterpretationProvider, EphemerisOriginHeaderInterpretationProvider>();

        services.AddSingleton<ITargetInterpreter, TargetInterpreter>();
        services.AddSingleton<ITargetGeodeticCoordinateInterpreter, CoordinateInterpreter>();
        services.AddSingleton<ITargetCylindricalCoordinateInterpreter, CoordinateInterpreter>();
        services.AddSingleton<ITargetReferenceEllipsoidInterpreter, ReferenceEllipsoidInterpreter>();
        services.AddSingleton<ITargetRadiiInterpreter, RadiiInterpreter>();

        services.AddSingleton<IOriginInterpreter, OriginInterpreter>();
        services.AddSingleton<IOriginGeodeticCoordinateInterpreter, CoordinateInterpreter>();
        services.AddSingleton<IOriginCylindricalCoordinateInterpreter, CoordinateInterpreter>();
        services.AddSingleton<IOriginSiteNameInterpreter, SiteNameInterpreter>();
        services.AddSingleton<IOriginReferenceEllipsoidInterpreter, ReferenceEllipsoidInterpreter>();
        services.AddSingleton<IOriginRadiiInterpreter, RadiiInterpreter>();

        services.AddSingleton<IInterpreter<MajorObject>, MajorObjectInterpreter>();
        services.AddSingleton<IInterpreter<MajorObjectID>, MajorObjectIDInterpreter>();
        services.AddSingleton<IInterpreter<MajorObjectName>, MajorObjectNameInterpreter>();

        services.AddSingleton<IInterpreter<MPCObject>, MPCObjectInterpreter>();
        services.AddSingleton<IInterpreter<MPCProvisionalObject>, MPCProvisionalObjectInterpreter>();
        services.AddSingleton<IInterpreter<MPCSequentialNumber>, MPCSequentialNumberInterpreter>();
        services.AddSingleton<IInterpreter<MPCProvisionalDesignation>, MPCProvisionalDesignationInterpreter>();
        services.AddSingleton<IInterpreter<MPCName>, MPCNameInterpreter>();

        services.AddSingleton<IInterpreter<MPCComet>, MPCCometInterpreter>();
        services.AddSingleton<IInterpreter<MPCCometDesignation>, MPCCometDesignationInterpreter>();
        services.AddSingleton<IInterpreter<MPCCometName>, MPCCometNameInterpreter>();

        services.AddSingleton<IEphemerisQueryEpochInterpreter, EphemerisQueryEpochInterpreter>();
        services.AddSingleton<IEphemerisStartEpochInterpreter, EphemerisBoundaryEpochInterpreter>();
        services.AddSingleton<IEphemerisStopEpochInterpreter, EphemerisBoundaryEpochInterpreter>();
        services.AddSingleton<ITimeSystemInterpreter, TimeSystemInterpreter>();
        services.AddSingleton<ITimeZoneOffsetInterpreter, TimeZoneOffsetInterpreter>();
        services.AddSingleton<IEphemerisStepSizeInterpreter, EphemerisStepSizeInterpreter>();

        services.AddSingleton<ISmallPerturbersInterpreter, SmallPerturbersInterpreter>();

        services.AddSingleton<IReferenceSystemInterpreter, ReferenceSystemInterpreter>();
        services.AddSingleton<IReferencePlaneInterpreter, ReferencePlaneInterpreter>();

        services.AddSingleton<IVectorsOutputUnitsInterpreter, OutputUnitsInterpreter>();

        services.AddSingleton<IVectorCorrectionInterpreter, VectorCorrectionInterpreter>();
        services.AddSingleton<IVectorTableContentInterpreter, VectorTableContentInterpreter>();

        return services;
    }

    /// <summary>Adds <see cref="IVectorsQuery"/>- and <see cref="IEphemerisQuantityInterpreter{THeader, TInterpretation}"/>-related services required by SharpHorizons to <paramref name="services"/>.</summary>
    /// <param name="services"><see cref="IVectorsQuery"/>- and <see cref="IEphemerisQuantityInterpreter{THeader, TInterpretation}"/>-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    private static IServiceCollection AddSharpHorizonsVectorInterpreters(this IServiceCollection services)
    {
        services.AddSingleton<IVectorsHeaderInterpreter, VectorsHeaderInterpreter>();
        services.AddSingleton<IVectorsHeaderInterpretationProvider, VectorsHeaderInterpretationProvider>();

        services.AddSingleton<IOrbitalStateVectorsInterpreter, OrbitalStateVectorsInterpreter>();
        services.AddSingleton<IOrbitalStateVectorsEphemerisInterpreter, OrbitalStateVectorsEphemerisInterpreter>();

        services.AddSingleton<IObjectPositionInterpreter, ObjectPositionInterpreter>();
        services.AddSingleton<IObjectPositionEphemerisInterpreter, ObjectPositionEphemerisInterpreter>();

        services.AddSingleton<IObjectPositionUncertaintyACNInterpreter, ObjectPositionUncertaintyACNInterpreter>();
        services.AddSingleton<IObjectPositionUncertaintyACNEphemerisInterpreter, ObjectPositionUncertaintyACNEphemerisInterpreter>();

        services.AddSingleton<IObjectPositionUncertaintyPOSInterpreter, ObjectPositionUncertaintyPOSInterpreter>();
        services.AddSingleton<IObjectPositionUncertaintyPOSEphemerisInterpreter, ObjectPositionUncertaintyPOSEphemerisInterpreter>();

        services.AddSingleton<IObjectPositionUncertaintyRTNInterpreter, ObjectPositionUncertaintyRTNInterpreter>();
        services.AddSingleton<IObjectPositionUncertaintyRTNEphemerisInterpreter, ObjectPositionUncertaintyRTNEphemerisInterpreter>();

        services.AddSingleton<IObjectPositionUncertaintyXYZInterpreter, ObjectPositionUncertaintyXYZInterpreter>();
        services.AddSingleton<IObjectPositionUncertaintyXYZEphemerisInterpreter, ObjectPositionUncertaintyXYZEphemerisInterpreter>();

        services.AddSingleton<IObjectVelocityInterpreter, ObjectVelocityInterpreter>();
        services.AddSingleton<IObjectVelocityEphemerisInterpreter, ObjectVelocityEphemerisInterpreter>();

        services.AddSingleton<IObjectVelocityUncertaintyACNInterpreter, ObjectVelocityUncertaintyACNInterpreter>();
        services.AddSingleton<IObjectVelocityUncertaintyACNEphemerisInterpreter, ObjectVelocityUncertaintyACNEphemerisInterpreter>();

        services.AddSingleton<IObjectVelocityUncertaintyPOSInterpreter, ObjectVelocityUncertaintyPOSInterpreter>();
        services.AddSingleton<IObjectVelocityUncertaintyPOSEphemerisInterpreter, ObjectVelocityUncertaintyPOSEphemerisInterpreter>();

        services.AddSingleton<IObjectVelocityUncertaintyRTNInterpreter, ObjectVelocityUncertaintyRTNInterpreter>();
        services.AddSingleton<IObjectVelocityUncertaintyRTNEphemerisInterpreter, ObjectVelocityUncertaintyRTNEphemerisInterpreter>();

        services.AddSingleton<IObjectVelocityUncertaintyXYZInterpreter, ObjectVelocityUncertaintyXYZInterpreter>();
        services.AddSingleton<IObjectVelocityUncertaintyXYZEphemerisInterpreter, ObjectVelocityUncertaintyXYZEphemerisInterpreter>();

        services.AddSingleton<IObjectDistanceInterpreter, ObjectDistanceInterpreter>();
        services.AddSingleton<IObjectDistanceEphemerisInterpreter, ObjectDistanceEphemerisInterpreter>();

        services.AddSingleton<IEphemerisEpochInterpreter, EphemerisEpochInterpreter>();

        services.AddSingleton<IObjectPositionComponentInterpreter, DistanceQuantityInterpreter>();
        services.AddSingleton<IObjectPositionUncertaintyACNComponentInterpreter, DistanceQuantityInterpreter>();
        services.AddSingleton<IObjectPositionUncertaintyPOSComponentInterpreter, DistanceQuantityInterpreter>();
        services.AddSingleton<IObjectPositionUncertaintyRTNComponentInterpreter, DistanceQuantityInterpreter>();
        services.AddSingleton<IObjectPositionUncertaintyXYZComponentInterpreter, DistanceQuantityInterpreter>();
        services.AddSingleton<IDistanceInterpreter, DistanceQuantityInterpreter>();

        services.AddSingleton<IObjectVelocityComponentInterpreter, SpeedQuantityInterpreter>();
        services.AddSingleton<IObjectVelocityUncertaintyACNComponentInterpreter, SpeedQuantityInterpreter>();
        services.AddSingleton<IObjectVelocityUncertaintyPOSComponentInterpreter, SpeedQuantityInterpreter>();
        services.AddSingleton<IObjectVelocityUncertaintyRTNComponentInterpreter, SpeedQuantityInterpreter>();
        services.AddSingleton<IObjectVelocityUncertaintyXYZComponentInterpreter, SpeedQuantityInterpreter>();
        services.AddSingleton<IRadialSpeedInterpreter, SpeedQuantityInterpreter>();

        services.AddSingleton<ILightTimeInterpreter, TimeQuantityInterpreter>();

        return services;
    }
}

namespace SharpHorizons.Extensions.Query;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
using SharpHorizons.Query.Result;
using SharpHorizons.Query.Target;
using SharpHorizons.Query.Vectors;
using SharpHorizons.Query.Vectors.Table;
using SharpHorizons.Settings.Query.Parameters;
using SharpHorizons.Settings.Query.Result;

using SharpMeasures.Astronomy;

using System;

/// <summary>Hosts extension methods for <see cref="IServiceCollection"/>.</summary>
public static class IServiceCollectionExtensions
{
    /// <summary>Adds query-related services required by SharpHorizons to the <see cref="IServiceCollection"/> <paramref name="services"/>.</summary>
    /// <param name="services">Query-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    public static IServiceCollection AddSharpHorizonsQuery(this IServiceCollection services)
    {
        services.AddSharpHorizonsQueryOptions();

        services.AddTransient<IQueryArgumentSetBuilder, QueryArgumentSetBuilder>();
        services.AddSingleton<IQueryArgumentSetFactory, QueryArgumentSetBuilderFactory>();

        services.AddSingleton<ITimeSystemOffsetProvider, ZeroTimeSystemOffsetProvider>();

        services.AddSharpHorizonsTarget();
        services.AddSharpHorizonsOrigin();
        services.AddSharpHorizonsEpochSelection();

        services.AddSharpHorizonsVectorsQuery();

        services.AddSharpHorizonsArgumentComposers();

        return services;
    }

    /// <summary>Adds query-related services required by SharpHorizons to the <see cref="IServiceCollection"/> <paramref name="services"/>, with configuration provided by the <see cref="IConfiguration"/> <paramref name="configuration"/>.</summary>
    /// <param name="services">Query-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    /// <param name="configuration">This <see cref="IConfiguration"/> provides configuration for the added SharpHorizons services.</param>
    /// <exception cref="ArgumentNullException"/>
    public static IServiceCollection AddSharpHorizonsQuery(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        services.AddSharpHorizonsQuery();

        services.Configure<QueryResultOptions>(configuration.GetSection(QueryResultOptions.Section));
        services.Configure<ParameterIdentifierOptions>(configuration.GetSection(ParameterIdentifierOptions.Section));

        return services;
    }

    /// <summary>Adds query- and options-related services required by SharpHorizons to the <see cref="IServiceCollection"/> <paramref name="services"/>.</summary>
    /// <param name="services">Query- and options-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    private static IServiceCollection AddSharpHorizonsQueryOptions(this IServiceCollection services)
    {
        services.AddOptions<QueryResultOptions>().Configure(QueryResultOptions.ApplyDefaults);
        services.AddOptions<ParameterIdentifierOptions>().Configure(ParameterIdentifierOptions.ApplyDefaults);

        services.AddSingleton<IQueryResultOptionsProvider, QueryResultOptionsProvider>();
        services.AddSingleton<IQueryParameterIdentifierProvider, QueryParameterIdentifierProvider>();

        return services;
    }

    /// <summary>Adds <see cref="ITarget"/>-related services required by SharpHorizons to the <see cref="IServiceCollection"/> <paramref name="services"/>.</summary>
    /// <param name="services"><see cref="ITarget"/>-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    private static IServiceCollection AddSharpHorizonsTarget(this IServiceCollection services)
    {
        services.AddSingleton<ITargetFactory, TargetFactory>();
        services.AddSingleton<ITargetSiteFactory, TargetSiteFactory>();
        services.AddSingleton<ITargetObjectFactory, TargetObjectFactory>();

        services.AddSingleton<IMajorObjectTargetFactory, MajorObjectTargetFactory>();
        services.AddSingleton<IMPCTargetFactory, MPCTargetFactory>();
        services.AddSingleton<IMPCCometTargetFactory, MPCCometTargetFactory>();

        services.AddSingleton<ITargetSiteComposer<CylindricalCoordinate>, SharpHorizons.Query.Arguments.Composers.Target.CylindricalCoordinateComposer>();
        services.AddSingleton<ITargetSiteComposer<GeodeticCoordinate>, SharpHorizons.Query.Arguments.Composers.Target.GeodeticCoordinateComposer>();

        services.AddSingleton<ITargetObjectComposer<MajorObject>, SharpHorizons.Query.Arguments.Composers.Target.MajorObjectComposer>();
        services.AddSingleton<ITargetObjectComposer<MajorObjectID>, SharpHorizons.Query.Arguments.Composers.Target.MajorObjectIDComposer>();
        services.AddSingleton<ITargetObjectComposer<MajorObjectName>, SharpHorizons.Query.Arguments.Composers.Target.MajorObjectNameComposer>();

        return services;
    }

    /// <summary><see cref="IOrigin"/>-related services required by SharpHorizons to the <see cref="IServiceCollection"/> <paramref name="services"/>.</summary>
    /// <param name="services"><see cref="IOrigin"/>-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    private static IServiceCollection AddSharpHorizonsOrigin(this IServiceCollection services)
    {
        services.AddSingleton<IOriginFactory, OriginFactory>();
        services.AddSingleton<IOriginObjectFactory, OriginObjectFactory>();

        services.AddSingleton<IOriginCoordinateFactory, OriginCoordinateFactory>();

        services.AddSingleton<IOriginObjectComposer<MajorObject>, SharpHorizons.Query.Arguments.Composers.Origin.MajorObjectComposer>();
        services.AddSingleton<IOriginObjectComposer<MajorObjectID>, SharpHorizons.Query.Arguments.Composers.Origin.MajorObjectIDComposer>();
        services.AddSingleton<IOriginObjectComposer<MajorObjectName>, SharpHorizons.Query.Arguments.Composers.Origin.MajorObjectNameComposer>();

        return services;
    }

    /// <summary><see cref="IEpochSelection"/>-related services required by SharpHorizons to the <see cref="IServiceCollection"/> <paramref name="services"/>.</summary>
    /// <param name="services"><see cref="IEpochSelection"/>-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    private static IServiceCollection AddSharpHorizonsEpochSelection(this IServiceCollection services)
    {
        services.AddSingleton<IEpochCollectionFactory, EpochCollectionFactory>();

        services.AddSingleton<IEpochRangeFactory, SimpleEpochRangeFactory>();
        services.AddSingleton<IFixedEpochRangeFactory, FixedEpochRangeFactory>();
        services.AddSingleton<IUniformEpochRangeFactory, UniformEpochRangeFactory>();
        services.AddSingleton<ICalendarEpochRangeFactory, CalendarEpochRangeFactory>();
        services.AddSingleton<IAngularEpochRangeFactory, AngularEpochRangeFactory>();

        services.AddSingleton<IFixedStepSizeFactory, FixedStepSizeFactory>();
        services.AddSingleton<IUniformStepSizeFactory, UniformStepSizeFactory>();
        services.AddSingleton<ICalendarStepSizeFactory, CalendarStepSizeFactory>();
        services.AddSingleton<IAngularStepSizeFactory, AngularStepSizeFactory>();

        return services;
    }

    /// <summary>Adds <see cref="IVectorsQuery"/>-related services required by SharpHorizons to the <see cref="IServiceCollection"/> <paramref name="services"/>.</summary>
    /// <param name="services"><see cref="IVectorsQuery"/>-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    private static IServiceCollection AddSharpHorizonsVectorsQuery(this IServiceCollection services)
    {
        services.AddSingleton<IVectorsQueryFactory, VectorsQueryFactory>();
        services.AddSingleton<IVectorsQueryValidator, VectorsQueryValidator>();

        services.AddSingleton<IVectorsQueryArgumentComposer, VectorsQueryArgumentComposer>();
        services.AddSingleton<IVectorsQueryComposer, VectorsQueryComposer>();

        services.AddSingleton<IVectorTableContentValidator, VectorTableContentValidator>();
        services.AddSingleton<IVectorTableQuantitiesValidator, VectorTableQuantitiesValidator>();

        return services;
    }

    /// <summary>Adds <see cref="IArgumentComposer{TArgument, T}"/>-related services required by SharpHorizons to the <see cref="IServiceCollection"/> <paramref name="services"/>.</summary>
    /// <param name="services"><see cref="IArgumentComposer{TArgument, T}"/>-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    private static IServiceCollection AddSharpHorizonsArgumentComposers(this IServiceCollection services)
    {
        services.AddSingleton<IQueryStringComposer, QueryStringComposer>();

        services.AddSingleton<ICommandComposer<QueryCommand>, QueryCommandComposer>();

        services.AddSingleton<ITargetComposer<MajorObject>, SharpHorizons.Query.Arguments.Composers.Target.MajorObjectComposer>();
        services.AddSingleton<ITargetComposer<MajorObjectID>, SharpHorizons.Query.Arguments.Composers.Target.MajorObjectIDComposer>();
        services.AddSingleton<ITargetComposer<MajorObjectName>, SharpHorizons.Query.Arguments.Composers.Target.MajorObjectNameComposer>();

        services.AddSingleton<ITargetComposer<MPCObject>, MPCObjectTargetComposer>();
        services.AddSingleton<ITargetComposer<MPCProvisionalObject>, MPCProvisionalObjectTargetComposer>();
        services.AddSingleton<ITargetComposer<MPCName>, MPCNameTargetComposer>();
        services.AddSingleton<ITargetComposer<MPCProvisionalDesignation>, MPCProvisionalDesignationTargetComposer>();
        services.AddSingleton<ITargetComposer<MPCSequentialNumber>, MPCSequentialNumberTargetComposer>();

        services.AddSingleton<ITargetComposer<ISiteTarget>, SiteTargetComposer>();

        services.AddSingleton<IOriginComposer<IBodyCentricOrigin>, BodyCentricOriginComposer>();
        services.AddSingleton<IOriginComposer<ICoordinateOrigin>, CoordinateOriginComposer>();
        services.AddSingleton<IOriginComposer<IObservationSiteOrigin>, ObservationSiteOriginComposer>();

        services.AddSingleton<IOriginCoordinateComposer<CylindricalCoordinate>, SharpHorizons.Query.Arguments.Composers.Origin.CylindricalCoordinateComposer>();
        services.AddSingleton<IOriginCoordinateComposer<GeodeticCoordinate>, SharpHorizons.Query.Arguments.Composers.Origin.GeodeticCoordinateComposer>();

        services.AddSingleton<IOriginCoordinateTypeComposer<CylindricalCoordinate>, SharpHorizons.Query.Arguments.Composers.Origin.CylindricalCoordinateComposer>();
        services.AddSingleton<IOriginCoordinateTypeComposer<GeodeticCoordinate>, SharpHorizons.Query.Arguments.Composers.Origin.GeodeticCoordinateComposer>();

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
}

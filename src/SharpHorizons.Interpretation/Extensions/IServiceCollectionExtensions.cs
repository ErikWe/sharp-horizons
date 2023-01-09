namespace SharpHorizons.Extensions.Interpretation;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SharpHorizons.Interpretation;
using SharpHorizons.Interpretation.Ephemeris;
using SharpHorizons.Interpretation.Ephemeris.Origin;
using SharpHorizons.Interpretation.Ephemeris.Target;
using SharpHorizons.Interpretation.Ephemeris.Vectors;
using SharpHorizons.MPC;
using SharpHorizons.Query.Vectors;
using SharpHorizons.Settings.Interpretation;
using SharpHorizons.Settings.Interpretation.Ephemeris;
using SharpHorizons.Settings.Interpretation.Ephemeris.Origin;
using SharpHorizons.Settings.Interpretation.Ephemeris.Target;
using SharpHorizons.Settings.Interpretation.Ephemeris.Vectors;

using System;

/// <summary>Hosts extension methods for <see cref="IServiceCollection"/>.</summary>
public static class IServiceCollectionExtensions
{
    /// <summary>Adds interpretation-related services required by SharpHorizons to the <see cref="IServiceCollection"/> <paramref name="services"/>.</summary>
    /// <param name="services">Interpretation-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    public static IServiceCollection AddSharpHorizonsInterpretation(this IServiceCollection services)
    {
        services.AddSharpHorizonsInterpretationOptions();

        services.AddSharpHorizonsInterpreters();

        return services;
    }

    /// <summary>Adds interpretation-related services required by SharpHorizons to the <see cref="IServiceCollection"/> <paramref name="services"/>, with configuration provided by the <see cref="IConfiguration"/> <paramref name="configuration"/>.</summary>
    /// <param name="services">Interpretation-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    /// <param name="configuration">This <see cref="IConfiguration"/> provides configuration for the added SharpHorizons services.</param>
    /// <exception cref="ArgumentNullException"/>
    public static IServiceCollection AddSharpHorizonsInterpretation(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        services.AddSharpHorizonsInterpretation();

        services.Configure<EphemerisInterpretationOptions>(configuration.GetSection(EphemerisInterpretationOptions.Section));
        services.Configure<TargetInterpretationOptions>(configuration.GetSection(TargetInterpretationOptions.Section));
        services.Configure<OriginInterpretationOptions>(configuration.GetSection(OriginInterpretationOptions.Section));
        services.Configure<VectorsInterpretationOptions>(configuration.GetSection(VectorsInterpretationOptions.Section));

        return services;
    }

    /// <summary>Adds interpretation- and options-related services required by SharpHorizons to the <see cref="IServiceCollection"/> <paramref name="services"/>.</summary>
    /// <param name="services">Interpretation- and options-related services required by SharpHorizons are added to this <see cref="IServiceCollection"/>.</param>
    private static IServiceCollection AddSharpHorizonsInterpretationOptions(this IServiceCollection services)
    {
        services.AddOptions<InterpretationOptions>().Configure(InterpretationOptions.ApplyDefaults);
        services.AddOptions<EphemerisInterpretationOptions>().Configure(EphemerisInterpretationOptions.ApplyDefaults);
        services.AddOptions<TargetInterpretationOptions>().Configure(TargetInterpretationOptions.ApplyDefaults);
        services.AddOptions<OriginInterpretationOptions>().Configure(OriginInterpretationOptions.ApplyDefaults);
        services.AddOptions<VectorsInterpretationOptions>().Configure(VectorsInterpretationOptions.ApplyDefaults);

        services.AddSingleton<IInterpretationOptionsProvider, InterpretationOptionsProvider>();
        services.AddSingleton<IEphemerisInterpretationOptionsProvider, EphemerisInterpretationOptionsProvider>();
        services.AddSingleton<ITargetInterpretationOptionsProvider, TargetInterpretationOptionsProvider>();
        services.AddSingleton<IOriginInterpretationOptionsProvider, OriginInterpretationOptionsProvider>();
        services.AddSingleton<IVectorsInterpretationOptionsProvider, VectorsInterpretationOptionsProvider>();

        return services;
    }

    /// <summary>Adds <see cref="IInterpreter{TInterpretation}"/>-related services required by SharpHorizons to the <see cref="IServiceCollection"/> <paramref name="services"/>.</summary>
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

    /// <summary>Adds <see cref="IVectorsQuery"/>- and <see cref="IEphemerisQuantityInterpreter{THeader, TInterpretation}"/>-related services required by SharpHorizons to the <see cref="IServiceCollection"/> <paramref name="services"/>.</summary>
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

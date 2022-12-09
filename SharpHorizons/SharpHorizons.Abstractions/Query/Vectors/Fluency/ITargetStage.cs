namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.MPC;
using SharpHorizons.Query.Target;

using SharpMeasures.Astronomy;

using System;

/// <summary>Provides means of selecting the <see cref="ITarget"/> of a <see cref="IVectorsQuery"/>.</summary>
public interface ITargetStage
{
    /// <summary>Selects <paramref name="target"/> as the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="target">The <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOriginStage WithTarget(ITarget target);

    /// <summary>Describes the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/> as the center of <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The center of this <see cref="MajorObject"/> represents the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOriginStage WithTarget(MajorObject majorObject);

    /// <summary>Describes the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/> as the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of a <see cref="MajorObject"/>, the center of which represents the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</param>
    public abstract IOriginStage WithTarget(MajorObjectID majorObjectID);

    /// <summary>Describes the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/> as the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of a <see cref="MajorObject"/>, the center of which represents the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the <see cref="MajorObject"/>, if known - as using the <see cref="MajorObjectName"/> can result in multiple matches.</remarks>
    /// <exception cref="ArgumentException"/>
    public abstract IOriginStage WithTarget(MajorObjectName majorObjectName);

    /// <summary>Describes the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/> as a custom <paramref name="coordinate"/> relative to <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="CylindricalCoordinate"/>, relative to <paramref name="majorObject"/>, which represents the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOriginStage WithTarget(MajorObject majorObject, CylindricalCoordinate coordinate);

    /// <summary>Describes the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/> as a custom <paramref name="coordinate"/> relative to <paramref name="majorObject"/>.</summary>
    /// <param name="majorObject">The <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="GeodeticCoordinate"/>, relative to <paramref name="majorObject"/>, which represents the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOriginStage WithTarget(MajorObject majorObject, GeodeticCoordinate coordinate);

    /// <summary>Describes the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/> as <paramref name="coordinate"/> relative to the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of a <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="CylindricalCoordinate"/>, relative to a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>, which represents the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    public abstract IOriginStage WithTarget(MajorObjectID majorObjectID, CylindricalCoordinate coordinate);

    /// <summary>Describes the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/> as <paramref name="coordinate"/> relative to the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>.</summary>
    /// <param name="majorObjectID">The <see cref="MajorObjectID"/> of a <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="GeodeticCoordinate"/>, relative to a <see cref="MajorObject"/> identified by <paramref name="majorObjectID"/>, which represents the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    public abstract IOriginStage WithTarget(MajorObjectID majorObjectID, GeodeticCoordinate coordinate);

    /// <summary>Describes the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/> as <paramref name="coordinate"/> relative to the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of a <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="CylindricalCoordinate"/>, relative to a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>, which represents the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the <see cref="MajorObject"/>, if known - as using the <see cref="MajorObjectName"/> can result in multiple matches.</remarks>
    /// <exception cref="ArgumentException"/>
    public abstract IOriginStage WithTarget(MajorObjectName majorObjectName, CylindricalCoordinate coordinate);

    /// <summary>Describes the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/> as <paramref name="coordinate"/> relative to the center of a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>.</summary>
    /// <param name="majorObjectName">The <see cref="MajorObjectName"/> of a <see cref="MajorObject"/>, relative to which <paramref name="coordinate"/> is expressed.</param>
    /// <param name="coordinate">The custom <see cref="GeodeticCoordinate"/>, relative to a <see cref="MajorObject"/> identified by <paramref name="majorObjectName"/>, which represents the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <remarks>Prefer using the <see cref="MajorObjectID"/> of the <see cref="MajorObject"/>, if known - as using the <see cref="MajorObjectName"/> can result in multiple matches.</remarks>
    /// <exception cref="ArgumentException"/>
    public abstract IOriginStage WithTarget(MajorObjectName majorObjectName, GeodeticCoordinate coordinate);

    /// <summary>Describes the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/> as the center of <paramref name="mpcObject"/>.</summary>
    /// <param name="mpcObject">The center of this <see cref="MPCObject"/> represents the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOriginStage WithTarget(MPCObject mpcObject);

    /// <summary>Describes the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/> as the center of <paramref name="mpcObject"/>.</summary>
    /// <param name="mpcObject">The center of this <see cref="MPCProvisionalObject"/> represents the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    public abstract IOriginStage WithTarget(MPCProvisionalObject mpcObject);

    /// <summary>Describes the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/> as the center of an <see cref="MPCObject"/> identified by <paramref name="mpcName"/>.</summary>
    /// <param name="mpcName">The <see cref="MPCName"/> of an <see cref="MPCObject"/>, the center of which represents the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    public abstract IOriginStage WithTarget(MPCName mpcName);

    /// <summary>Describes the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/> as the center of an <see cref="MPCObject"/> or <see cref="MPCProvisionalObject"/> identified by <paramref name="mpcDesignation"/>.</summary>
    /// <param name="mpcDesignation">The <see cref="MPCProvisionalDesignation"/> of an <see cref="MPCObject"/> or <see cref="MPCProvisionalObject"/>, the center of which represents the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    public abstract IOriginStage WithTarget(MPCProvisionalDesignation mpcDesignation);

    /// <summary>Describes the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/> as the center of an <see cref="MPCObject"/> or <see cref="MPCProvisionalObject"/> identified by <paramref name="mpcNumber"/>.</summary>
    /// <param name="mpcNumber">The <see cref="MPCSequentialNumber"/> of an <see cref="MPCObject"/> or <see cref="MPCProvisionalObject"/>, the center of which represents the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</param>
    public abstract IOriginStage WithTarget(MPCSequentialNumber mpcNumber);

    /// <summary>Describes the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/> as the center of <paramref name="mpcComet"/>.</summary>
    /// <param name="mpcComet">The center of this <see cref="MPCComet"/> represents the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOriginStage WithTarget(MPCComet mpcComet);

    /// <summary>Describes the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/> as the center of an <see cref="MPCComet"/> identified by <paramref name="mpcCometName"/>.</summary>
    /// <param name="mpcCometName">The <see cref="MPCCometName"/> of an <see cref="MPCComet"/>, the center of which represents the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    public abstract IOriginStage WithTarget(MPCCometName mpcCometName);

    /// <summary>Describes the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/> as the center of an <see cref="MPCComet"/> identified by <paramref name="mpcCometDesignation"/>.</summary>
    /// <param name="mpcCometDesignation">The <see cref="MPCCometDesignation"/> of an <see cref="MPCComet"/>, the center of which represents the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    public abstract IOriginStage WithTarget(MPCCometDesignation mpcCometDesignation);
}

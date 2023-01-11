namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Query.Origin;

using System;

/// <summary>Provides means of selecting the <see cref="IOrigin"/> of a <see cref="IVectorsQuery"/>.</summary>
public interface IOriginStage
{
    /// <summary>Uses a <see cref="IOriginFactory"/> to select the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="originFactory">This <see cref="IOriginFactory"/> is used to select the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public delegate IOrigin DOriginFactory(IOriginFactory originFactory);

    /// <summary>Uses <paramref name="origin"/> as the <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/>, and proceeds to the <see cref="IEpochStage"/>.</summary>
    /// <param name="origin">The <see cref="IOrigin"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEpochStage WithOrigin(IOrigin origin);

    /// <summary>Delegates the selection of <see cref="IOrigin"/> to an <see cref="IOriginFactory"/>, and proceeds to the <see cref="IEpochStage"/>.</summary>
    /// <param name="originFactoryDelegate"><inheritdoc cref="DOriginFactory" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEpochStage WithOrigin(DOriginFactory originFactoryDelegate);
}

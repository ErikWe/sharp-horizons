namespace SharpHorizons.Query.Vectors.Fluency;

using SharpHorizons.Query.Target;

using System;

/// <summary>Provides means of selecting the <see cref="ITarget"/> of a <see cref="IVectorsQuery"/>.</summary>
public interface ITargetStage
{
    /// <summary>Uses a <see cref="ITargetFactory"/> to select the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</summary>
    /// <param name="targetFactory">This <see cref="ITargetFactory"/> is used to select the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    public delegate ITarget DTargetFactory(ITargetFactory targetFactory);

    /// <summary>Selects <paramref name="target"/> as the <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>, and proceeds to the <see cref="IOriginStage"/>.</summary>
    /// <param name="target">The <see cref="ITarget"/> in the <see cref="IVectorsQuery"/>.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOriginStage WithTarget(ITarget target);

    /// <summary>Delegates the selection of <see cref="ITarget"/> to a <see cref="ITargetFactory"/>, and proceeds to the <see cref="IOriginStage"/>.</summary>
    /// <param name="targetFactoryDelegate"><inheritdoc cref="DTargetFactory" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IOriginStage WithTarget(DTargetFactory targetFactoryDelegate);
}

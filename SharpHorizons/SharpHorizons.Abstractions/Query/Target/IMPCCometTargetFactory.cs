namespace SharpHorizons.Query.Target;

using SharpHorizons.Identity;

using System;

/// <summary>Handles construction of <see cref="ITarget"/> associated with <see cref="MPCComet"/>.</summary>
public interface IMPCCometTargetFactory
{
    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of <paramref name="mpcComet"/>.</summary>
    /// <param name="mpcComet">The center of this <see cref="MPCComet"/> represents the <see cref="ITarget"/> in a query.</param>
    /// <exception cref="ArgumentNullException"/>
    public abstract ITarget Create(MPCComet mpcComet);

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of a <see cref="MPCComet"/> identified by <paramref name="mpcCometName"/>.</summary>
    /// <param name="mpcCometName">The <see cref="MPCCometName"/> of a <see cref="MPCComet"/>, the center of which represents the <see cref="ITarget"/> in a query.</param>
    public abstract ITarget Create(MPCCometName mpcCometName);

    /// <summary>Describes the <see cref="ITarget"/> in a query as the center of a <see cref="MPCComet"/> identified by <paramref name="mpcCometDesignation"/>.</summary>
    /// <param name="mpcCometDesignation">The <see cref="MPCCometDesignation"/> of a <see cref="MPCComet"/>, the center of which represents the <see cref="ITarget"/> in a query.</param>
    public abstract ITarget Create(MPCCometDesignation mpcCometDesignation);
}
namespace SharpHorizons.Query.Arguments.Composers.Epoch;

using SharpHorizons.Query.Epoch;

using System;

/// <summary>Composes <see cref="string"/> that describe <see cref="QueryEpoch"/>.</summary>
public interface IQueryEpochComposer
{
    /// <summary>Composes a <see cref="string"/> describing <paramref name="queryEpoch"/>.</summary>
    /// <param name="queryEpoch">The composed <see cref="string"/> describes this <see cref="QueryEpoch"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="InvalidOperationException"/>
    public abstract string Compose(QueryEpoch queryEpoch);
}

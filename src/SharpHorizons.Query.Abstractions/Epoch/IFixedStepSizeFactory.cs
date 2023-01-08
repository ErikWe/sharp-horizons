namespace SharpHorizons.Query.Epoch;

using SharpMeasures;

using System;

/// <summary>Handles construction of <see cref="IFixedStepSize"/>, describing the <see cref="IStepSize"/> in a query using a fixed <see cref="Time"/>.</summary>
public interface IFixedStepSizeFactory
{
    /// <summary>Describes the <see cref="IStepSize"/> in a query using a fixed <see cref="Time"/> difference <paramref name="deltaTime"/>.</summary>
    /// <param name="deltaTime"><inheritdoc cref="IFixedStepSize.DeltaTime" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public abstract IFixedStepSize Create(Time deltaTime);
}

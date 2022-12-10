﻿namespace SharpHorizons.Query.Epoch;

using System;

/// <summary>Handles construction of <see cref="IUniformStepSize"/>, describing the <see cref="IStepSize"/> in a query using an <see cref="int"/> number of uniformly distributed steps.</summary>
public interface IUniformStepSizeFactory
{
    /// <summary>Describes the <see cref="IStepSize"/> in a query using <paramref name="stepCount"/> uniformly distributed steps.</summary>
    /// <param name="stepCount"><inheritdoc cref="IUniformStepSize.StepCount" path="/summary"/></param>
    /// <exception cref="ArgumentOutOfRangeException"/>
    public abstract IUniformStepSize Create(int stepCount);
}

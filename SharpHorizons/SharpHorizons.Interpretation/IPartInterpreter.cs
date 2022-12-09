﻿namespace SharpHorizons.Interpretation;

using SharpHorizons.Query.Result;

using System;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <typeparamref name="TInterpretation"/>.</summary>
/// <typeparam name="TInterpretation">The type of the interpreted result.</typeparam>
public interface IPartInterpreter<TInterpretation>
{
    /// <summary>Interprets <paramref name="queryPart"/>, resulting in an instance of type <typeparamref name="TInterpretation"/>.</summary>
    /// <param name="queryPart">This part of a <see cref="IQueryResult"/> is interpreted as an instance of type <typeparamref name="TInterpretation"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract TInterpretation Interpret(string queryPart);
}

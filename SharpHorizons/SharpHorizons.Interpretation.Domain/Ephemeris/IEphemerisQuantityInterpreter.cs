namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Ephemeris;
using SharpHorizons.Query.Result;

using System;

/// <summary>Interprets a quantity of an <see cref="IEphemerisEntry"/>.</summary>
/// <typeparam name="THeader">The type of the <see cref="IEphemerisHeader"/>.</typeparam>
/// <typeparam name="TInterpretation">The type of the interpreted result.</typeparam>
public interface IEphemerisQuantityInterpreter<THeader, TInterpretation> where THeader : IEphemerisHeader
{
    /// <summary>Attempts to interpret <paramref name="text"/>, resulting in an instance of <typeparamref name="TInterpretation"/>.</summary>
    /// <param name="text">This <see cref="string"/>, part of a <see cref="QueryResult"/>, is interpreted as an instance of type <typeparamref name="TInterpretation"/>, if possible.</param>
    /// <param name="header">The <typeparamref name="THeader"/>, representing the header of the <see cref="QueryResult"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract Optional<TInterpretation> Interpret(string text, THeader header);
}

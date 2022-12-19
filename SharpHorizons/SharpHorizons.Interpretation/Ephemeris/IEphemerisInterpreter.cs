namespace SharpHorizons.Interpretation.Ephemeris;

using SharpHorizons.Ephemeris;
using SharpHorizons.Query.Result;

using System;

/// <summary>Interprets <see cref="QueryResult"/> as <see cref="IEphemeris{TEntry}"/> with entries of type <typeparamref name="TEphemerisEntry"/>.</summary>
/// <typeparam name="THeader">The type of the <see cref="IEphemerisHeader"/>, describing the content of the <see cref="QueryResult"/>.</typeparam>
/// <typeparam name="TEphemerisEntry">The type of the <see cref="IEphemerisEntry"/> of the interpreted <see cref="IEphemeris{TEntry}"/>.</typeparam>
public interface IEphemerisInterpreter<THeader, TEphemerisEntry> where THeader : IEphemerisHeader where TEphemerisEntry : IEphemerisEntry
{
    /// <summary>Attempts to interpret <paramref name="queryResult"/> as an <see cref="IEphemeris{TEntry}"/> with entries of type <typeparamref name="TEphemerisEntry"/>.</summary>
    /// <param name="header">The <typeparamref name="THeader"/> that describe the content of the <see cref="QueryResult"/>.</param>
    /// <param name="queryResult">This <see cref="QueryResult"/> is interpreted as an <see cref="IEphemeris{TEntry}"/> with entries of type <typeparamref name="TEphemerisEntry"/>, if possible.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IEphemeris<TEphemerisEntry> Interpret(THeader header, QueryResult queryResult);
}

namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Ephemeris;
using SharpHorizons.Query.Result;

using System;

/// <summary>Interprets <see cref="QueryResult"/> as <typeparamref name="TEphemerisEntry"/>.</summary>
/// <typeparam name="THeader">The type of the <see cref="IEphemerisHeader"/>, describing the content of the <see cref="QueryResult"/>.</typeparam>
/// <typeparam name="TEphemerisEntry">The type of the <see cref="IEphemerisEntry"/> of the interpreted <see cref="IEphemeris{TEntry}"/>.</typeparam>
public interface IEphemerisEntryInterpreter<THeader, TEphemerisEntry> where THeader : IEphemerisHeader where TEphemerisEntry : IEphemerisEntry
{
    /// <summary>Attempts to interpret the <paramref name="queryResult"/> as an <typeparamref name="TEphemerisEntry"/>.</summary>
    /// <param name="header">The <typeparamref name="THeader"/> that describe the content of the <see cref="QueryResult"/>.</param>
    /// <param name="queryResult">This <see cref="QueryResult"/> is interpreted as an <typeparamref name="TEphemerisEntry"/>, if possible.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract Optional<TEphemerisEntry> Interpret(THeader header, QueryResult queryResult);
}

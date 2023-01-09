namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Ephemeris;
using SharpHorizons.Query.Result;

using System;
using System.Collections.Generic;
using System.IO;

/// <summary>Handles interpretation of an <typeparamref name="TEphemerisEntry"/>.</summary>
/// <typeparam name="TEphemerisEntry">The type of the interpreted <see cref="IEphemerisEntry"/>.</typeparam>
/// <typeparam name="THeader">The type of the <see cref="IEphemerisHeader"/>.</typeparam>
internal abstract class AEphemerisEntryInterpreter<TEphemerisEntry, THeader> where THeader : IEphemerisHeader
{
    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider"/>
    private IEphemerisInterpretationOptionsProvider EphemerisInterpretationOptionsProvider { get; }

    /// <inheritdoc cref="IEphemerisQuantityInterpretationDelegater"/>
    private IEphemerisQuantityInterpretationDelegater InterpretationResolver { get; }

    /// <inheritdoc cref="AEphemerisInterpreter{TEphemeris, THeader}"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="EphemerisInterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="interpretationResolver"><inheritdoc cref="InterpretationResolver" path="/summary"/></param>
    protected AEphemerisEntryInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider, IEphemerisQuantityInterpretationDelegater interpretationResolver)
    {
        EphemerisInterpretationOptionsProvider = ephemerisInterpretationOptionsProvider;

        InterpretationResolver = interpretationResolver;
    }

    /// <summary>Interprets a collection of <typeparamref name="TEphemerisEntry"/> from <paramref name="queryResult"/>.</summary>
    /// <param name="header">The <typeparamref name="THeader"/>, representing the header of the <see cref="QueryResult"/>.</param>
    /// <param name="queryResult">The <see cref="QueryResult"/>, containing the <typeparamref name="TEphemerisEntry"/>.</param>
    protected Optional<TEphemerisEntry> Interpret(THeader header, QueryResult queryResult)
    {
        var linesEnumerator = SplitLines(queryResult.Content).GetEnumerator();

        if (header.Quantities.RowCount is 1)
        {
            linesEnumerator.MoveNext();

            if (linesEnumerator.Current == EphemerisInterpretationOptionsProvider.EndOfEphemeris)
            {
                return new();
            }

            return InterpretSingleLinedEntry(header, linesEnumerator.Current);
        }

        return InterpretMultiLinedEntry(header, linesEnumerator);
    }

    /// <summary>Constructs a blank <typeparamref name="TEphemerisEntry"/>.</summary>
    protected abstract TEphemerisEntry CreateEntry();

    /// <summary>Determines the validity of the <typeparamref name="TEphemerisEntry"/> <paramref name="entry"/>.</summary>
    /// <param name="entry">This <typeparamref name="TEphemerisEntry"/> is validated.</param>
    protected virtual bool ValidateEntry(TEphemerisEntry entry) => true;

    /// <summary>Attempts to interpret an <typeparamref name="TEphemerisEntry"/> from <paramref name="line"/>.</summary>
    /// <param name="header">The <typeparamref name="THeader"/>, representing the header of the <see cref="QueryResult"/>.</param>
    /// <param name="line">The <see cref="string"/> from which an <typeparamref name="TEphemerisEntry"/> is interpreted.</param>
    private Optional<TEphemerisEntry> InterpretSingleLinedEntry(THeader header, string line)
    {
        if (line.Contains(',', StringComparison.Ordinal))
        {
            return InterpretCommaSeparatedEntry(header, line);
        }

        var ephemerisEntry = CreateEntry();

        var startCharacterIndex = 0;
        var columnIndex = 0;

        while (startCharacterIndex <= line.Length)
        {
            EphemerisQuantityTableIndex quantityIndex = new(0, columnIndex);

            if (header.Quantities.TryGetValue(quantityIndex, out var quantity) is false || quantity.Value.CharacterLength is null)
            {
                return new();
            }

            var text = line.Substring(startCharacterIndex, quantity.Value.CharacterLength.Value).Trim();

            ephemerisEntry = InterpretationResolver.Interpret(quantity.Value, quantityIndex, text, header, ephemerisEntry);

            startCharacterIndex += quantity.Value.CharacterLength.Value;
            columnIndex += 1;
        }

        return ephemerisEntry;
    }

    /// <summary>Attempts to interpret an <typeparamref name="TEphemerisEntry"/> from comma-separated values of <paramref name="line"/>.</summary>
    /// <param name="header">The <typeparamref name="THeader"/>, representing the header of the <see cref="QueryResult"/>.</param>
    /// <param name="line">The <see cref="string"/> from which an <typeparamref name="TEphemerisEntry"/> is interpreted.</param>
    private Optional<TEphemerisEntry> InterpretCommaSeparatedEntry(THeader header, string line)
    {
        var ephemerisEntry = CreateEntry();

        var commaSplit = line.Split(',', StringSplitOptions.TrimEntries);

        for (var columnIndex = 0; columnIndex < commaSplit.Length; columnIndex++)
        {
            EphemerisQuantityTableIndex quantityIndex = new(0, columnIndex);

            if (header.Quantities.TryGetValue(quantityIndex, out var quantity) is false)
            {
                return new();
            }

            ephemerisEntry = InterpretationResolver.Interpret(quantity.Value, quantityIndex, commaSplit[columnIndex], header, ephemerisEntry);
        }

        return ephemerisEntry;
    }

    /// <summary>Attempts to interpret an <typeparamref name="TEphemerisEntry"/> spanning multiple lines of <paramref name="linesEnumerator"/>.</summary>
    /// <param name="header">The <typeparamref name="THeader"/>, representing the header of the <see cref="QueryResult"/>.</param>
    /// <param name="linesEnumerator">The <see cref="IEnumerator{T}"/> used to access the lines from which an <typeparamref name="TEphemerisEntry"/> is interpreted.</param>
    private Optional<TEphemerisEntry> InterpretMultiLinedEntry(THeader header, IEnumerator<string> linesEnumerator)
    {
        var ephemerisEntry = CreateEntry();

        var rowIndex = 0;

        while (linesEnumerator.MoveNext())
        {
            if (linesEnumerator.Current == EphemerisInterpretationOptionsProvider.EndOfEphemeris)
            {
                return new();
            }

            var components = getComponents(linesEnumerator.Current);
            var columnIndex = 0;

            foreach (var component in components)
            {
                EphemerisQuantityTableIndex quantityIndex = new(rowIndex, columnIndex);

                if (header.Quantities.TryGetValue(quantityIndex, out var quantity) is false)
                {
                    return new();
                }

                ephemerisEntry = InterpretationResolver.Interpret(quantity.Value, quantityIndex, component, header, ephemerisEntry);

                columnIndex += 1;
            }

            rowIndex += 1;

            if (rowIndex == header.Quantities.RowCount)
            {
                return ephemerisEntry;
            }
        }

        return new();

        static IEnumerable<string> getComponents(string line)
        {
            line = line.Replace(':', ' ');

            if (line.Split('=') is { Length: > 1 } equalsSplit)
            {
                return iterateLabelled(equalsSplit);
            }

            return line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            static IEnumerable<string> iterateLabelled(string[] equalsSplit)
            {
                var previousWhiteSpaceSplit = equalsSplit[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (var i = 1; i < equalsSplit.Length; i++)
                {
                    var whiteSpaceSplit = equalsSplit[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    yield return $"{previousWhiteSpaceSplit[^1]} = {string.Join(' ', whiteSpaceSplit[..^(i == equalsSplit.Length - 1 ? 0 : 1)])}";

                    previousWhiteSpaceSplit = whiteSpaceSplit;
                }
            }
        }
    }

    /// <summary>Iterates the lines of <paramref name="input"/>.</summary>
    /// <param name="input">The lines of this <see cref="string"/> are iterated.</param>
    private static IEnumerable<string> SplitLines(string input)
    {
        using var reader = new StringReader(input);

        while (reader.ReadLine() is string line)
        {
            yield return line;
        }
    }

    /// <summary>Handles the invokation of some <see cref="IEphemerisQuantityInterpreter{THeader, TInterpretation}"/> associated with some <see cref="EphemerisQuantityIdentifier"/>.</summary>
    protected interface IEphemerisQuantityInterpretationDelegater
    {
        /// <summary>Invokes the interpreter associated with <paramref name="quantity"/>, resulting in an instance of <typeparamref name="TEphemerisEntry"/>, based on <paramref name="ephemerisEntry"/>.</summary>
        /// <param name="quantity">An <see cref="IEphemerisQuantityInterpreter{THeader, TInterpretation}"/> associated with this <see cref="EphemerisQuantityIdentifier"/> is invoked.</param>
        /// <param name="index">The <see cref="EphemerisQuantityTableIndex"/> of the <paramref name="quantity"/>.</param>
        /// <param name="text">The <see cref="string"/> that is interpreted.</param>
        /// <param name="header">The <typeparamref name="THeader"/>, representing the header of the <see cref="QueryResult"/>.</param>
        /// <param name="ephemerisEntry">The resulting <typeparamref name="TEphemerisEntry"/> is based on this instance.</param>
        public abstract TEphemerisEntry Interpret(EphemerisQuantityIdentifier quantity, EphemerisQuantityTableIndex index, string text, THeader header, TEphemerisEntry ephemerisEntry);
    }
}

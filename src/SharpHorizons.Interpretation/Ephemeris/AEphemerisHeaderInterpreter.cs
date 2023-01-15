namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Query.Result;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

/// <summary>Handles iterative interpretation of the lines of an <see cref="IEphemerisHeader"/>.</summary>
/// <typeparam name="THeader">The type of the interpreted <see cref="IEphemerisHeader"/>.</typeparam>
internal abstract class AEphemerisHeaderInterpreter<THeader> where THeader : IEphemerisHeader
{
    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider"/>
    private IEphemerisInterpretationOptionsProvider EphemerisInterpretationOptionsProvider { get; }

    /// <summary>Delegates registered for invokation when the first line of the <see cref="IEphemerisHeader"/> is encountered.</summary>
    private ICollection<Func<QueryResult, THeader, THeader>> FirstLineInterpreters { get; } = new List<Func<QueryResult, THeader, THeader>>();

    /// <summary>Delegates registered for invokation when some <see cref="string"/> key is encountered.</summary>
    private Dictionary<string, ICollection<Func<QueryResult, THeader, THeader>>> KeyInterpreters { get; } = new();

    /// <inheritdoc cref="AEphemerisHeaderInterpreter{THeader}"/>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="EphemerisInterpretationOptionsProvider" path="/summary"/></param>
    public AEphemerisHeaderInterpreter(IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider)
    {
        EphemerisInterpretationOptionsProvider = ephemerisInterpretationOptionsProvider;
    }

    /// <summary>Registers a <see cref="IInterpreter{TInterpretation}"/>, <paramref name="interpreter"/>, for invokation when the first line of the <see cref="IEphemerisHeader"/> is encountered.</summary>
    /// <typeparam name="TInterpretation">The type of the result interpreted by the <paramref name="interpreter"/>.</typeparam>
    /// <param name="interpreter">This <see cref="IInterpreter{TInterpretation}"/> is registered for invokation when the first line of the <see cref="IEphemerisHeader"/> is encounterd.</param>
    /// <param name="setter">Delegate for applying the result of the <paramref name="interpreter"/>.</param>
    protected void RegisterFirstLineInterpreter<TInterpretation>(IInterpreter<TInterpretation> interpreter, Func<TInterpretation, THeader, THeader> setter)
    {
        FirstLineInterpreters.Add(wrapper);

        THeader wrapper(QueryResult queryResult, THeader header)
        {
            if (interpreter.Interpret(queryResult) is not { HasValue: true } optionalInterpretation)
            {
                return header;
            }

            return setter(optionalInterpretation.Value, header);
        }
    }

    /// <summary>Registers a <see cref="IInterpreter{TInterpretation}"/>, <paramref name="interpreter"/>, for invokation when a <paramref name="key"/> is encountered.</summary>
    /// <typeparam name="TInterpretation">The type of the result interpreted by the <paramref name="interpreter"/>.</typeparam>
    /// <param name="interpreter">This <see cref="IInterpreter{TInterpretation}"/> is registered for invokation when a <paramref name="key"/> is encounterd.</param>
    /// <param name="key">The key which, when encountered, results in the <paramref name="interpreter"/> being invoked.</param>
    /// <param name="setter">Delegate for applying the result of the <paramref name="interpreter"/>.</param>
    protected void RegisterKeyInterpreter<TInterpretation>(IInterpreter<TInterpretation> interpreter, string key, Func<TInterpretation, THeader, THeader> setter)
    {
        key = FormatKey(key);

        if (KeyInterpreters.ContainsKey(key) is false)
        {
            KeyInterpreters[key] = new List<Func<QueryResult, THeader, THeader>>(1) { wrapper };

            return;
        }

        KeyInterpreters[key].Add(wrapper);

        THeader wrapper(QueryResult queryResult, THeader header)
        {
            if (interpreter.Interpret(queryResult) is not { HasValue: true } optionalInterpretation)
            {
                return header;
            }

            return setter(optionalInterpretation.Value, header);
        }
    }

    /// <summary>Attempts to interpret <paramref name="queryResult"/>, resulting in an instance of <typeparamref name="THeader"/>.</summary>
    /// <param name="queryResult">This <see cref="QueryResult"/> is interpreted as an instance of <typeparamref name="THeader"/>, if possible.</param>
    protected Optional<THeader> Interpret(QueryResult queryResult)
    {
        if (ConstructHeader(queryResult) is not { HasValue: true, Value: var header })
        {
            return new();
        }

        var linesEnumerator = SplitLines(queryResult.Content).GetEnumerator();

        while (linesEnumerator.MoveNext())
        {
            if (linesEnumerator.Current.Length is 0)
            {
                continue;
            }

            if (TryInterpretFirstLine(new QueryResult(queryResult.Signature, linesEnumerator.Current), header) is { HasValue: true } optionalHeader)
            {
                header = optionalHeader.Value;

                break;
            }
        }

        while (linesEnumerator.MoveNext())
        {
            if (CheckExitKeyIterator(linesEnumerator.Current))
            {
                break;
            }

            header = InterpretLine(new QueryResult(queryResult.Signature, linesEnumerator.Current), header);
        }

        var quantities = InterpretEphemerisQuantities(linesEnumerator);

        header = SetQuantities(header, quantities);

        if (ValidateHeader(header) is false)
        {
            return new();
        }

        return header;
    }

    /// <summary>Attempts to construct a <typeparamref name="THeader"/>.</summary>
    /// <param name="queryResult">The <see cref="QueryResult"/> which the constructed <typeparamref name="THeader"/> will describe.</param>
    protected abstract Optional<THeader> ConstructHeader(QueryResult queryResult);

    /// <summary>Sets the <see cref="IEphemerisHeader.Quantities"/> of the <paramref name="header"/> to <paramref name="quantities"/>, resulting in a new instance of <typeparamref name="THeader"/>, which was based on <paramref name="header"/>.</summary>
    /// <param name="header">The instance of <typeparamref name="THeader"/> representing the initial interpretation, on which the new instance of <typeparamref name="THeader"/> is based.</param>
    /// <param name="quantities">The <see cref="IEphemerisHeader.Quantities"/> of the <paramref name="header"/> is set to this <see cref="EphemerisQuantityTable"/>.</param>
    protected abstract THeader SetQuantities(THeader header, EphemerisQuantityTable quantities);

    /// <summary>Determines the validity of the <typeparamref name="THeader"/> <paramref name="header"/>.</summary>
    /// <param name="header">This <typeparamref name="THeader"/> is validated.</param>
    protected virtual bool ValidateHeader(THeader header) => true;

    /// <summary>Attempts to interpret the first <paramref name="line"/> of the <see cref="IEphemerisHeader"/>, resulting in a new instance of <typeparamref name="THeader"/>, which was based on <paramref name="header"/>.</summary>
    /// <param name="line">A line of the <see cref="QueryResult"/>, which is interpreted as the first line of the <see cref="IEphemerisHeader"/>, if possible.</param>
    /// <param name="header">The instance of <typeparamref name="THeader"/> representing the initial interpretation, on which the new instance of <typeparamref name="THeader"/> is based.</param>
    private Optional<THeader> TryInterpretFirstLine(QueryResult line, THeader header)
    {
        if (line.Content.StartsWith(EphemerisInterpretationOptionsProvider.EphemerisDataStart, StringComparison.Ordinal) is false)
        {
            return new();
        }

        return InvokeFirstLineInterpreters(line, header);
    }

    /// <summary>Interprets the first <paramref name="line"/> of the <see cref="IEphemerisHeader"/> by invoking the <see cref="FirstLineInterpreters"/>, resulting in a new instance of <typeparamref name="THeader"/>, which was based on <paramref name="header"/>.</summary>
    /// <param name="line">The first line of the <see cref="IEphemerisHeader"/>.</param>
    /// <param name="header">The instance of <typeparamref name="THeader"/> representing the initial interpretation, on which the new instance of <typeparamref name="THeader"/> is based.</param>
    private THeader InvokeFirstLineInterpreters(QueryResult line, THeader header)
    {
        foreach (var interpreter in FirstLineInterpreters)
        {
            header = interpreter(line, header);
        }

        return header;
    }

    /// <summary>Checks whether the <see cref="IEphemerisHeader"/> has been iterated.</summary>
    /// <param name="line">The current line of the iteration of the <see cref="IEphemerisHeader"/>.</param>
    private bool CheckExitKeyIterator(string line) => line == EphemerisInterpretationOptionsProvider.StartOfEphemeris;

    /// <summary>Interprets a <paramref name="line"/> of the <see cref="IEphemerisHeader"/>, resulting in a new instance of <typeparamref name="THeader"/>, which was based on <paramref name="header"/>.</summary>
    /// <param name="line">A line of the <see cref="IEphemerisHeader"/>.</param>
    /// <param name="header">The instance of <typeparamref name="THeader"/> representing the initial interpretation, on which the new instance of <typeparamref name="THeader"/> is based.</param>
    private THeader InterpretLine(QueryResult line, THeader header)
    {
        if (line.Content.Split(':') is not { Length: > 1 } colonSplit)
        {
            return header;
        }

        var key = FormatKey(colonSplit[0]);

        return InvokeKeyInterpreters(key, line, header);
    }

    /// <summary>Interprets a <paramref name="line"/> of the <see cref="IEphemerisHeader"/> by invoking the <see cref="KeyInterpreters"/>, resulting in a new instance of <typeparamref name="THeader"/>, which was based on <paramref name="header"/>.</summary>
    /// <param name="key">The <see cref="string"/> key of the <paramref name="line"/>.</param>
    /// <param name="line">A line of the <see cref="IEphemerisHeader"/>, corresponding to some <paramref name="key"/>.</param>
    /// <param name="header">The instance of <typeparamref name="THeader"/> representing the initial interpretation, on which the new instance of <typeparamref name="THeader"/> is based.</param>
    private THeader InvokeKeyInterpreters(string key, QueryResult line, THeader header)
    {
        if (KeyInterpreters.TryGetValue(key, out var interpreters))
        {
            foreach (var interpreter in interpreters)
            {
                header = interpreter(line, header);
            }
        }

        return header;
    }

    /// <summary>Interprets the <see cref="EphemerisQuantityTable"/> from <paramref name="linesEnumerator"/>.</summary>
    /// <param name="linesEnumerator">Used to iterate the lines of the <see cref="IEphemerisHeader"/>.</param>
    private static EphemerisQuantityTable InterpretEphemerisQuantities(IEnumerator<string> linesEnumerator)
    {
        Dictionary<EphemerisQuantityTableIndex, EphemerisQuantityIdentifier> quantities = new();

        var rowIndex = 0;

        while (linesEnumerator.MoveNext())
        {
            if (linesEnumerator.Current[0] is '*')
            {
                break;
            }

            var columnIndex = 0;

            foreach (var component in getComponentsOfLine(linesEnumerator.Current))
            {
                quantities[new EphemerisQuantityTableIndex(rowIndex, columnIndex)] = new EphemerisQuantityIdentifier(component.Replace("_", string.Empty, StringComparison.Ordinal).Trim(), component.Length);

                columnIndex += 1;
            }

            rowIndex += 1;
        }

        return new(quantities, rowIndex);

        static IEnumerable<string> getComponentsOfLine(string line)
        {
            StringBuilder component = new();

            var lastCharacterWasWhiteSpaceOrComma = true;

            foreach (var character in line)
            {
                if (lastCharacterWasWhiteSpaceOrComma)
                {
                    append(character);

                    if (character is not (' ' or ',' or ':'))
                    {
                        lastCharacterWasWhiteSpaceOrComma = false;
                    }

                    continue;
                }

                if (character is ' ' or ',' or ':')
                {
                    yield return component.ToString();

                    component.Clear();

                    lastCharacterWasWhiteSpaceOrComma = true;
                }

                append(character);
            }

            if (component.Length > 0 && lastCharacterWasWhiteSpaceOrComma is false)
            {
                yield return component.ToString();
            }

            void append(char character)
            {
                if (character is ',' or ':')
                {
                    component.Append(' ');

                    return;
                }

                component.Append(character);
            }
        }
    }

    /// <summary>Converts <paramref name="key"/> to a format suitable for comparison.</summary>
    /// <param name="key">This <see cref="string"/> is formatted.</param>
    private static string FormatKey(string key) => key.Replace(" ", string.Empty, StringComparison.Ordinal).ToUpperInvariant();

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
}

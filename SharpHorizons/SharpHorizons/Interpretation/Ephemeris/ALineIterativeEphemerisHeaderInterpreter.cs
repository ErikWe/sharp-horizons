namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Query.Result;

using System;
using System.Collections.Generic;
using System.IO;

/// <summary>Handles iterative interpretation of the lines of an <see cref="IEphemerisHeader"/>.</summary>
/// <typeparam name="THeader">The type of the interpreted <see cref="IEphemerisHeader"/>.</typeparam>
internal abstract class ALineIterativeEphemerisHeaderInterpreter<THeader> where THeader : IEphemerisHeader
{
    /// <inheritdoc cref="IInterpretationOptionsProvider"/>
    private IInterpretationOptionsProvider InterpretationOptionsProvider { get; }

    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider"/>
    private IEphemerisInterpretationOptionsProvider EphemerisInterpretationOptionsProvider { get; }

    /// <summary>Delegates registered for invokation when the first line of the <see cref="IEphemerisHeader"/> is encountered.</summary>
    private ICollection<Func<string, THeader, THeader>> FirstLineInterpreters { get; } = new List<Func<string, THeader, THeader>>();

    /// <summary>Delegates registered for invokation when some <see cref="string"/> key is encountered.</summary>
    private Dictionary<string, ICollection<Func<string, THeader, THeader>>> KeyInterpreters { get; } = new();

    /// <inheritdoc cref="ALineIterativeEphemerisHeaderInterpreter{THeader}"/>
    /// <param name="interpretationOptionsProvider"><inheritdoc cref="InterpretationOptionsProvider" path="/summary"/></param>
    /// <param name="ephemerisInterpretationOptionsProvider"><inheritdoc cref="EphemerisInterpretationOptionsProvider" path="/summary"/></param>
    public ALineIterativeEphemerisHeaderInterpreter(IInterpretationOptionsProvider interpretationOptionsProvider, IEphemerisInterpretationOptionsProvider ephemerisInterpretationOptionsProvider)
    {
        InterpretationOptionsProvider = interpretationOptionsProvider;
        EphemerisInterpretationOptionsProvider = ephemerisInterpretationOptionsProvider;
    }

    /// <summary>Registers a <see cref="IPartInterpreter{TInterpretation}"/>, <paramref name="interpreter"/>, for invokation when the first line of the <see cref="IEphemerisHeader"/> is encountered.</summary>
    /// <typeparam name="TInterpretation">The type of the result interpreted by the <paramref name="interpreter"/>.</typeparam>
    /// <param name="interpreter">This <see cref="IInterpreter{TInterpretation}"/> is registered for invokation when the first line of the <see cref="IEphemerisHeader"/> is encounterd.</param>
    /// <param name="setter">Delegate for applying the result of the <paramref name="interpreter"/>.</param>
    protected void RegisterFirstLineInterpreter<TInterpretation>(IPartInterpreter<TInterpretation> interpreter, Func<TInterpretation, THeader, THeader> setter)
    {
        FirstLineInterpreters.Add(wrapper);

        THeader wrapper(string line, THeader header)
        {
            if (interpreter.Interpret(line) is not { HasValue: true } optionalHeader)
            {
                return header;
            }

            return setter(optionalHeader.Value, header);
        }
    }

    /// <summary>Registers a <see cref="IPartInterpreter{TInterpretation}"/>, <paramref name="interpreter"/>, for invokation when a <paramref name="key"/> is encountered.</summary>
    /// <typeparam name="TInterpretation">The type of the result interpreted by the <paramref name="interpreter"/>.</typeparam>
    /// <param name="interpreter">This <see cref="IInterpreter{TInterpretation}"/> is registered for invokation when a <paramref name="key"/> is encounterd.</param>
    /// <param name="key">The key which, when encountered, results in the <paramref name="interpreter"/> being invoked.</param>
    /// <param name="setter">Delegate for applying the result of the <paramref name="interpreter"/>.</param>
    protected void RegisterKeyInterpreter<TInterpretation>(IPartInterpreter<TInterpretation> interpreter, string key, Func<TInterpretation, THeader, THeader> setter)
    {
        key = FormatKey(key);

        if (KeyInterpreters.ContainsKey(key) is false)
        {
            KeyInterpreters[key] = new List<Func<string, THeader, THeader>>(1) { wrapper };

            return;
        }

        KeyInterpreters[key].Add(wrapper);

        THeader wrapper(string line, THeader header)
        {
            if (interpreter.Interpret(line) is not { HasValue: true } optionalHeader)
            {
                return header;
            }

            return setter(optionalHeader.Value, header);
        }
    }

    /// <summary>Attempts to interpret <paramref name="queryResult"/>, resulting in an instance of <typeparamref name="THeader"/>.</summary>
    /// <param name="queryResult">This <see cref="IQueryResult"/> is interpreted as an instance of <typeparamref name="THeader"/>, if possible.</param>
    protected Optional<THeader> Interpret(IQueryResult queryResult)
    {
        if (ConstructHeader(queryResult) is not { HasValue: true, Value: var header })
        {
            return new();
        }

        var linesEnumerator = SplitLines(queryResult.Content).GetEnumerator();

        while (linesEnumerator.MoveNext())
        {
            if (TryInterpretFirstLine(linesEnumerator.Current, header) is { HasValue: true } optionalHeader)
            {
                header = optionalHeader.Value;

                break;
            }
        }

        int blockSeparatorCount = 0;

        while (linesEnumerator.MoveNext())
        {
            if (CheckExitKeyIterator(linesEnumerator.Current, ref blockSeparatorCount))
            {
                break;
            }

            header = InterpretLine(linesEnumerator.Current, header);
        }

        var quantities = InterpretEphemerisQuantities(linesEnumerator);

        header = SetQuantities(header, quantities);

        if (ValidateHeader(header) is false)
        {
            return new();
        }

        return header;
    }

    /// <summary>Attempts to interpret the first <paramref name="line"/> of the <see cref="IEphemerisHeader"/>, resulting in a new instance of <typeparamref name="THeader"/>, which was based on <paramref name="header"/>.</summary>
    /// <param name="line">A line of the <see cref="IQueryResult"/>, which is interpreted as the first line of the <see cref="IEphemerisHeader"/>, if possible.</param>
    /// <param name="header">The instance of <typeparamref name="THeader"/> representing the initial interpretation, on which the new instance of <typeparamref name="THeader"/> is based.</param>
    private Optional<THeader> TryInterpretFirstLine(string line, THeader header)
    {
        if (line.StartsWith(EphemerisInterpretationOptionsProvider.EphemerisDataStart) is false)
        {
            return new();
        }

        return InvokeFirstLineInterpreters(line, header);
    }

    /// <summary>Interprets the first <paramref name="line"/> of the <see cref="IEphemerisHeader"/> by invoking the <see cref="FirstLineInterpreters"/>, resulting in a new instance of <typeparamref name="THeader"/>, which was based on <paramref name="header"/>.</summary>
    /// <param name="line">The first line of the <see cref="IEphemerisHeader"/>.</param>
    /// <param name="header">The instance of <typeparamref name="THeader"/> representing the initial interpretation, on which the new instance of <typeparamref name="THeader"/> is based.</param>
    private THeader InvokeFirstLineInterpreters(string line, THeader header)
    {
        foreach (var interpreter in FirstLineInterpreters)
        {
            header = interpreter(line, header);
        }

        return header;
    }

    /// <summary>Checks whether the <see cref="IEphemerisHeader"/> has been iterated.</summary>
    /// <param name="line">A line of the <see cref="IEphemerisHeader"/>.</param>
    /// <param name="blockSeparatorCount">The number of block separators that has been encountered.</param>
    private bool CheckExitKeyIterator(string line, ref int blockSeparatorCount)
    {
        if (line.StartsWith(InterpretationOptionsProvider.BlockSeparator) is false)
        {
            return false;
        }

        blockSeparatorCount += 1;

        return blockSeparatorCount == EphemerisInterpretationOptionsProvider.EphemerisDataBlockCount;
    }

    /// <summary>Interprets a <paramref name="line"/> of the <see cref="IEphemerisHeader"/>, resulting in a new instance of <typeparamref name="THeader"/>, which was based on <paramref name="header"/>.</summary>
    /// <param name="line">A line of the <see cref="IEphemerisHeader"/>.</param>
    /// <param name="header">The instance of <typeparamref name="THeader"/> representing the initial interpretation, on which the new instance of <typeparamref name="THeader"/> is based.</param>
    private THeader InterpretLine(string line, THeader header)
    {
        if (line.Split(':') is not { Length: > 1 } colonSplit)
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
    private THeader InvokeKeyInterpreters(string key, string line, THeader header)
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


    /// <summary>Interprets the <see cref="EphemerisQuantities"/> from <paramref name="linesEnumerator"/>.</summary>
    /// <param name="linesEnumerator">Used to iterate the lines of the <see cref="IEphemerisHeader"/>.</param>
    private EphemerisQuantities InterpretEphemerisQuantities(IEnumerator<string> linesEnumerator)
    {
        Dictionary<(int, int), string> quantities = new();

        int rowIndex = 0;

        while (linesEnumerator.MoveNext())
        {
            if (linesEnumerator.Current.StartsWith(InterpretationOptionsProvider.BlockSeparator))
            {
                break;
            }

            var components = getComponentsOfLine(linesEnumerator.Current);

            for (int columnIndex = 0; columnIndex < components.Length; columnIndex++)
            {
                quantities[(rowIndex, columnIndex)] = components[columnIndex];
            }

            rowIndex += 1;
        }

        return new(quantities, rowIndex);

        static string[] getComponentsOfLine(string line)
        {
            if (line.Contains(','))
            {
                return line.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            }

            return line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }

    /// <summary>Converts <paramref name="key"/> to a format suitable for comparison.</summary>
    /// <param name="key">This <see cref="string"/> is formatted.</param>
    private static string FormatKey(string key) => key.Replace(" ", string.Empty).ToUpperInvariant();

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

    /// <summary>Attempts to construct a <typeparamref name="THeader"/>.</summary>
    /// <param name="queryResult">The <see cref="IQueryResult"/> which the constructed <typeparamref name="THeader"/> will describe.</param>
    protected abstract Optional<THeader> ConstructHeader(IQueryResult queryResult);

    /// <summary>Sets the <see cref="IEphemerisHeader.Quantities"/> of the <paramref name="header"/> to <paramref name="quantities"/>, resulting in a new instance of <typeparamref name="THeader"/>, which was based on <paramref name="header"/>.</summary>
    /// <param name="header">The instance of <typeparamref name="THeader"/> representing the initial interpretation, on which the new instance of <typeparamref name="THeader"/> is based.</param>
    /// <param name="quantities">The <see cref="IEphemerisHeader.Quantities"/> of the <paramref name="header"/> is set to this <see cref="EphemerisQuantities"/>.</param>
    protected abstract THeader SetQuantities(THeader header, EphemerisQuantities quantities);

    /// <summary>Checks that <paramref name="header"/> represents a valid <typeparamref name="THeader"/>.</summary>
    /// <param name="header">This <typeparamref name="THeader"/> is validated.</param>
    protected virtual bool ValidateHeader(THeader header) => true;
}

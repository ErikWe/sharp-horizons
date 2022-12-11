namespace SharpHorizons.Interpretation.Ephemeris;

using Microsoft.CodeAnalysis;

using SharpHorizons.Query.Result;

using System;
using System.Collections.Generic;
using System.IO;

/// <summary>Handles iterative interpretation of the lines of the the ephemeris header.</summary>
/// <typeparam name="THeader">The type of the interpreted header.</typeparam>
internal abstract class ALineIterativeEphemerisQueryHeaderInterpreter<THeader>
{
    /// <inheritdoc cref="IEphemerisInterpretationOptionsProvider"/>
    private IEphemerisInterpretationOptionsProvider InterpretationOptionsProvider { get; }

    /// <summary>Delegates registered for invokation when the first line of the ephemeris header is encountered.</summary>
    private ICollection<Func<string, THeader, THeader>> FirstLineInterpreters { get; } = new List<Func<string, THeader, THeader>>();

    /// <summary>Delegates registered for invokation when some <see cref="string"/> key is encountered.</summary>
    private Dictionary<string, ICollection<Func<string, THeader, THeader>>> KeyInterpreters { get; } = new();

    /// <inheritdoc cref="ALineIterativeEphemerisQueryHeaderInterpreter{THeader}"/>
    /// <param name="interpretationOptionsProvider"><inheritdoc cref="InterpretationOptionsProvider" path="/summary"/></param>
    public ALineIterativeEphemerisQueryHeaderInterpreter(IEphemerisInterpretationOptionsProvider interpretationOptionsProvider)
    {
        InterpretationOptionsProvider = interpretationOptionsProvider;
    }

    /// <summary>Registers a <see cref="IPartInterpreter{TInterpretation}"/>, <paramref name="interpreter"/>, for invokation when the first line of the ephemeris header is encountered.</summary>
    /// <typeparam name="TInterpretation">The type of the result interpreted by the <paramref name="interpreter"/>.</typeparam>
    /// <param name="interpreter">This <see cref="IInterpreter{TInterpretation}"/> is registered for invokation when the first line of the ephemeris header is encounterd.</param>
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
            if (CheckExitIterator(linesEnumerator.Current, ref blockSeparatorCount))
            {
                break;
            }

            header = InterpretLine(linesEnumerator.Current, header);
        }

        if (ValidateHeader(header) is false)
        {
            return new();
        }

        return header;
    }

    /// <summary>Attempts to interpret the first <paramref name="line"/> of the ephemeris header, resulting in a new instance of <typeparamref name="THeader"/>, which was based on <paramref name="header"/>.</summary>
    /// <param name="line">A line of the <see cref="IQueryResult"/>, which is interpreted as the first line of the ephemeris header, if possible.</param>
    /// <param name="header">The instance of <typeparamref name="THeader"/> representing the initial interpretation, on which the new instance of <typeparamref name="THeader"/> is based.</param>
    private Optional<THeader> TryInterpretFirstLine(string line, THeader header)
    {
        if (line.StartsWith(InterpretationOptionsProvider.EphemerisDataStart) is false)
        {
            return new();
        }

        return InvokeFirstLineInterpreters(line, header);
    }

    /// <summary>Interprets the first <paramref name="line"/> of the ephemeris header by invoking the <see cref="FirstLineInterpreters"/>, resulting in a new instance of <typeparamref name="THeader"/>, which was based on <paramref name="header"/>.</summary>
    /// <param name="line">The first line of the ephemeris header.</param>
    /// <param name="header">The instance of <typeparamref name="THeader"/> representing the initial interpretation, on which the new instance of <typeparamref name="THeader"/> is based.</param>
    private THeader InvokeFirstLineInterpreters(string line, THeader header)
    {
        foreach (var interpreter in FirstLineInterpreters)
        {
            header = interpreter(line, header);
        }

        return header;
    }

    /// <summary>Checks whether the ephemeris header has been iterated over.</summary>
    /// <param name="line">A line of the ephemeris header.</param>
    /// <param name="blockSeparatorCount">The number of block separators that has been encountered.</param>
    private bool CheckExitIterator(string line, ref int blockSeparatorCount)
    {
        if (line.StartsWith(InterpretationOptionsProvider.BlockSeparator) is false)
        {
            return false;
        }

        blockSeparatorCount += 1;

        return blockSeparatorCount == InterpretationOptionsProvider.EphemerisDataBlockCount;
    }

    /// <summary>Interprets a <paramref name="line"/> of the ephemeris header, resulting in a new instance of <typeparamref name="THeader"/>, which was based on <paramref name="header"/>.</summary>
    /// <param name="line">A line of the ephemeris header.</param>
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

    /// <summary>Interprets a <paramref name="line"/> of the ephemeris header by invoking the <see cref="KeyInterpreters"/>, resulting in a new instance of <typeparamref name="THeader"/>, which was based on <paramref name="header"/>.</summary>
    /// <param name="key">The <see cref="string"/> key of the <paramref name="line"/>.</param>
    /// <param name="line">A line of the ephemeris header, corresponding to some <paramref name="key"/>.</param>
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

    /// <summary>Checks that <paramref name="header"/> represents a valid <typeparamref name="THeader"/>.</summary>
    /// <param name="header">This <typeparamref name="THeader"/> is validated.</param>
    protected virtual bool ValidateHeader(THeader header) => true;
}

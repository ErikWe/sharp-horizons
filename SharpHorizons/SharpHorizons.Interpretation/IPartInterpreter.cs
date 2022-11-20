namespace SharpHorizons.Interpretation;

using Microsoft.CodeAnalysis;

using SharpHorizons.Query.Result;

/// <summary>Interprets some part of <see cref="IQueryResult"/> as <typeparamref name="TInterpretation"/>.</summary>
/// <typeparam name="TInterpretation">The type of the interpreted result.</typeparam>
public interface IPartInterpreter<TInterpretation>
{
    /// <summary>Interprets <paramref name="queryPart"/>, resulting in an instance of type <typeparamref name="TInterpretation"/>.</summary>
    /// <param name="queryPart">This part of a <see cref="IQueryResult"/> is interpreted as an instance of type <typeparamref name="TInterpretation"/>.</param>
    /// <exception cref="UnexpectedQueryResultFormatException"/>
    public virtual TInterpretation Interpret(string queryPart)
    {
        if (TryInterpret(queryPart) is not { HasValue: true, Value: var result })
        {
            throw new UnexpectedQueryResultFormatException();
        }

        return result;
    }

    /// <summary>Attempts to interpret <paramref name="queryPart"/>, resulting in an instance of type <typeparamref name="TInterpretation"/>.</summary>
    /// <param name="queryPart">This part of a <see cref="IQueryResult"/> is interpreted as an instance of type <typeparamref name="TInterpretation"/>, if possible.</param>
    public abstract Optional<TInterpretation> TryInterpret(string queryPart);
}

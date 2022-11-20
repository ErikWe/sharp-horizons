namespace SharpHorizons.Interpretation;

using Microsoft.CodeAnalysis;

using SharpHorizons.Query.Result;

/// <summary>Interprets <see cref="IQueryResult"/> as <typeparamref name="TInterpretation"/>.</summary>
/// <typeparam name="TInterpretation">The type of the interpreted result.</typeparam>
public interface IInterpreter<TInterpretation>
{
    /// <summary>Interprets <paramref name="queryResult"/>, resulting in an instance of type <typeparamref name="TInterpretation"/>.</summary>
    /// <param name="queryResult">This <see cref="IQueryResult"/> is interpreted as an instance of type <typeparamref name="TInterpretation"/>.</param>
    /// <exception cref="UnexpectedQueryResultFormatException"/>
    public virtual TInterpretation Interpret(IQueryResult queryResult)
    {
        if (TryInterpret(queryResult) is not { HasValue: true, Value: var result })
        {
            throw new UnexpectedQueryResultFormatException();
        }

        return result;
    }

    /// <summary>Attempts to interpret <paramref name="queryResult"/>, resulting in an instance of type <typeparamref name="TInterpretation"/>.</summary>
    /// <param name="queryResult">This <see cref="IQueryResult"/> is interpreted as an instance of type <typeparamref name="TInterpretation"/>, if possible.</param>
    public abstract Optional<TInterpretation> TryInterpret(IQueryResult queryResult);
}

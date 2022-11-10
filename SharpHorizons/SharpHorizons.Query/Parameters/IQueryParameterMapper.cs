namespace SharpHorizons.Query.Parameters;

using SharpHorizons.Query.Arguments;

/// <summary>Handles mapping of <see cref="IQueryArgumentSet"/> to <see cref="IQueryParameterSet"/>.</summary>
public interface IQueryParameterMapper
{
    /// <summary>Maps <paramref name="arguments"/> to a <see cref="IQueryParameterSet"/>.</summary>
    /// <param name="arguments">This <see cref="IQueryArgumentSet"/> is mapped to a <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSet Map(IQueryArgumentSet arguments);
}

namespace SharpHorizons.Query.Parameters;

/// <summary>Handles construction of <see cref="IQueryParameterSetBuilder"/>.</summary>
public interface IQueryParameterSetBuilderFactory
{
    /// <summary>Constructs a <see cref="IQueryParameterSetBuilder"/>.</summary>
    /// <param name="command">The <see cref="ICommandParameter"/> of the <see cref="IQueryParameterSet"/>.</param>
    public abstract IQueryParameterSetBuilder Create(ICommandParameter command);
}

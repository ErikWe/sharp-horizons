namespace SharpHorizons.Query;

/// <summary>Handles construction of <see cref="IQueryArgumentsBuilder"/>.</summary>
public interface IQueryArgumentsBuilderFactory
{
    /// <summary>Constructs a <see cref="IQueryArgumentsBuilder"/>.</summary>
    public abstract IQueryArgumentsBuilder Create();
}

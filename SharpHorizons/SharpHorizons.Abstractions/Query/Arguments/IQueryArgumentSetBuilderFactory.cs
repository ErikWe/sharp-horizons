namespace SharpHorizons.Query.Arguments;

/// <summary>Handles construction of <see cref="IQueryArgumentSetBuilder"/>.</summary>
public interface IQueryArgumentSetBuilderFactory
{
    /// <summary>Constructs a <see cref="IQueryArgumentSetBuilder"/>.</summary>
    public abstract IQueryArgumentSetBuilder Create();
}

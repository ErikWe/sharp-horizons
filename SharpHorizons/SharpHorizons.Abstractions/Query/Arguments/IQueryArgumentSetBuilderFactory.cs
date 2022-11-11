namespace SharpHorizons.Query.Arguments;

/// <summary>Handles construction of <see cref="IQueryArgumentSetBuilder"/>.</summary>
public interface IQueryArgumentSetBuilderFactory
{
    /// <summary>Constructs a <see cref="IQueryArgumentSetBuilder"/>.</summary>
    /// <param name="command">The <see cref="ICommandArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    public abstract IQueryArgumentSetBuilder Create(ICommandArgument command);
}

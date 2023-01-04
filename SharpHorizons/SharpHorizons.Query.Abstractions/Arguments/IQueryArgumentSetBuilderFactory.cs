namespace SharpHorizons.Query.Arguments;

using System;

/// <summary>Handles construction of <see cref="IQueryArgumentSetBuilder"/>.</summary>
public interface IQueryArgumentSetBuilderFactory
{
    /// <summary>Constructs a <see cref="IQueryArgumentSetBuilder"/> with the <see cref="ICommandArgument"/> <paramref name="command"/>.</summary>
    /// <param name="command">The <see cref="ICommandArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder Create(ICommandArgument command);
}

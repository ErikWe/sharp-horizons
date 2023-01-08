namespace SharpHorizons.Query.Arguments;

using System;

/// <summary>Handles construction of <see cref="IQueryArgumentSet"/>.</summary>
public interface IQueryArgumentSetFactory
{
    /// <summary>Constructs a <see cref="IQueryArgumentSetBuilder"/>, handling incremental construction of <see cref="IQueryArgumentSet"/> - with <paramref name="command"/> as the required <see cref="ICommandArgument"/>.</summary>
    /// <param name="command">The <see cref="ICommandArgument"/> of the <see cref="IQueryArgumentSet"/>.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder CreateBuilder(ICommandArgument command);

    /// <summary>Constructs a <see cref="IQueryArgumentSetBuilder"/>, handling incremental construction of <see cref="IQueryArgumentSet"/> - with an initial configuration <paramref name="argumentSet"/>.</summary>
    /// <param name="argumentSet">The initial configuration of the <see cref="IQueryArgumentSetBuilder"/>. This instance is not modified.</param>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentNullException"/>
    public abstract IQueryArgumentSetBuilder CreateBuilder(IQueryArgumentSet argumentSet);
}

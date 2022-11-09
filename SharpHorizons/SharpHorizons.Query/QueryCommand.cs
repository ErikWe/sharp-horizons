namespace SharpHorizons.Query;

using SharpHorizons.Identity;
using SharpHorizons.Query.Target;

/// <summary>Specifies the command associated with a query.</summary>
public enum QueryCommand
{
    /// <summary>Retrieve ephemerides for a <see cref="ITarget"/>.</summary>
    Ephemerides,
    /// <summary>Retrieve a list of <see cref="MajorObject"/>.</summary>
    MajorBodyList,
    /// <summary>Retrieve a list of Horizons news.</summary>
    News
}

namespace SharpHorizons.Query;

using SharpHorizons;
using SharpHorizons.Query.Target;

/// <summary>Specifies the command associated with a query.</summary>
public enum QueryCommand
{
    /// <summary>The <see cref="QueryCommand"/> is unknown.</summary>
    Unknown,
    /// <summary>Retrieve an ephemeris for a <see cref="ITarget"/>.</summary>
    Ephemeris,
    /// <summary>Retrieve a list of <see cref="MajorObject"/>.</summary>
    MajorBodyList,
    /// <summary>Retrieve a list of Horizons news.</summary>
    News
}

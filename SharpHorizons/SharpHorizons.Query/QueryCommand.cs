namespace SharpHorizons.Query;

using SharpHorizons;
using SharpHorizons.Ephemeris;

/// <summary>Specifies the command associated with a query.</summary>
public enum QueryCommand
{
    /// <summary>The <see cref="QueryCommand"/> is unknown.</summary>
    Unknown,
    /// <summary>Generate an <see cref="IEphemeris{TEntry}"/>.</summary>
    Ephemeris,
    /// <summary>Retrieve a list of <see cref="MajorObject"/>.</summary>
    MajorBodyList,
    /// <summary>Retrieve a list of Horizons news.</summary>
    News
}

namespace SharpHorizons.Identification;

using System;

/// <summary>Describes the type of an astronomical object, as defined in Horizons.</summary>
[Flags]
public enum HorizonsBodyType
{
    /// <summary>The body is neither a small body or a major body.</summary>
    /// <remarks>To represent a body of unknown type, use <see cref="Unknown"/>.</remarks>
    None = 0,
    /// <summary>The body is considered a small body - an asteroid or comet.</summary>
    Small = 1,
    /// <summary>The body is considered a major body - typically a planet, a moon of a planet, a spacecraft, or a few other special cases.</summary>
    Major = 2,
    /// <summary>The type of the body is unknown.</summary>
    Unknown = Small | Major
}
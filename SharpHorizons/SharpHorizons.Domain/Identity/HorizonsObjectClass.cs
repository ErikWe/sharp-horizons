namespace SharpHorizons.Identity;

using System;

/// <summary>Describes how an object is classifed by Horizons.</summary>
[Flags]
public enum HorizonsObjectClass
{
    /// <summary>The object is not classified.</summary>
    /// <remarks>To represent an object of an unknown class, use <see cref="Unknown"/>.</remarks>
    None = 0,
    /// <summary>The object is classified as a small body - an asteroid or comet.</summary>
    Small = 1,
    /// <summary>The object is classified as a major body - typically a planet, a moon, or a spacecraft.</summary>
    Major = 2,
    /// <summary>The class of the object is unknown, or the object exists under both classifications <see cref="Small"/> and <see cref="Major"/>.</summary>
    Unknown = Small | Major
}
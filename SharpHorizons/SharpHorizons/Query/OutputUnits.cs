namespace SharpHorizons.Query;

/// <summary>Specifies what units are used to express length and time in the result of a query.</summary>
public enum OutputUnits
{
    /// <summary>Kilometres and seconds are used to express length and time.</summary>
    KilometresAndSeconds,
    /// <summary>Astronomical units and days are used to express length and time.</summary>
    AstronomicalUnitsAndDays,
    /// <summary>Kilometres and days are used to express length and timey.</summary>
    KilometresAndDays
}
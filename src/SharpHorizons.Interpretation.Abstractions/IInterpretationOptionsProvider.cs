namespace SharpHorizons.Interpretation;

using NodaTime;

using SharpHorizons.Query.Result;

/// <summary>Provides options related to the interpretation of <see cref="QueryResult"/>.</summary>
public interface IInterpretationOptionsProvider
{
    /// <summary>The ID of the Horizons time zone, as defined in TZDB and <see cref="IDateTimeZoneProvider"/>.</summary>
    public abstract string HorizonsTimeZoneID { get; }

    /// <summary>The <see cref="string"/> indicating an unavilable value.</summary>
    public abstract string UnavailableText { get; }
}

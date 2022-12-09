namespace SharpHorizons.Interpretation.Ephemeris;

using SharpMeasures;

using System;

/// <summary>Describes the radii of an object along different axes - as interpreted from the result of a query.</summary>
public sealed record class ObjectRadiiInterpretation
{
    /// <summary>The mean equatorial radius of the object, if provided.</summary>
    /// <exception cref="ArgumentException"/>
    public Distance? Equator
    {
        get => equatorField;
        init
        {
            if (value is not null)
            {
                SharpMeasuresValidation.Validate(value.Value);
            }

            equatorField = value;
        }
    }

    /// <summary>The mean radius along the prime meridian of the object, if provided.</summary>
    /// <exception cref="ArgumentException"/>
    public Distance? Meridian
    {
        get => meridianField;
        init
        {
            if (value is not null)
            {
                SharpMeasuresValidation.Validate(value.Value);
            }

            meridianField = value;
        }
    }

    /// <summary>The polar radius of the object, if provided.</summary>
    /// <exception cref="ArgumentException"/>
    public Distance? Pole
    {
        get => poleField;
        init
        {
            if (value is not null)
            {
                SharpMeasuresValidation.Validate(value.Value);
            }

            poleField = value;
        }
    }

    /// <inheritdoc cref="ObjectRadiiInterpretation"/>
    public ObjectRadiiInterpretation() { }

    /// <summary>Backing field for <see cref="Equator"/>. Should not be used elsewhere.</summary>
    private readonly Distance? equatorField;
    /// <summary>Backing field for <see cref="Meridian"/>. Should not be used elsewhere.</summary>
    private readonly Distance? meridianField;
    /// <summary>Backing field for <see cref="Pole"/>. Should not be used elsewhere.</summary>
    private readonly Distance? poleField;
}

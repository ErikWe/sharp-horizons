namespace SharpHorizons;

using SharpHorizons.MPC;

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

/// <summary>Represents an object classified as a major object in Horizons - typically a planet, a moon, or a spacecraft.</summary>
/// <remarks>Asteroids and comets are typically represented using <see cref="MPCObject"/> or <see cref="MPCComet"/> instead.</remarks>
public sealed record class MajorObject
{
    /// <summary>The <see cref="MajorObjectID"/> of the <see cref="MajorObject"/>.</summary>
    public required MajorObjectID ID { get; init; }

    /// <summary>The <see cref="MajorObjectName"/> of the <see cref="MajorObject"/>, or <see langword="null"/> if the <see cref="MajorObject"/> is unnamed.</summary>
    /// <exception cref="ArgumentException"/>
    public MajorObjectName? Name
    {
        get => name;
        init
        {
            if (value is not null)
            {
                MajorObjectName.Validate(value.Value);
            }

            name = value;
        }
    }

    /// <summary>Describes how longitude is defined for the <see cref="MajorObject"/>.</summary>
    /// <exception cref="InvalidEnumArgumentException"/>
    public LongitudeDefinition LongitudeDefinition
    {
        get => longitudeDefinition;
        init
        {
            InvalidEnumArgumentExceptionFactory.ThrowIfUnlisted(value);

            longitudeDefinition = value;
        }
    }

    /// <inheritdoc cref="MajorObject"/>
    public MajorObject() { }

    /// <inheritdoc cref="MajorObject"/>
    /// <param name="id"><inheritdoc cref="ID" path="/summary"/></param>
    [SetsRequiredMembers]
    public MajorObject(MajorObjectID id)
    {
        ID = id;
    }

    /// <inheritdoc cref="MajorObject"/>
    /// <param name="id"><inheritdoc cref="ID" path="/summary"/></param>
    /// <param name="name"><inheritdoc cref="Name" path="/summary"/></param>
    /// <exception cref="ArgumentException"/>
    [SetsRequiredMembers]
    public MajorObject(MajorObjectID id, MajorObjectName? name)
    {
        if (name is not null)
        {
            MajorObjectName.Validate(name.Value);
        }

        ID = id;
        Name = name;
    }

    /// <summary>Backing field for <see cref="Name"/>. Should not be used elsewhere.</summary>
    private readonly MajorObjectName? name = null;

    /// <summary>Backing field for <see cref="LongitudeDefinition"/>. Should not be used elsewhere.</summary>
    private readonly LongitudeDefinition longitudeDefinition = LongitudeDefinition.Unknown;
}
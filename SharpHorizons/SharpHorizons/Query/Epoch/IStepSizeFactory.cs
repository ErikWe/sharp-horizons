namespace SharpHorizons.Query.Epoch;

using SharpHorizons.Composers;
using SharpHorizons.Query.Origin;
using SharpHorizons.Query.Target;

using SharpMeasures;

using System.ComponentModel;

/// <summary>Handles construction of <see cref="IFixedStepSize"/>, describing the <see cref="IStepSize"/> in a query using a fixed <see cref="Time"/>.</summary>
public interface IFixedStepSizeFactory
{
    /// <summary><inheritdoc cref="FixedStepSize(Time, IStepSizeComposer{IFixedStepSize})" path="/summary"/></summary>
    /// <param name="deltaTime"><inheritdoc cref="IFixedStepSize.DeltaTime" path="/summary"/></param>
    public abstract IFixedStepSize Create(Time deltaTime);
}

/// <summary>Handles construction of <see cref="IUniformStepSize"/>, describing the <see cref="IStepSize"/> in a query using an <see cref="int"/> number of uniformly distributed steps.</summary>
public interface IUniformStepSizeFactory
{
    /// <summary><inheritdoc cref="UniformStepSize(int, IStepSizeComposer{IUniformStepSize})" path="/summary"/></summary>
    /// <param name="stepCount"><inheritdoc cref="IUniformStepSize.StepCount" path="/summary"/></param>
    public abstract IUniformStepSize Create(int stepCount);
}

/// <summary>Handles construction of <see cref="ICalendarStepSize"/>, describing the <see cref="IStepSize"/> in a query using some calendar-based unit.</summary>
/// <remarks>To construct <see cref="IStepSize"/> using a non-variable calendar-related unit, such as days or weeks, use <see cref="IFixedStepSizeFactory"/>.</remarks>
public interface ICalendarStepSizeFactory
{
    /// <summary><inheritdoc cref="CalendarStepSize(int, CalendarStepSizeUnit, IStepSizeComposer{ICalendarStepSize})" path="/summary"/></summary>
    /// <param name="count">Describes the size of each attempted step, with the intended <see cref="CalendarStepSizeUnit"/> being specified through <paramref name="unit"/>. A step is skipped if the resulting date does not exist.</param>
    /// <param name="unit">Determines the calendar-based unit that each step is based on - with <paramref name="count"/> scaling the <see cref="CalendarStepSizeUnit"/> by some <see cref="int"/> value.</param>
    /// <exception cref="InvalidEnumArgumentException"/>
    public abstract ICalendarStepSize Create(int count, CalendarStepSizeUnit unit);
}

/// <summary>Handles construction of <see cref="IAngularStepSize"/>, describing the <see cref="IStepSize"/> in a query as the variable amount of time it takes for the position of a <see cref="ITarget"/> to change by some <see cref="Angle"/>, as seen from an <see cref="IOrigin"/>.</summary>
/// <remarks><inheritdoc cref="IAngularStepSize" path="/remarks"/></remarks>
public interface IAngularStepSizeFactory
{
    /// <summary><inheritdoc cref="AngularStepSize(Angle, IStepSizeComposer{IAngularStepSize})" path="/summary"/>.</summary>
    /// <param name="deltaAngle"><inheritdoc cref="IAngularStepSize.DeltaAngle" path="/summary"/></param>
    public abstract IAngularStepSize Create(Angle deltaAngle);
}

namespace SharpHorizons.Query.Arguments.Composers.Epoch;

using SharpMeasures;

using System.Globalization;

internal sealed class TimeZoneComposer : ITimeZoneComposer
{
    ITimeZoneArgument IArgumentComposer<ITimeZoneArgument, Time>.Compose(Time obj)
    {
        SharpMeasuresValidation.Validate(obj);

        var hours = (int)obj.Hours.Round();
        var minutes = (int)((obj.Hours - hours) * 60).Round();

        return new QueryArgument($"{hours.ToString("0", CultureInfo.InvariantCulture)}:{minutes.ToString("00", CultureInfo.InvariantCulture)}");
    }
}

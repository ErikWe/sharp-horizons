namespace SharpHorizons.Tests.IdentityCases.MajorObjectIDCases;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using Xunit;

public class ToString_String
{
    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    [SuppressMessage("Globalization", "CA1305: Specify IFormatProvider", Justification = "Test-case for ToString(string).")]
    public void General_MatchInt32ToStringWithCurrentCulture(MajorObjectID majorObjectID)
    {
        var format = "G";

        var expected = majorObjectID.Value.ToString(format, CultureInfo.CurrentCulture);

        var actual = majorObjectID.ToString(format);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    [SuppressMessage("Globalization", "CA1305: Specify IFormatProvider", Justification = "Test-case for ToString(string).")]
    public void Currency_MatchInt32ToStringWithCurrentCulture(MajorObjectID majorObjectID)
    {
        var format = "C";

        var expected = majorObjectID.Value.ToString(format, CultureInfo.CurrentCulture);

        var actual = majorObjectID.ToString(format);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    [SuppressMessage("Globalization", "CA1305: Specify IFormatProvider", Justification = "Test-case for ToString(string).")]
    public void Null_MatchInt32ToStringWithCurrentCulture(MajorObjectID majorObjectID)
    {
        string? format = null;

        var expected = majorObjectID.Value.ToString(format, CultureInfo.CurrentCulture);

        var actual = majorObjectID.ToString(format);

        Assert.Equal(expected, actual);
    }
}

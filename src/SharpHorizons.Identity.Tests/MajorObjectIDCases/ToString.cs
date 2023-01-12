namespace SharpHorizons.Tests.IdentityCases.MajorObjectIDCases;

using System.Diagnostics.CodeAnalysis;
using System.Globalization;

using Xunit;

public class ToString
{
    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    [SuppressMessage("Globalization", "CA1305: Specify IFormatProvider", Justification = "Test-case for ToString().")]
    public void Valid_MatchInt32ToStringWithCurrentCulture(MajorObjectID majorObjectID)
    {
        var expected = majorObjectID.Value.ToString(CultureInfo.CurrentCulture);

        var actual = majorObjectID.ToString();

        Assert.Equal(expected, actual);
    }
}

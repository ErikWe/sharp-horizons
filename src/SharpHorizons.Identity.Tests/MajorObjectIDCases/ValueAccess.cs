namespace SharpHorizons.Tests.IdentityCases.MajorObjectIDCases;

using Xunit;

public class ValueAccess
{
    [Theory]
    [ClassData(typeof(Datasets.MajorObjectIDs))]
    public void Valid_NoException(MajorObjectID majorObjectID)
    {
        var exception = Record.Exception(() => majorObjectID.Value);

        Assert.Null(exception);
    }
}

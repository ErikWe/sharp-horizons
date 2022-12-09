using System;

internal static class Program
{
    private static void Main()
    {
        Uh();
    }

    private static void Uh()
    {
        try
        {
            throw new InvalidCastException("Hey, that's an invalid cast.");
        }
        catch (Exception e)
        {
            throw new InvalidOperationException("Hey, something went wrong.", e);
        }
    }
}

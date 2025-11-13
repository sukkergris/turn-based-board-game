using System;

public static class Helpers
{
    public static readonly Random Rand = new Random();
    public static int Random()
    {
        var next = Rand.Next(2) == 0 ? -1 : 1;
        return next;
    }
}
namespace GameEngine.Utility;

public interface IPrint
{
    void Print(string message);
    void Clear();
}

public class Printer : IPrint
{
    public void Print(string message)
    {
        Console.WriteLine(message);
    }

    public void Clear() => Console.Clear();
}

public static class Helpers
{
    public static readonly Random Rand = new Random();

    public static int Random()
    {
        var next = Rand.Next(2) == 0 ? -1 : 1;
        return next;
    }

    public static void Print(this string message, IPrint printer)
    {
        printer.Print(message);
    }
}

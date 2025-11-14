namespace GameEngine.Models;

public record XCoordinate(uint Value)
{
    public static XCoordinate Create(uint x) => new XCoordinate(x);

    public static XCoordinate Create(int x, ClosedCartesianCoordinateSystem system)
    {
        int correctedX = system.AutoCorrectXCoordinate(x);
        return new XCoordinate((uint)correctedX);
    }
}

namespace GameEngine.Models;

public record YCoordinate(uint Value)
{
    public static YCoordinate Create(uint y) => new YCoordinate(y);

    public static YCoordinate Create(int y, ClosedCartesianCoordinateSystem system)
    {
        int correctedY = system.AutoCorrectYCoordinate(y);
        return new YCoordinate((uint)correctedY);
    }
}

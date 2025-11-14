namespace GameEngine.Models;

public class ClosedCartesianCoordinateSystem
{
    public readonly uint XLength;
    public readonly uint YLength;

    public ClosedCartesianCoordinateSystem(uint xLength, uint yLength)
    {
        XLength = xLength;
        YLength = yLength;
    }

    public int AutoCorrectXCoordinate(int proposedCoordinate) =>
        AutoCorrectCoordinate(proposedCoordinate, (int)XLength);

    public int AutoCorrectYCoordinate(int proposedCoordinate) =>
        AutoCorrectCoordinate(proposedCoordinate, (int)YLength);

    int AutoCorrectCoordinate(int proposedCoordinate, int length)
    {
        var result = proposedCoordinate % length;
        return result < 0 ? result + length : result;
    }
}

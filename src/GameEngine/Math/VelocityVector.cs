namespace GameEngine.Math;

public class VelocityVector
{
    public readonly ClosedCoordinates Start;
    public readonly ClosedCoordinates End;

    public VelocityVector(ClosedCoordinates start, ClosedCoordinates end)
    {
        Start = start;
        End = end;
    }
}

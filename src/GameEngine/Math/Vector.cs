namespace GameEngine.Math;

// Closed Cartesian coordinate system
public class Vector
{
    public readonly ClosedCoordinates Start;

    public readonly ClosedCoordinates End;

    public Vector(ClosedCoordinates start, ClosedCoordinates end)
    {
        Start = start;

        End = end;
    }

    public double Abs =>
        System.Math.Sqrt(
            System.Math.Pow(End.X.Value - Start.X.Value, 2)
                + System.Math.Pow(End.Y.Value - Start.Y.Value, 2)
        );

    public double Angle =>
        System.Math.Atan((End.Y.Value - Start.Y.Value) / (End.X.Value - Start.X.Value));
}

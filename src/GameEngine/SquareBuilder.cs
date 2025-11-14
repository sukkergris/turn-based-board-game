namespace GameEngine;

public class SquareBuilder
{
    private Square? _square;

    public Square Build(ClosedCoordinates coordinates)
    {
        _square = new Square(coordinates);

        return _square;
    }
}

using GameEngine.Models;

namespace GameEngine;

public record ClosedCoordinates(XCoordinate X, YCoordinate Y)
{
    public static ClosedCoordinates Create(uint x, uint y)
    {
        return new ClosedCoordinates(XCoordinate.Create(x), YCoordinate.Create(y));
    }
}

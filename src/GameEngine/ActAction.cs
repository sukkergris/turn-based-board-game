using GameEngine.Math;
using GameEngine.Models;
using GameEngine.Utility;

namespace GameEngine;

public class ActAction
{
    public World World { get; }
    public Guid ActionId { get; }

    public ActAction(World world, Guid actionId)
    {
        World = world;
        ActionId = actionId;
    }

    public void Act(Player player)
    {
        var coordinates = player.Coordinates;
        var square = World.Squares.Single(s => s.Key == coordinates).Value;
        square.ActionInfo =
            $"{square.Coordinates.X.Value} {square.Coordinates.Y.Value}, name: {player.Name}";
    }

    public ClosedCoordinates Move(Player player)
    {
        var next = NextRandomCoordinate(player.Direction, player.Coordinates);
        return next;
    }

    public ClosedCoordinates NextRandomCoordinate(Vector direction, ClosedCoordinates origin)
    {
        var correctedX = World.CoordinateSystem.AutoCorrectXCoordinate(
            Helpers.Random() + (int)origin.X.Value
        );
        var correctedY = World.CoordinateSystem.AutoCorrectYCoordinate(
            Helpers.Random() + (int)origin.Y.Value
        );
        var next = origin with
        {
            X = XCoordinate.Create((uint)correctedX),
            Y = YCoordinate.Create((uint)correctedY),
        };
        return next;
    }
}

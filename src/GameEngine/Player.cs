using GameEngine.Math;

namespace GameEngine;

public class Player
{
    public List<ClosedCoordinates> Moves = new List<ClosedCoordinates>();
    public string Name { get; }
    public Guid MoveId { get; private set; }
    public ClosedCoordinates Coordinates { get; set; }
    public readonly Vector Direction;

    public Player(World world, ClosedCoordinates startingPoint, Vector direction, string name)
    {
        Coordinates = startingPoint;
        World = world;
        Direction = direction;
        Name = name;
        Moves.Add(startingPoint);
    }

    public World World { get; }

    public void Act(ActAction actAction)
    {
        // Set your mark on the world around you
        actAction.Act(this);
    }

    public void Move(ActAction moveAction)
    {
        // move

        Coordinates = moveAction.Move(this);
        Moves.Add(Coordinates);

        // interact with surroundings
    }
}

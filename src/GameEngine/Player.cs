using GameEngine.Math;
using System;

namespace GameEngine
{
   public class Player
   {
      public Guid MoveId { get; private set; }
      public ClosedCoordinates Coordinates { get; set; }
      public readonly Vector Direction;
      public Player(World world, ClosedCoordinates startingPoint, Vector direction)
      {
         Coordinates = startingPoint;
         World = world;
         Direction = direction;
      }

      public World World { get; }
      public ClosedCoordinates NextRandomCoordinate(Vector direction, ClosedCoordinates origin)
      {
         return origin;
      }
      public void Act(ActAction actAction)
      {

         // set your mark on the world arround you

      }
      public void Move(Guid moveId)
      {
         MoveId = moveId;
         // move
         Coordinates = NextRandomCoordinate(Direction, Coordinates);
         // interact with surroundings
         // 
      }
   }
}
using System.Linq;
using System;
using GameEngine.Math;
using GameEngine.Models;

namespace GameEngine
{
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
         square.ActionInfo = $"{square.Coordinates.X.Value} {square.Coordinates.Y.Value}, name: {player.Name}";
      }

      public ClosedCoordinates Move(Player player)
      {
         var next = NextRandomCoordinate(player.Direction, player.Coordinates);
         return next;
      }
      public ClosedCoordinates NextRandomCoordinate(Vector direction, ClosedCoordinates origin)
      {
         var xlength = World.CoordinateSystem.XLength;
         var ylength = World.CoordinateSystem.YLength;

         var correctedX = World.CoordinateSystem.AutoCorrectCoordinate(Helpers.Random() + (int)origin.X.Value, (int)xlength);
         var correctedY = World.CoordinateSystem.AutoCorrectCoordinate(Helpers.Random() + (int)origin.Y.Value, (int)ylength);
         var next = origin with { X = XCoordinate.Create((uint)correctedX), Y = YCoordinate.Create((uint)correctedY) };
         return next;
      }
   }
}
using GameEngine.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameEngine
{
   public class World
   {
      public readonly uint XAxisCount = 8;
      public readonly uint YAxisCount = 8;
      public readonly ClosedCartesianCoordinateSystem CoordinateSystem;
      public World(ClosedCartesianCoordinateSystem coordinateSystem)
      {
         CoordinateSystem = coordinateSystem;
      }

      public Dictionary<ClosedCoordinates, Square> Squares { get; set; }

      public ClosedCoordinates[] GetSurroundingCoordinates(ClosedCoordinates c)
      {
         var xcoordinates = new int[3] {
            CoordinateSystem.AutoCorrectCoordinate(-1 + (int)c.X.Value, (int)XAxisCount),
            (int)c.X.Value,
            CoordinateSystem.AutoCorrectCoordinate((int)c.X.Value + 1, (int)XAxisCount)
         };
         var ycoordinates = new int[3] {
            CoordinateSystem.AutoCorrectCoordinate((int)c.Y.Value - 1, (int)YAxisCount),
            (int)c.Y.Value,
            CoordinateSystem.AutoCorrectCoordinate((int)c.Y.Value + 1, (int)YAxisCount)
         };

         var coordinates = xcoordinates.SelectMany(x => ycoordinates.Select(y =>
            new ClosedCoordinates(XCoordinate.Create((uint)x), YCoordinate.Create((uint)y))
         )).ToArray();
         return coordinates;
      }
   }
}
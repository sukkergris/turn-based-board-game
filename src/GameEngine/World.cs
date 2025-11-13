using GameEngine.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameEngine
{
   public class World
   {
      public readonly ClosedCartesianCoordinateSystem CoordinateSystem;
      public World(ClosedCartesianCoordinateSystem coordinateSystem)
      {
         CoordinateSystem = coordinateSystem;
      }
      public Dictionary<ClosedCoordinates, Square> Squares { get; set; }

      public ClosedCoordinates[] GetSurroundingCoordinates(ClosedCoordinates c)
      {
         var xcoordinates = new int[3] { AutoCorrectCoordinate(-1 + c.X.Value, xaxiscount), c.X, AutoCorrectCoordinate(c.X + 1, xaxiscount) };
         var ycoordinates = new int[3] { AutoCorrectCoordinate(c.Y.Value - 1, yaxiscount), c.Y, AutoCorrectCoordinate(c.Y.Value + 1, yaxiscount) };
     // 7,7 7,0 7,1
     // 0,7 0,0 0,1 0,2 0,3 0,4 0,5 0,6 0,7
     // 1,7 1,0 1,1 1,2 1,3 1,4 1,5 1,6 1,7
         // 2,0 2,1 2,2 2,3
         // 3,0 3,1 3,2 3,3
         // 4,0 4,1 4,2 4,3
         // 5,0
         // 6,0
         // 7,0 7,1 7,2 7,3 7,4 7,5 7,6 7,7
         var coordinates = xcoordinates.SelectMany(x=>ycoordinates.Select(y=>new ClosedCoordinates(x,y))).ToArray();
         return coordinates;
      }
      public int AutoCorrectCoordinate(int center, int length) => center switch
      {
         < 0 => length - 1,
         int i when i > (length - 1) => 0,
         _ => center
      };
   }
}
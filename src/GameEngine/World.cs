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
         var xcoordinates = new int[3] {
            CoordinateSystem.AutoCorrectXCoordinate(-1 + (int)c.X.Value),
            (int)c.X.Value,
            CoordinateSystem.AutoCorrectYCoordinate((int)c.X.Value + 1)
         };
         var ycoordinates = new int[3] {
            CoordinateSystem.AutoCorrectXCoordinate((int)c.Y.Value - 1),
            (int)c.Y.Value,
            CoordinateSystem.AutoCorrectYCoordinate((int)c.Y.Value + 1)
         };

         var coordinates = xcoordinates.SelectMany(x => ycoordinates.Select(y =>
            ClosedCoordinates.Create((uint)x, (uint)y)
         )).ToArray();
         return coordinates;
      }
      public string Display()
      {
         string output = "Board:\n\n";
         foreach (KeyValuePair<ClosedCoordinates, Square>[] row in FilterForCartesianDisplay(Squares, CoordinateSystem).Chunk((int)CoordinateSystem.XLength))
         {
            output += PrintRow(row.ToArray());
         }
         return output;
      }

      public KeyValuePair<ClosedCoordinates, Square>[] FilterForCartesianDisplay(Dictionary<ClosedCoordinates, Square> coordinates, ClosedCartesianCoordinateSystem coordinateSystem)
      {
         var x = coordinateSystem.XLength;
         List<KeyValuePair<ClosedCoordinates, Square>[]> filtered = new List<KeyValuePair<ClosedCoordinates, Square>[]>();
         for (int i = 0; i < x; i++)
         {
            var selected = coordinates.Where((c, iterator) => iterator % x == i).ToArray();
            filtered.Add(selected);
         }
         filtered.Reverse();
         return filtered.SelectMany(c => c).ToArray();
      }
      private string PrintRow(KeyValuePair<ClosedCoordinates, Square>[] row)
      {
         string output = string.Empty;
         foreach (var (_, square) in row)
         {
            output += $"|x:{square.Coordinates.X.Value},y:{square.Coordinates.Y.Value}| {square.ActionInfo} | ";
         }

         output += "\n";
         return output;
      }

      public ClosedCoordinates CreateFrom(int x, int y)
      {
         var correctedX = (uint)CoordinateSystem.AutoCorrectXCoordinate(x);
         var correctedY = (uint)CoordinateSystem.AutoCorrectYCoordinate(y);
         return ClosedCoordinates.Create(correctedX, correctedY);
      }
   }
}
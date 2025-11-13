using GameEngine.Models;
using System.Collections.Generic;
using System.Linq;
using System;

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
            CoordinateSystem.AutoCorrectCoordinate(-1 + (int)c.X.Value, (int)CoordinateSystem.XLength),
            (int)c.X.Value,
            CoordinateSystem.AutoCorrectCoordinate((int)c.X.Value + 1, (int)CoordinateSystem.XLength)
         };
         var ycoordinates = new int[3] {
            CoordinateSystem.AutoCorrectCoordinate((int)c.Y.Value - 1, (int)CoordinateSystem.YLength),
            (int)c.Y.Value,
            CoordinateSystem.AutoCorrectCoordinate((int)c.Y.Value + 1, (int)CoordinateSystem.YLength)
         };

         var coordinates = xcoordinates.SelectMany(x => ycoordinates.Select(y =>
            new ClosedCoordinates(XCoordinate.Create((uint)x), YCoordinate.Create((uint)y))
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
         List<KeyValuePair<ClosedCoordinates, Square>> filtered = new List<KeyValuePair<ClosedCoordinates, Square>>();
         for (int i = 0; i < x; i++)
         {
            var selected = coordinates.Where((c, iterator) => iterator % x == i).ToArray();
            filtered.AddRange(selected);
         }
         return filtered.ToArray();
      }
      private string PrintRow(KeyValuePair<ClosedCoordinates, Square>[] row)
      {
         string output = string.Empty;
         foreach (var (_, square) in row)
         {
            output += $"|x:{square.Coordinates.X.Value},y:{square.Coordinates.Y.Value}|";
         }

         output += "\n";
         return output;
      }
   }
}
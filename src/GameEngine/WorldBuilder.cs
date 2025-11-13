using GameEngine.Models;
using System.Linq;

namespace GameEngine
{
   public class WorldBuilder
   {
      private World _world;
      public World Build(uint x, uint y)
      {
         var closedCartesianCoordinateSystem = new ClosedCartesianCoordinateSystem(x, y);
         _world = new World(closedCartesianCoordinateSystem);

         var xaxis = Enumerable.Range(0, (int)x);
         var yaxis = Enumerable.Range(0, (int)y);

         var coordinates = xaxis.SelectMany(x => yaxis.Select(y => new ClosedCoordinates(XCoordinate.Create((uint)x), YCoordinate.Create((uint)y)))).ToArray();

         _world.Squares = coordinates.ToDictionary(coordinate => coordinate, coordinate => new SquareBuilder().Build(coordinate));

         return _world;
      }
   }
}

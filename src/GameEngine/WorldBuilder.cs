using GameEngine.Models;
using System.Linq;

namespace GameEngine
{
   public class WorldBuilder
   {
      private World _world;
      public World Build()
      {
         uint xaxisCount = 8;
         uint yaxisCount = 8;
         var closedCartesianCoordinateSystem = new ClosedCartesianCoordinateSystem(xaxisCount,yaxisCount);
         _world = new World(closedCartesianCoordinateSystem);

         var xaxis = Enumerable.Range(0, (int)xaxisCount);
         var yaxis = Enumerable.Range(0, (int)yaxisCount);

         var coordinates = xaxis.SelectMany(x => yaxis.Select(y => new ClosedCoordinates(XCoordinate.Create( (uint)x),YCoordinate.Create( (uint)y))));

         _world.Squares = coordinates.ToDictionary(coordinate => coordinate, coordinate => new SquareBuilder().Build(coordinate));

         return _world;
      }
   }
}

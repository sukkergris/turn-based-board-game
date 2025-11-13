using GameEngine.Models;

namespace GameEngine
{
   public class ClosedCoordinates
    {
      public ClosedCoordinates(XCoordinate x,YCoordinate y)
      {
         X = x;
         Y = y;
      }

      public XCoordinate X { get; }
      public YCoordinate Y { get; }
   }
}

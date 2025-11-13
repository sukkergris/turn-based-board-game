namespace GameEngine
{
   public class Square
   {
      public Square(ClosedCoordinates coordinates)
      {
         Coordinates = coordinates;
      }

      public ClosedCoordinates Coordinates { get; }
   }
}

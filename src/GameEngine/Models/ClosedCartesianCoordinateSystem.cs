namespace GameEngine.Models
{
   public class ClosedCartesianCoordinateSystem
   {
      public readonly uint XLength;
      public readonly uint YLength;
      public ClosedCartesianCoordinateSystem(uint xLength, uint yLenght)
      {
         XLength = xLength;
         YLength = yLenght;
      }

      public int AutoCorrectCoordinate(int proposedCoordinate, int length) => proposedCoordinate switch
      {
         < 0 => length - 1,
         int i when i > (length - 1) => 0,
         _ => proposedCoordinate
      };
   }
}
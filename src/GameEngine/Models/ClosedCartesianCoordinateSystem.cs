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

      public int AutoCorrectXCoordinate(int proposedCoordinate) => AutoCorrectCoordinate(proposedCoordinate, (int)XLength);
      public int AutoCorrectYCoordinate(int proposedCoordinate) => AutoCorrectCoordinate(proposedCoordinate, (int)YLength);
      int AutoCorrectCoordinate(int proposedCoordinate, int length) => proposedCoordinate switch
      {
         < 0 => (length + proposedCoordinate % length) == 3 ? 0 : (length + proposedCoordinate % length),
         int i when i > (length - 1) => proposedCoordinate % length,
         _ => proposedCoordinate
      };
   }
}
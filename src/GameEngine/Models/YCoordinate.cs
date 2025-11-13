using Functional.Makeup;
using System;

namespace GameEngine.Models
{
   public class YCoordinate : ValueObject<YCoordinate>
   {
      public readonly uint Value;
      private YCoordinate(uint y)
      {
         Value = y;
      }
      public static YCoordinate Create(uint y) => new YCoordinate(y);
      public static Result<YCoordinate> Create(int y, ClosedCartesianCoordinateSystem system)
      {
         return y switch
         {

         };
      }
      protected override bool EqualsCore(YCoordinate other)
      {
         throw new NotImplementedException();
      }

      protected override int GetHashCodeCore()
      {
         throw new NotImplementedException();
      }
   }
}

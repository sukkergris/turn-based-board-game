using Functional.Makeup;
using System;

namespace GameEngine.Models
{
   public record YCoordinate(uint Value)
   {
      public static YCoordinate Create(uint y) => new YCoordinate(y);
      public static Result<YCoordinate> Create(int y, ClosedCartesianCoordinateSystem system)
      {
         return y switch
         {

         };
      }
   }
}

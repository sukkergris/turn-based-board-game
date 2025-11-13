using Functional.Makeup;

namespace GameEngine.Models
{
   public class XCoordinate : ValueObject<XCoordinate>
   {
      public readonly uint Value;
      private XCoordinate(uint x)
      {
         Value = x;
      }
      public static XCoordinate Create(uint x) => new XCoordinate(x);
      public static Result<XCoordinate> Create(int x)
      {
         return Result.Ok(new XCoordinate((uint)System.Math.Abs(x)));
      }

      protected override bool EqualsCore(XCoordinate other) => other.Value == Value;

      protected override int GetHashCodeCore() => Value.GetHashCode();
   }
}

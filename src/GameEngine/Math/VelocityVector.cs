using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Math
{
    public class VelocityVector
    {
      public readonly Coordinate Start;
      public readonly Coordinate End;
      public VelocityVector(Coordinate start, Coordinate end)
      {
         Start = start;
         End = end;
      }
   }
}

using GameEngine.Models;
using Xunit;

namespace GameEngine.test
{
   public class UnitTest1
   {
      [Fact]
      public void Test1()
      {
         var sut = new WorldBuilder().Build(3, 3);
         var shouldBeZero = sut.CoordinateSystem.AutoCorrectCoordinate(0, (int)sut.XAxisCount);
         Assert.Equal(0, shouldBeZero);
         var shouldBeZero2 = sut.CoordinateSystem.AutoCorrectCoordinate(8, (int)sut.YAxisCount);
         Assert.Equal(0, shouldBeZero2);
         var shouldBeOne = sut.CoordinateSystem.AutoCorrectCoordinate(1, (int)sut.XAxisCount);
         Assert.Equal(1, shouldBeOne);
         var shouldBeSeven = sut.CoordinateSystem.AutoCorrectCoordinate(-1, (int)sut.YAxisCount);
         Assert.Equal(7, shouldBeSeven);
      }
      [Fact]
      public void Test2()
      {
         var sut = new WorldBuilder().Build(3, 3);
         var coordinates = new ClosedCoordinates(XCoordinate.Create(7U), YCoordinate.Create(7U));
         var result = sut.GetSurroundingCoordinates(coordinates);
      }

      [Fact]
      public void GameOn()
      {
         var world = new WorldBuilder().Build(3, 3);
         var sut = new Engine(world);
         sut.Initialize();
         sut.Play();
      }
   }
}

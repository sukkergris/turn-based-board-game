using GameEngine.Models;
using Xunit;

namespace GameEngine.test
{
   public class UnitTest1
   {
      [Fact]
      public void Test1()
      {
         var sut = new WorldBuilder().Build();
         var shouldBeZero = sut.AutoCorrectCoordinate(0, sut.xaxiscount);
         Assert.Equal(0, shouldBeZero);
         var shouldBeZero2 = sut.AutoCorrectCoordinate(8, sut.yaxiscount);
         Assert.Equal(0, shouldBeZero2);
         var shouldBeOne = sut.AutoCorrectCoordinate(1, sut.xaxiscount);
         Assert.Equal(1, shouldBeOne);
         var shouldBeSeven = sut.AutoCorrectCoordinate(-1, sut.yaxiscount);
         Assert.Equal(7, shouldBeSeven);
      }
      [Fact]
      public void Test2()
      {
         var sut = new WorldBuilder().Build();
         var coordinates = new ClosedCoordinates(XCoordinate.Create(7U), YCoordinate.Create(7U));
         var result = sut.GetSurroundingCoordinates(coordinates);
      }

      [Fact]
      public void GameOn()
      {
         var world = new WorldBuilder().Build();
         var sut = new Engine(world);
         sut.Initialize();
         sut.Play();
      }
   }
}

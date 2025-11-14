using GameEngine.Models;
namespace GameEngine;

public static class PlayerBuilder
{
    public static Player Hans(World world) => new Player(world,
         new ClosedCoordinates(
            XCoordinate.Create(0U),
            YCoordinate.Create(0U)),
             new Math.Vector(
               new ClosedCoordinates(
                  XCoordinate.Create(1U),
                  YCoordinate.Create(1U)),
         new ClosedCoordinates(
            XCoordinate.Create(1U),
            YCoordinate.Create(2U))),
         "Hans");
    public static Player Peter(World world) => new Player(world,
            new ClosedCoordinates(
               XCoordinate.Create(3U),
               YCoordinate.Create(3U)),
               new Math.Vector(
                  new ClosedCoordinates(
                     XCoordinate.Create(3U),
                     YCoordinate.Create(9U)),
                     new ClosedCoordinates(
                        XCoordinate.Create(6U),
                        YCoordinate.Create(1U))),
         "Peter");
}
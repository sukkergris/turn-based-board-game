using GameEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameEngine
{
   public class Engine
   {
      public Engine(World world)
      {
         World = world;
      }
      public List<Player> Players { get; private set; } = new List<Player>();
      public World World { get; }

      //public Player NewPlayer() => new Player(World);
      public void AddPlayer(Player player)
      {
         var predicate = new Predicate<Player>(player.Equals);
         var existing = Players.Exists(predicate);
         if (existing) return;
         Players.Add(player);
      }
      public void Initialize()
      {
         // Setup world
         // Add players
         AddPlayer(new Player(World,
         new ClosedCoordinates(
            XCoordinate.Create(1U),
            YCoordinate.Create(1U)),
             new Math.Vector(
               new ClosedCoordinates(
                  XCoordinate.Create(1U),
                  YCoordinate.Create(1U)),
         new ClosedCoordinates(
            XCoordinate.Create(1U),
            YCoordinate.Create(2U))),
         "Hans"));
         // AddPlayer(new Player(World,
         //    new ClosedCoordinates(
         //       XCoordinate.Create(3U),
         //       YCoordinate.Create(3U)),
         //       new Math.Vector(
         //          new ClosedCoordinates(
         //             XCoordinate.Create(3U),
         //             YCoordinate.Create(9U)),
         //             new ClosedCoordinates(
         //                XCoordinate.Create(6U),
         //                YCoordinate.Create(1U))),
         // "Peter"));

         // Game loop
         int max = 1_000;
         int loopCount = max;
         while (loopCount > 0)
         {
            foreach (var square in World.Squares)
            {
               square.Value.ActionInfo = "               ";
            }

            var actionId = Guid.NewGuid();
            foreach (var player in Players)
            {
               var action = new ActAction(World, actionId);
               player.Move(action);
               player.Act(action);
            }

            // Clear and redraw
            Console.Clear();
            foreach (var player in Players)
            {
               Console.WriteLine($"Player: {player.Name}, X: {player.Coordinates.X.Value}, Y: {player.Coordinates.Y.Value}");
            }
            var rendered = Render(World);
            Console.WriteLine(rendered);
            Console.WriteLine($"Generation: {max - loopCount}");

            // Add a small delay to see the animation
            System.Threading.Thread.Sleep(250);

            loopCount--;
         }
         var dimmer = Players.First().Moves.GroupBy(x => x).Select(gr => new
         {
            Count = gr.Count(),
            Cord = gr.First(),
         }).OrderBy(m => m.Cord.X.Value).ThenBy(m => m.Cord.Y.Value).ToList();

         foreach (var item in dimmer)
         {
            Console.WriteLine($"Count: {item.Count} X: {item.Cord.X.Value}, Y: {item.Cord.Y.Value}");
         }
      }
      public string Render(World world)
      {
         return world.Display();
      }
   }
}

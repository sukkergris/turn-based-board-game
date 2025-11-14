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
         AddPlayer(PlayerBuilder.Hans(World));
         // AddPlayer();

         // Game loop
         int runningCycles = 1_000;
         int loopCount = runningCycles;
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
            if (false)
            {
               // Clear and redraw
               Console.Clear();
               foreach (var player in Players)
               {
                  Console.WriteLine($"Player: {player.Name}, X: {player.Coordinates.X.Value}, Y: {player.Coordinates.Y.Value}");
               }
               var rendered = Render(World);
               Console.WriteLine(rendered);
               Console.WriteLine($"Generation: {(runningCycles - loopCount):N0}");
            }
            else
            {
               Console.Clear();
               Console.WriteLine($"Generation: {((runningCycles - loopCount) + 1):N0}");
            }
            // Add a small delay to see the animation
            // System.Threading.Thread.Sleep(250);

            loopCount--;
         }
         var statistics = Players.First().Moves.GroupBy(x => x).Select(gr => new
         {
            Count = gr.Count(),
            Cord = gr.First(),
         }).OrderBy(x => x.Cord.X.Value).ThenBy(y => y.Cord.Y.Value);

         foreach (var item in statistics)
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

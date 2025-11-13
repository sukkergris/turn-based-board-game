using GameEngine.Models;
using System;
using System.Collections.Generic;

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
         AddPlayer(new Player(World, new ClosedCoordinates(XCoordinate.Create(1U), YCoordinate.Create(1U)), new Math.Vector(new ClosedCoordinates(XCoordinate.Create(3U), YCoordinate.Create(9U)), new ClosedCoordinates(XCoordinate.Create(6U), YCoordinate.Create(2U)))));
         AddPlayer(new Player(World, new ClosedCoordinates(XCoordinate.Create(0U), YCoordinate.Create(0U)), new Math.Vector(new ClosedCoordinates(XCoordinate.Create(3U), YCoordinate.Create(9U)), new ClosedCoordinates(XCoordinate.Create(6U), YCoordinate.Create(1U)))));

         // Game loop
         int loopCount = 100;
         while (loopCount > 0)
         {
            var moveId = Guid.NewGuid();
            foreach (var player in Players)
            {
               player.Move(moveId);
               player.Act(new ActAction(World));
            }
            Render(World);
            loopCount--;
         }
      }
      public string Render(World world)
      {
         return world.Display();
      }
      public void Play() { }
   }
}

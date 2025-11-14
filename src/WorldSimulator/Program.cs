using GameEngine;
using GameEngine.Utility;

var world = new WorldBuilder().Build(9, 9);
var sut = new Engine(world, new Printer());
sut.Initialize();

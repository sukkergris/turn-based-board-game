using GameEngine;
using GameEngine.Utility;

var world = new WorldBuilder().Build(7, 7);
var sut = new Engine(
    world,
    new Printer(),
    new EngineConfiguration(new WorldConfiguration()));

sut.Initialize();

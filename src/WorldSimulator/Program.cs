using System;
using GameEngine;

var world = new WorldBuilder().Build(4, 4);
var sut = new Engine(world);
sut.Initialize();
var rendered = sut.Render(world);

Console.WriteLine(rendered);

// Console.ReadKey();
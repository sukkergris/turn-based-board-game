using GameEngine;
using System.Linq;
using System.Collections.Generic;

var world = new WorldBuilder().Build(9, 9);
var sut = new Engine(world);
sut.Initialize();
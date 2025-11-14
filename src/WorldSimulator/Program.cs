using GameEngine;

var world = new WorldBuilder().Build(3, 3);
// var sut = new Engine(world);
// sut.Initialize();

var items = Enumerable.Range(-12, 25).
    Select(i => new
    {
        iter = i,
        to = world.CoordinateSystem.AutoCorrectXCoordinate(i)
    }).
    ToArray();

foreach (var item in items)
{
    System.Console.WriteLine($"{item.iter} : {item.to}");
}



using System.Collections.Generic;
using System.Linq;
using System;

var x = 4;
var y = 4;
var arr = Enumerable.Range(1, 1);

Console.WriteLine("Base array: " + string.Join(", ", arr));

for (int i = 0; i < x; i++)
{
    var selected = arr.Where((a, iterator) => iterator % x == i);
    Console.WriteLine("S " + string.Join(", ", selected));
}
var random = new Random();
var sum = Enumerable.Range(1, 1_000_000).Select(_ => random.Next(2) == 0 ? -1 : 1).Sum();

Console.WriteLine($"{sum}");

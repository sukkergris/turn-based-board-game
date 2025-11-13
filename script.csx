using System.Collections.Generic;
using System.Linq;
using System;

var x = 4;
var y = 4;
var arr = Enumerable.Range(1, x * y);

Console.WriteLine("Base array: " + string.Join(", ", arr));

for (int i = 0; i < x; i++)
{
    var selected = arr.Where((a, iterator) => iterator % x == i);
    Console.WriteLine("S " + string.Join(", ", selected));
}
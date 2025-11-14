using System.Collections.Generic;
using System.Linq;
using GameEngine.Models;

namespace GameEngine;

public class World(ClosedCartesianCoordinateSystem coordinateSystem)
{
    public readonly ClosedCartesianCoordinateSystem CoordinateSystem = coordinateSystem;

    public Dictionary<ClosedCoordinates, Square> Squares { get; set; } =
        new Dictionary<ClosedCoordinates, Square>();

    public ClosedCoordinates[] GetSurroundingCoordinates(ClosedCoordinates c)
    {
        var surroundingCoords = new List<ClosedCoordinates>();
        var centerX = (int)c.X.Value;
        var centerY = (int)c.Y.Value;

        // Generate all 8 surrounding coordinates (3x3 grid minus center)
        for (int deltaX = -1; deltaX <= 1; deltaX++)
        {
            for (int deltaY = -1; deltaY <= 1; deltaY++)
            {
                // Skip the center coordinate
                if (deltaX == 0 && deltaY == 0)
                    continue;

                var newX = CoordinateSystem.AutoCorrectXCoordinate(centerX + deltaX);
                var newY = CoordinateSystem.AutoCorrectYCoordinate(centerY + deltaY);

                surroundingCoords.Add(ClosedCoordinates.Create((uint)newX, (uint)newY));
            }
        }

        return surroundingCoords.ToArray();
    }

    public string Display() => Display(Array.Empty<ClosedCoordinates>());

    public string Display(ClosedCoordinates[] squares)
    {
        string output = "Board:\n\n";

        foreach (var plot in squares)
        {
            var square = Squares.First(s => s.Key == plot);

            square.Value.ActionInfo = "X-Mark the spot";
        }

        foreach (
            KeyValuePair<ClosedCoordinates, Square>[] row in FilterForCartesianDisplay(
                    Squares,
                    CoordinateSystem
                )
                .Chunk((int)CoordinateSystem.XLength)
        )
        {
            output += PrintRow(row.ToArray());
        }
        return output;
    }

    public KeyValuePair<ClosedCoordinates, Square>[] FilterForCartesianDisplay(
        Dictionary<ClosedCoordinates, Square> coordinates,
        ClosedCartesianCoordinateSystem coordinateSystem
    )
    {
        var x = coordinateSystem.XLength;
        List<KeyValuePair<ClosedCoordinates, Square>[]> filtered =
            new List<KeyValuePair<ClosedCoordinates, Square>[]>();
        for (int i = 0; i < x; i++)
        {
            var selected = coordinates.Where((c, iterator) => iterator % x == i).ToArray();
            filtered.Add(selected);
        }
        filtered.Reverse();
        return filtered.SelectMany(c => c).ToArray();
    }

    private string PrintRow(KeyValuePair<ClosedCoordinates, Square>[] row)
    {
        string output = string.Empty;
        foreach (var (_, square) in row)
        {
            output +=
                $"|x:{square.Coordinates.X.Value},y:{square.Coordinates.Y.Value}| {square.ActionInfo} | ";
        }

        output += "\n";
        return output;
    }

    public ClosedCoordinates CreateFrom(int x, int y)
    {
        var correctedX = (uint)CoordinateSystem.AutoCorrectXCoordinate(x);
        var correctedY = (uint)CoordinateSystem.AutoCorrectYCoordinate(y);
        return ClosedCoordinates.Create(correctedX, correctedY);
    }
}

using Xunit;

namespace GameEngine.test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var sut = new WorldBuilder().Build(3, 3);
        var shouldBeZero = sut.CoordinateSystem.AutoCorrectXCoordinate(0);
        Assert.Equal(0, shouldBeZero);
        var shouldBe2 = sut.CoordinateSystem.AutoCorrectYCoordinate(8);
        Assert.Equal(2, shouldBe2);
        var shouldBeOne = sut.CoordinateSystem.AutoCorrectXCoordinate(1);
        Assert.Equal(1, shouldBeOne);
        var shouldBeTwo = sut.CoordinateSystem.AutoCorrectYCoordinate(-1);
        Assert.Equal(2, shouldBeTwo);
    }

    [Fact]
    public void AutoCorrectCoordinate_RangeTest()
    {
        var world = new WorldBuilder().Build(3, 3);

        // Test a range of coordinates to ensure wrapping works correctly
        var testResults = Enumerable
            .Range(-12, 25)
            .Select(i => new
            {
                Input = i,
                Output = world.CoordinateSystem.AutoCorrectXCoordinate(i),
            })
            .ToArray();

        // Verify all outputs are within valid range [0, 2]
        Assert.All(testResults, result => Assert.InRange(result.Output, 0, 2));

        // Test specific cases
        Assert.Equal(0, world.CoordinateSystem.AutoCorrectXCoordinate(0)); // 0 -> 0
        Assert.Equal(1, world.CoordinateSystem.AutoCorrectXCoordinate(1)); // 1 -> 1
        Assert.Equal(2, world.CoordinateSystem.AutoCorrectXCoordinate(2)); // 2 -> 2
        Assert.Equal(0, world.CoordinateSystem.AutoCorrectXCoordinate(3)); // 3 -> 0
        Assert.Equal(2, world.CoordinateSystem.AutoCorrectXCoordinate(-1)); // -1 -> 2
        Assert.Equal(1, world.CoordinateSystem.AutoCorrectXCoordinate(-2)); // -2 -> 1
    }

    [Fact]
    public void Test2()
    {
        var sut = new WorldBuilder().Build(3, 3);
        var coordinates = sut.CreateFrom((int)7U, (int)7U);
        var result = sut.GetSurroundingCoordinates(coordinates);

        // Should return 8 surrounding coordinates
        Assert.Equal(8, result.Length);

        // Verify all surrounding coordinates are within the valid range
        Assert.All(
            result,
            coord =>
            {
                Assert.InRange(coord.X.Value, 0u, 2u);
                Assert.InRange(coord.Y.Value, 0u, 2u);
            }
        );

        // For coordinate (7,7) in a 3x3 grid, it wraps to (1,1)
        // So surrounding coordinates should include (0,0), (0,1), (0,2), (1,0), (1,2), (2,0), (2,1), (2,2)
        Assert.Contains(result, coord => coord.X.Value == 0 && coord.Y.Value == 0);
        Assert.Contains(result, coord => coord.X.Value == 0 && coord.Y.Value == 1);
        Assert.Contains(result, coord => coord.X.Value == 0 && coord.Y.Value == 2);
        Assert.Contains(result, coord => coord.X.Value == 1 && coord.Y.Value == 0);
        Assert.Contains(result, coord => coord.X.Value == 1 && coord.Y.Value == 2);
        Assert.Contains(result, coord => coord.X.Value == 2 && coord.Y.Value == 0);
        Assert.Contains(result, coord => coord.X.Value == 2 && coord.Y.Value == 1);
        Assert.Contains(result, coord => coord.X.Value == 2 && coord.Y.Value == 2);
    }

    [Fact]
    public void GameOn()
    {
        var world = new WorldBuilder().Build(3, 3);
        var sut = new Engine(world, new Printer());
        sut.Initialize();
        var rendered = sut.Render(world);

        // Verify the engine was created successfully
        Assert.NotNull(sut);
        Assert.NotNull(sut.World);
        Assert.Equal(world, sut.World);

        // Verify players were added during initialization
        Assert.NotEmpty(sut.Players);

        // Verify rendering produces output
        Assert.NotNull(rendered);
        Assert.NotEmpty(rendered);

        // Verify the world has the correct dimensions
        Assert.Equal(3u, world.CoordinateSystem.XLength);
        Assert.Equal(3u, world.CoordinateSystem.YLength);
    }
}

using GameEngine.Utility;

namespace GameEngine;

public class Engine
{
    private readonly IPrint printer;
    private readonly EngineConfiguration config;

    public Engine(World world, IPrint printer, EngineConfiguration config)
    {
        World = world;
        this.printer = printer;
        this.config = config;
    }

    public List<Player> Players { get; private set; } = new List<Player>();
    public World World { get; }

    //public Player NewPlayer() => new Player(World);
    public void AddPlayer(Player player)
    {
        var predicate = new Predicate<Player>(player.Equals);
        var existing = Players.Exists(predicate);
        if (existing)
            return;
        Players.Add(player);
    }

    public void Initialize()
    {
        // Setup world
        // Add players
        AddPlayer(PlayerBuilder.Hans(World));
        AddPlayer(PlayerBuilder.Peter(World));
        // AddPlayer();

        // Game loop
        bool noPrint = false;
        int runningCycles = 1000;
        int loopCount = runningCycles;
        while (loopCount > 0)
        {
            foreach (var square in World.Squares)
            {
                square.Value.ActionInfo = "               ";
            }

            var actionId = Guid.NewGuid();
            foreach (var player in Players)
            {
                var action = new ActAction(World, actionId);
                player.Move(action);
                player.Act(action);
            }
            if (!noPrint)
            {
                // Clear and redraw
                Console.Clear();
                foreach (var player in Players)
                {
                    $"Player: {player.Name}, X: {player.Coordinates.X.Value}, Y: {player.Coordinates.Y.Value}".Print(
                        printer
                    );
                    // var coord = player.Coordinates;
                    // var surroundingCoords = World
                    //     .GetSurroundingCoordinates(coord)
                    //     .ToArray();
                    // World.Display(surroundingCoords);
                }

                var rendered = Render(World);
                rendered.Print(printer);
                $"Generation: {runningCycles - loopCount + 1:N0}".Print(
                    printer
                );
            }
            else
            {
                printer.Clear();
                $"Generation: {runningCycles - loopCount + 1:N0}".Print(
                    printer
                );
            }
            // Add a small delay to see the animation
            Thread.Sleep(250);

            loopCount--;
        }
        var statistics = Players
            .First()
            .Moves.GroupBy(x => x)
            .Select(gr => new { Count = gr.Count(), Cord = gr.First() })
            .OrderBy(x => x.Cord.X.Value)
            .ThenBy(y => y.Cord.Y.Value);

        foreach (var item in statistics)
        {
            $"Count: {item.Count} X: {item.Cord.X.Value}, Y: {item.Cord.Y.Value}".Print(printer);
        }
    }

    public string Render(World world)
    {
        return world.Display();
    }
}

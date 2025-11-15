namespace GameEngine.Config;

public record GameLoopConfiguration(
    int MaxCycles = 1000,
    int DelayBetweenCyclesMs = 250,
    bool EnableRendering = true,
    bool ClearConsoleEachCycle = true
);

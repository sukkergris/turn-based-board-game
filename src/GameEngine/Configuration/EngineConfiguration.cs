using GameEngine.Models;

namespace GameEngine;

public record EngineConfiguration(WorldConfiguration WorldConfiguration);

public record WorldConfiguration(
    uint Width = 3,
    uint Height = 3,
    bool Borderless = true
);

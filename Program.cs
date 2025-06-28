using System.Numerics;

namespace survival;

/// <summary>
/// Main class for game system operations.
/// Opens the main window and handles the game loop.
/// </summary>
public static class Game
{
    private static readonly Vector2 DefaultWindowSize = new(800, 600);

    public static void Main()
    {
        Window.Open(DefaultWindowSize, "Survival Prototype");

        while (!Window.ShouldClose)
        {
            // Game loop and rendering here.
        }

        Window.Close();
    }
}
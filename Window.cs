using System.Numerics;
using Raylib_cs;

namespace survival;

/// <summary>
/// Main class for window operations. <br/>
/// As this project does not require multiple windows,
/// this is a static class dedicated to handling the single game window.
/// </summary>
public static class Window
{
    /// <summary>
    /// Window Width.
    /// </summary>
    public static int Width { get; private set; }

    /// <summary>
    /// Window Height.
    /// </summary>
    public static int Height { get; private set; }

    /// <summary>
    /// Window Title.
    /// </summary>
    public static string Title { get; private set; } = "Game";

    /// <summary>
    /// Vector2 for the size of the window.
    /// Size = (Width, Height)
    /// </summary>
    public static Vector2 Size
    {
        get => new(Width, Height);

        private set
        {
            value = new((int)value.X, (int)value.Y);
            if (value.X > 0 && value.Y > 0)
            {
                Width = (int)value.X;
                Height = (int)value.Y;
            }
            else
            {
                throw new InvalidWindowException($"Invalid Window Size: {value}");
            }
        }
    }

    public static bool IsOpen { get; private set; } = false;

    /// <summary>
    /// Called to open a window and define it's parameters.
    /// </summary>
    /// <param name="size">Vector2 for the size of the window.</param>
    /// <param name="title">String for the title of the window.</param>
    /// <exception cref="InvalidWindowException">Thrown if there is an open window already.</exception>
    public static void Open(Vector2 size, string title)
    {
        if (IsOpen)
        {
            throw new InvalidWindowException($"Cannot open window on top of existing window instance");
        }

        Size = size;
        Title = title;
        Raylib.InitWindow(Width, Height, Title);
        IsOpen = true;
    }

    /// <summary>
    /// Checks if the window is required to be closed.
    /// </summary>
    public static bool ShouldClose() => Raylib.WindowShouldClose();

    /// <summary>
    /// Closes the current window.
    /// </summary>
    public static void Close()
    {
        Raylib.CloseWindow();
        IsOpen = false;
    }
}

[Serializable]
public class InvalidWindowException : Exception
{
    public InvalidWindowException() : base() { }
    public InvalidWindowException(string message) : base(message) { }
    public InvalidWindowException(string message, Exception inner) : base(message, inner) { }
}
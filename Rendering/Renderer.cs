using Raylib_cs;

namespace survival.Rendering;

public enum RenderLayer
{
    UI,
    World

}

public static class Renderer
{
    private static int _targetFPS = 60;
    public static readonly Color BackgroundColor = Color.Black;


    public static bool ShowFPS = true;

    public static List<RenderObject> Renderables = [];

    public static int TargetFPS
    {
        get => _targetFPS;
        set
        {
            _targetFPS = value;
            if (Window.IsOpen)
            {
                Raylib.SetTargetFPS(_targetFPS);
            }
        }
    }
    public static void Render()
    {
        ClearScreen();

        // Sort renderables by render order
        Renderables.Sort(RenderObject.CompareRenderOrder);

        Raylib.BeginDrawing();

        foreach (RenderObject renderable in Renderables)
        {
            renderable.Render();
        }

        if (ShowFPS)
        {
            Raylib.DrawFPS(0, 0);
        }

        Raylib.EndDrawing();

    }

    private static void ClearScreen() => Raylib.ClearBackground(BackgroundColor);
}
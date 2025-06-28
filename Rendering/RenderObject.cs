namespace survival.Rendering;

public class RenderObject
{
    private bool _active = true;

    /// <summary>
    /// Priority in layer for visibility, smaller numbers mean it will be drawn later. 
    /// </summary>
    public int priority = 0;

    public readonly RenderLayer layer;

    public bool Active
    {
        get => _active;
        set
        {
            if (value == _active) return;
            if (value)
            {
                Renderer.Renderables.Add(this);
            }
            else
            {
                Renderer.Renderables.Remove(this);
            }
        }
    }

    /// <summary>
    /// Function for drawing the object on screen.
    /// </summary>
    public delegate void RenderFunction();


    public RenderFunction Render { get; private init; }

    public RenderObject(RenderLayer layer, RenderFunction renderFunction)
    {
        Renderer.Renderables.Add(this);
        this.layer = layer;
        Render = renderFunction;
    }


    /// <summary>
    /// Compares two RenderObjects (a and b) to figure which should be rendered first.<br/>
    /// First, compares the objects' RenderLayers.<br/>
    /// If both objects have the same RenderLayer, then they are compared by their render priority property.
    /// </summary>
    /// <returns>
    /// An integer n, that follows these rules:
    /// <ul>
    ///     <li> n < 0 -> Object a should be rendered first; </li>
    ///     <li> n = 0 -> Objects a and b have the same render order; </li>
    ///     <li> n > 0 -> Object b should be rendered first. </li>
    /// </ul>
    /// </returns>
    public static int CompareRenderOrder(RenderObject a, RenderObject b)
    {
        if (a.layer != b.layer)
        {
            return b.layer - a.layer;
        }

        return b.priority - a.priority;
    }

}

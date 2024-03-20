public enum RenderOrder
{
    None = 0,
    Floor = 100,
    Wall = 200,
    Goal = 300,
    Player = 400,
    Monster = 500,
}

class SpriteRenderer : Renderer
{
    public SpriteRenderer()
    {
        renderOrder = RenderOrder.None;
    }

    public char shape;
    public RenderOrder renderOrder;

    public override void Render()
    {
        if (transform != null)
        {
            Console.SetCursorPosition(transform.x, transform.y);
            Console.Write(shape);
        }
    }
}


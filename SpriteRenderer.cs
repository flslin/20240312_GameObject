class SpriteRenderer : Renderer
{
    public SpriteRenderer()
    {

    }

    public char shape;

    public override void Render()
    {
        Console.SetCursorPosition(transform.x, transform.y);
        Console.Write(shape);

    }
}


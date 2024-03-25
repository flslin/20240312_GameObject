using SDL2;

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
        string dir = Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.FullName;

        IntPtr mySurface = SDL.SDL_LoadBMP(dir + "/data/" + "floor.bmp");
    }

    public char shape;
    public RenderOrder renderOrder;

    public override void Render()
    {
        //SDL.SDL_GetTicks(); // uint32는 2^32라 40분이 지나면 0으로 돌아옴
        SDL.SDL_GetTicks64(); // 그래서 long으로 사용

        if (transform != null)
        {
            //Console.SetCursorPosition(transform.x, transform.y);
            //Console.Write(shape);

            Engine myEngine = Engine.GetInstance();

            SDL.SDL_Rect myRect = new SDL.SDL_Rect();
            myRect.x = transform.x * 30;
            myRect.y = transform.y * 30;
            myRect.w = 30;
            myRect.h = 30;

            if (renderOrder == RenderOrder.Floor)
            {
                SDL.SDL_SetRenderDrawColor(myEngine.myRenderer, 0, 255, 0, 0);
            }

            else if (renderOrder == RenderOrder.Wall)
            {
                SDL.SDL_SetRenderDrawColor(myEngine.myRenderer, 255, 255, 0, 0);
            }

            else if (renderOrder == RenderOrder.Player)
            {
                SDL.SDL_SetRenderDrawColor(myEngine.myRenderer, 0, 0, 255, 0);
            }

            else if (renderOrder == RenderOrder.Monster)
            {
                SDL.SDL_SetRenderDrawColor(myEngine.myRenderer, 0, 255, 255, 0);
            }

            else if (renderOrder == RenderOrder.Goal)
            {
                SDL.SDL_SetRenderDrawColor(myEngine.myRenderer, 255, 0, 255, 0);
            }

            SDL.SDL_RenderFillRect(myEngine.myRenderer, ref myRect);
        }
    }
}


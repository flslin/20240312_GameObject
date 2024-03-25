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
    public string textureName;

    public SDL.SDL_Color colorKey;

    public bool isMultiple = false;

    public int spriteCount = 0;

    protected int currentIndex = 0;

    public ulong currentTime = 0;

    public ulong executeTime = 250;

    public SpriteRenderer()
    {
        renderOrder = RenderOrder.None;
        textureName = "";
        colorKey.r = 255;
        colorKey.g = 255;
        colorKey.b = 255;
        colorKey.a = 255;
    }
    public void Load(string _textureName)
    {
        textureName = _textureName;

        ResourceManager.Load(textureName, colorKey); // 2024.03.25 추가
    }

    public char shape;
    public RenderOrder renderOrder;

    public override void Update()
    {
        if (isMultiple)
        {
            currentTime += Engine.GetInstance().deltaTime;
            if (currentTime >= executeTime)
            {
                currentIndex++;
                currentIndex = currentIndex % spriteCount; // 5로나눈 나머지로 넣음
                currentTime = 0;
            }
        }
    }

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

            //if (renderOrder == RenderOrder.Floor)
            //{
            //    SDL.SDL_SetRenderDrawColor(myEngine.myRenderer, 0, 255, 0, 0);
            //}

            //else if (renderOrder == RenderOrder.Wall)
            //{
            //    SDL.SDL_SetRenderDrawColor(myEngine.myRenderer, 255, 255, 0, 0);
            //}

            //else if (renderOrder == RenderOrder.Player)
            //{
            //    SDL.SDL_SetRenderDrawColor(myEngine.myRenderer, 0, 0, 255, 0);
            //}

            //else if (renderOrder == RenderOrder.Monster)
            //{
            //    SDL.SDL_SetRenderDrawColor(myEngine.myRenderer, 0, 255, 255, 0);
            //}

            //else if (renderOrder == RenderOrder.Goal)
            //{
            //    SDL.SDL_SetRenderDrawColor(myEngine.myRenderer, 255, 0, 255, 0);
            //}

            //SDL.SDL_RenderFillRect(myEngine.myRenderer, ref myRect);

            //unsafe
            //{
            //SDL.SDL_Surface* surface = (SDL.SDL_Surface*)mySurface;

            SDL.SDL_Rect rect = new SDL.SDL_Rect();
            uint format = 0;
            int acess = 0;
            SDL.SDL_QueryTexture(ResourceManager.Find(textureName), out format, out acess, out rect.w, out rect.h);

            if (isMultiple)
            {
                // animation
                int spriteWidth = rect.w / spriteCount;
                int spriteHeight = rect.h / spriteCount;
                rect.x = spriteWidth * currentIndex;
                rect.y = 0;
                rect.w = spriteWidth;
                rect.h = spriteHeight;
            }

            else
            {
                rect.x = 0;
                rect.y = 0;
            }
            //rect.w = surface->w;
            //rect.h = surface->h;

            SDL.SDL_Rect destRect = new SDL.SDL_Rect();
            destRect = myRect;

            SDL.SDL_RenderCopy(myEngine.myRenderer, ResourceManager.Find(textureName), ref rect, ref destRect);
            //}

        }
    }
}


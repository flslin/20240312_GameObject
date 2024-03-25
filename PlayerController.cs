using SDL2;
class PlayerController : Component
{
    public SpriteRenderer spriteRenderer;
    public override void Start() // 자식이 재정의 할수도 있음을 표시
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public override void Update()
    {
        if (transform == null)
        {
            return;
        }

        int oldX = transform.x;
        int oldY = transform.y;
        if (Input.GetKey(SDL.SDL_Keycode.SDLK_w))
        {
            spriteRenderer.currentYIndex = 2;
            transform.Translate(0, -1);
        }
        if (Input.GetKey(SDL.SDL_Keycode.SDLK_a))
        {
            spriteRenderer.currentYIndex = 0;
            transform.Translate(-1, 0);
        }
        if (Input.GetKey(SDL.SDL_Keycode.SDLK_s))
        {
            spriteRenderer.currentYIndex = 3;
            transform.Translate(0, 1);
        }
        if (Input.GetKey(SDL.SDL_Keycode.SDLK_d))
        {
            spriteRenderer.currentYIndex = 1;
            transform.Translate(1, 0);
        }
        if (Input.GetKey(SDL.SDL_Keycode.SDLK_ESCAPE))
        {
            // singleton pattern : 오브젝트가 엔진꺼 써야할 필요가 있을 때 씀
            Engine.GetInstance().Stop();
        } // 2024.03.25 키 입력시스템 변경

        transform.x = Math.Clamp(transform.x, 0, 80);
        transform.y = Math.Clamp(transform.y, 0, 80);

        // find new x, new y 해당 게임오브젝트 탐색
        // 찾은 게임 오브젝트에서 Collider2D, 충돌 체크
        foreach(GameObject findGameObjcet in Engine.GetInstance().gameObjects)
        {
            if (findGameObjcet == gameObject)
            {
                continue;
            }

            Collider2D find = findGameObjcet.GetComponent<Collider2D>();
            if ( find != null)
            {
                if(find.Check(gameObject) && find.isTrigger == false)
                {
                    // 충돌
                    transform.x = oldX;
                    transform.y = oldY;
                    break;
                }

                if (find.Check(gameObject) && find.isTrigger == true)
                {
                    OnTrigger(findGameObjcet);
                }
            }
        }
    }

    public void OnTrigger(GameObject other)
    {
        if(other.name == "Monster")
        {
            Engine.GetInstance().Find("GameManager").GetComponent<GameManager>().isGameOver = true;
        }

        else if (other.name == "Goal")
        {
            Engine.GetInstance().Find("GameManager").GetComponent<GameManager>().isNextStage = true;
        }
    }
}
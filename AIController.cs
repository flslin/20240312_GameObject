class AIController : Component
{
    public AIController()
    {

    }

    public override void Update()
    {
        if (transform == null)
        {
            return;
        }

        Random random = new Random();
        int oldX = transform.x;
        int oldY = transform.y;

        int nextDirction = random.Next(0, 4);
        if (nextDirction == 0)
        {
            transform.Translate(0, -1);
        }
        if (nextDirction == 1)
        {
            transform.Translate(-1, 0);
        }
        if (nextDirction == 2)
        {
            transform.Translate(0, 1);
        }
        if (nextDirction == 3)
        {
            transform.Translate(1, 0);
        }

        transform.x = Math.Clamp(transform.x, 0, 80);
        transform.y = Math.Clamp(transform.y, 0, 80);

        // find new x, new y 해당 게임오브젝트 탐색
        // 찾은 게임 오브젝트에서 Collider2D, 충돌 체크
        foreach (GameObject findGameObjcet in Engine.GetInstance().gameObjects)
        {
            if (findGameObjcet == gameObject)
            {
                continue;
            }

            Collider2D find = findGameObjcet.GetComponent<Collider2D>();
            if (find != null)
            {
                if (find.Check(gameObject))
                {
                    // 충돌
                    transform.x = oldX;
                    transform.y = oldY;
                    break;
                }

                if (find.Check(gameObject) && find.isTrigger == true)
                {
                    transform.x = oldX;
                    transform.y = oldY;
                    break;
                }
            }
        }
    }
}



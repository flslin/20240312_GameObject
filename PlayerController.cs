
class PlayerController : Component
{
    public override void Start() // 자식이 재정의 할수도 있음을 표시
    {

    }

    public override void Update()
    {
        if (transform == null)
        {
            return;
        }

        int oldX = transform.x;
        int oldY = transform.y;
        if (Input.GetButton("Up"))
        {

            transform.Translate(0, -1);
        }
        if (Input.GetButton("Left"))
        {
            transform.Translate(-1, 0);
        }
        if (Input.GetButton("Down"))
        {
            transform.Translate(0, 1);
        }
        if (Input.GetButton("Right"))
        {
            transform.Translate(1, 0);
        }
        if (Input.GetButton("Quit"))
        {
            // singleton pattern : 오브젝트가 엔진꺼 써야할 필요가 있을 때 씀
            Engine.GetInstance().Stop();
        }

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
                if(find.Check(gameObject))
                {
                    // 충돌
                    transform.x = oldX;
                    transform.y = oldY;
                    break;
                }
            }
        }
    }
}
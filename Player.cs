class Player : GameObject
{
    public Player()
    {
        shape = 'P';
    }
    public Player(int newX, int newY) // 생성자 오버로드
    {
        shape = 'P';

        x = newX;
        y = newY;
    }

    GameObject gameObject;

    ~Player()
    {

    }

    public override void Start() // 자식이 재정의 할수도 있음을 표시
    {

    }

    public override void Update()
    {
        if (Input.GetButton("Up"))
        {
            y--;
        }
        if (Input.GetButton("Left"))
        {
            x--;
        }
        if (Input.GetButton("Down"))
        {
            y++;
        }
        if (Input.GetButton("Right"))
        {
            x++;
        }
        if (Input.GetButton("Quit"))
        {
            // singleton pattern : 오브젝트가 엔진꺼 써야할 필요가 있을 때 씀
            // engine.Stop();
        }

        x = Math.Clamp(x, 0, 80);
        y = Math.Clamp(y, 0, 80);
    }

    //public override void Render()
    //{
    //    base.Render();
    //}

}
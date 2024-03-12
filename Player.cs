class Player : GameObject
{
    public Player()
    {
        shape = 'P';
    }
    public Player(int newX, int newY) // 생성자 오버로드
    {
        shape = 'P';

        beforeX = x;
        beforeY = y;
        afterX = x + 1;
        afterY = y + 1;
        x = newX;
        y = newY;
    }

    private int beforeX;
    public int BeforeX
    {
        get
        {
            return beforeX;
        }
        set
        {
            beforeX = value;
        }
    }
    private int beforeY;
    public int BeforeY
    {
        get
        {
            return beforeY;
        }
        set
        {
            beforeY = value;
        }
    }

    private int afterX;
    public int AfterX
    {
        get
        {
            return afterX;
        }
        set
        {
            afterX = value;
        }
    }

    private int afterY;
    public int AfterY
    {
        get
        {
            return afterY;
        }
        set
        {
            afterY = value;
        }
    }

    GameObject gameObject = new GameObject();
    Wall wall = new Wall();

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
            afterY--;
        }
        if (Input.GetButton("Left"))
        {
            afterX--;
        }
        if (Input.GetButton("Down"))
        {
            afterY++;
        }
        if (Input.GetButton("Right"))
        {
            afterX++;
        }
        if (Input.GetButton("Quit"))
        {
            // singleton pattern : 오브젝트가 엔진꺼 써야할 필요가 있을 때 씀
            // engine.Stop();
        }

        if (gameObject.GetType() is Wall != )
        {
            x = afterX;
            y = afterY;
        }

        x = Math.Clamp(x, 0, 80);
        y = Math.Clamp(y, 0, 80);
    }

    //public override void Render()
    //{
    //    base.Render();
    //}

}
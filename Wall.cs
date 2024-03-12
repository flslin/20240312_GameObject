
class Wall : GameObject
{
    //public Wall() // default 생성자. 생성자는 상속이 안됨
    //{
    //    shape = '*';
    //}

    public Wall(int newX = 0, int newY = 0) // 생성자 오버로드, = 0 -> default parameter
    {
        shape = '*';

        x = newX;
        y = newY;
    }

    ~Wall()
    {

    }

    public override void Start()
    {

    }

    public override void Update()
    {

    }

    public override void Render()
    {
        base.Render();
    }

}
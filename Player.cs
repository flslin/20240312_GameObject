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

    ~Player()
    {

    }

    public override void Start() // 자식이 재정의 할수도 있음을 표시
    {

    }

    public override void Update()
    {

    }

    //public override void Render()
    //{
    //    base.Render();
    //}

}
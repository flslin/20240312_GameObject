
class Goal : GameObject
{
    public Goal()
    {
        shape = 'G';
    }
    public Goal(int newX, int newY) // 생성자 오버로드
    {
        shape = 'G';

        x = newX;
        y = newY;
    }

    ~Goal()
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
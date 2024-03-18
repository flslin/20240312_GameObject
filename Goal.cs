
class Goal : GameObject
{
    public Goal()
    {
        shape = 'G';
        layerOrder = 100;
    }
    public Goal(int newX, int newY) // 생성자 오버로드
    {
        shape = 'G';

        x = newX;
        y = newY;
        layerOrder = 100;
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

class Monster : GameObject
{
    public Monster()
    {
        shape = 'M';
        layerOrder = 1000 + 1;
    }
    public Monster(int newX, int newY) // 생성자 오버로드
    {
        shape = 'M';

        x = newX;
        y = newY;

        layerOrder = 1000 + 1;
    }

    ~Monster()
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

class Monster : GameObject
{
    public Monster()
    {
        shape = 'M';
    }
    public Monster(int newX, int newY) // 생성자 오버로드
    {
        shape = 'M';

        x = newX;
        y = newY;
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
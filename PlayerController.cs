
class PlayerController : Component
{
    Engine engine;

    public override void Start() // 자식이 재정의 할수도 있음을 표시
    {

    }

    public override void Update()
    {
        if (Input.GetButton("Up"))
        {
            transform.y--;
        }
        if (Input.GetButton("Left"))
        {
            transform.x--;
        }
        if (Input.GetButton("Down"))
        {
            transform.y++;
        }
        if (Input.GetButton("Right"))
        {
            transform.x++;
        }
        if (Input.GetButton("Quit"))
        {
            // singleton pattern : 오브젝트가 엔진꺼 써야할 필요가 있을 때 씀
            engine.Stop();
        }

        transform.x = Math.Clamp(transform.x, 0, 80);
        transform.y = Math.Clamp(transform.y, 0, 80);
    }


}
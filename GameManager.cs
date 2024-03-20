class GameManager : Component
{
    public bool isGameOver = false;
    public bool isNextStage = false;
    public GameManager()
    {
        isGameOver = false;
        isNextStage = false;

    }

    public override void Update()
    {
        if (isGameOver)
        {
            Engine.GetInstance().Stop();
            Console.Clear();
            Console.WriteLine("Game Over");
        }

        if(isNextStage)
        {
            Console.Clear();
            Console.WriteLine("Congraturation");
            Console.ReadKey();

            Engine.GetInstance().NextLevel("level02.map");

            //Engine.GetInstance().Term(); // 오류남
            //Engine.GetInstance().LoadScene("level02.map);
        }
    }
}


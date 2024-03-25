class GameManager : Component
{
    public bool isGameOver = false;
    public bool isNextStage = false;

    protected Timer gameOverTimer;
    protected Timer gameCompliteTimer;

    public GameManager()
    {
        isGameOver = false;
        isNextStage = false;
        //gameOverTimer = new Timer(3000, ProcessGameOver);
        gameOverTimer = new Timer(3000, () => {
            ProcessGameOver();
        });

        gameCompliteTimer = new Timer(1000, ProcessGameComplite);

        //gameOverTimer.callback = () => { }; // 덮어씌워 다 지우기
    }

    public void ProcessGameOver()
    {
        Engine.GetInstance().Stop();
        Console.Clear();
        Console.WriteLine("Game Over");
    }

    public void ProcessGameComplite()
    {
        Console.Clear();
        Console.WriteLine("Congraturation");
        Console.ReadKey();

        Engine.GetInstance().NextLevel("level02.map");
    }

    public override void Update()
    {
        if (isGameOver)
        {
            gameOverTimer.Update();
        }

        if (isNextStage)
        {
            gameCompliteTimer.Update();
            //Engine.GetInstance().Term(); // 오류남
            //Engine.GetInstance().LoadScene("level02.map);
        }
    }
}


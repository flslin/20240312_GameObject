
class Engine
{
    public Engine()
    {
        gameObjects = new List<GameObject>();
        isRunning = true;
    }

    ~Engine()
    {

    }

    public List<GameObject> gameObjects;
    public bool isRunning;
    public ConsoleKeyInfo keyInfo;

    public Player player = new Player();

    public void Init()
    {
        Input.Init();
    }

    public void LoadScene(string SceneName)
    {
#if DEBUG
        string dir = System.IO.Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.FullName; // Environment.CurrentDirectory: 현재 디렉토리 .parent.parent == 메인디렉토리
        string[] map = File.ReadAllLines(dir + "./data/" + SceneName);
#else
        string dir = System.IO.Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.FullName;
        string[] map = File.ReadAllLines(dir + "./data/level01.map");
#endif

        //string[] map = new string[10];
        //// file로 읽어옴.
        //map[0] = "**********";
        //map[1] = "*P       *";
        //map[2] = "*        *";
        //map[3] = "*        *";
        //map[4] = "*    M   *";
        //map[5] = "*        *";
        //map[6] = "*        *";
        //map[7] = "*        *";
        //map[8] = "*       G*";
        //map[9] = "**********";

        for (int y = 0; y < 10/*map.Length*/; ++y)
        {
            for (int x = 0; x < 10/*map[y].Length*/; ++x)
            {
                if (map[y][x] == '*')
                {
                    Instantiate(new Wall(x, y));
                    //newGameObject.x = x; // 생성자 오버로드를 사용하면 필요없음
                    //newGameObject.y = y;
                }
                else if (map[y][x] == ' ')
                {
                    Instantiate(new Floor(x, y));
                }
                else if (map[y][x] == 'P')
                {
                    Instantiate(new Player(x, y));
                }
                else if (map[y][x] == 'G')
                {
                    Instantiate(new Goal(x, y));
                }
                else if (map[y][x] == 'M')
                {
                    Instantiate(new Monster(x, y));
                }
            }
        }
        //Load();

    }

    public void Run()
    {
        while (isRunning)
        {
            ProcessInput();
            Update();
            Render();
        } // 1frame
    }

    public void Term()
    {
        gameObjects.Clear();
    }

    //public GameObject Instanticate<T>() where T : GameObject // T에 들어갈수 있는 걸 정의
    //{
    //    return new T();
    //}

    public GameObject Instantiate(GameObject newgameObject)
    {
        gameObjects.Add(newgameObject);

        return newgameObject;
    }

    protected void ProcessInput()
    {
        Input.keyInfo = Console.ReadKey();
    }

    protected void Update()
    {
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.Update();
        }
    }

    protected void Render()
    {
        // 모든 게임 오브젝트 == 
        //for (int i = 0; i < gameObjects.Count; i++)
        //{
        //    gameObjects[i].Render();
        //}
        Console.Clear();
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.Render();
        }
    }
}
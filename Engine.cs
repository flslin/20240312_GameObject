
class Engine
{
    protected Engine()
    {
        gameObjects = new List<GameObject>();
        isRunning = true;
    }

    ~Engine()
    {

    }
    private static Engine? instance;

    public static Engine GetInstance()
    {
        if (instance == null)
        {
            instance = new Engine();
        }
        return instance;
        //return instance == null ? (instance = new Engine()) : instance; // null일 경우 new 아닐경우 instance 리턴;
        //return instance ?? (instance = new Engine()); // 을 줄인 코드
    }

    public List<GameObject> gameObjects;
    public bool isRunning;
    public ConsoleKeyInfo keyInfo;

    //public Player player = new Player();

    public void Init()
    {
        Input.Init();
    }

    public void Stop()
    {
        isRunning = false;
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
                    GameObject newGameObject = Instantiate(new GameObject());
                    newGameObject.name = "Wall";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    newGameObject.AddComponent<SpriteRenderer>();
                    newGameObject.GetComponent<SpriteRenderer>().shape = '*';

                    //Instantiate(new Wall(x, y));
                    //Instantiate(new Floor(x, y)); // 2024.03.18 변경

                    //newGameObject.x = x; // 생성자 오버로드를 사용하면 필요없음
                    //newGameObject.y = y;
                }
                else if (map[y][x] == ' ')
                {
                    GameObject newGameObject = Instantiate(new GameObject());
                    newGameObject.name = "Floor";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    newGameObject.AddComponent<SpriteRenderer>();
                    //newGameObject.GetComponent<SpriteRenderer>().shape = ' ';
                    //Instantiate(new Floor(x, y));
                }
                else if (map[y][x] == 'P')
                {
                    GameObject newGameObject = Instantiate(new GameObject());
                    newGameObject.name = "Player";
                    newGameObject.transform.x = 1;
                    newGameObject.transform.y = 1;
                    newGameObject.AddComponent<SpriteRenderer>();
                    newGameObject.GetComponent<SpriteRenderer>().shape = 'P';
                    newGameObject.AddComponent<PlayerController>();

                }
                else if (map[y][x] == 'G')
                {
                    GameObject newGameObject = Instantiate(new GameObject());
                    newGameObject.name = "Goal";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    newGameObject.AddComponent<SpriteRenderer>();
                    newGameObject.GetComponent<SpriteRenderer>().shape = 'G';

                    //Instantiate(new Goal(x, y));
                    //Instantiate(new Floor(x, y));

                }
                else if (map[y][x] == 'M')
                {
                    GameObject newGameObject = Instantiate(new GameObject());
                    newGameObject.name = "Monster";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    newGameObject.AddComponent<SpriteRenderer>();
                    newGameObject.GetComponent<SpriteRenderer>().shape = 'M';

                    //Instantiate(new Monster(x, y));
                    //Instantiate(new Floor(x, y));

                }
            }
        }

        //Load();
        //    gameObjects.Sort();

        //    int WCount = 0;
        //    foreach (GameObject obj in gameObjects)
        //    {
        //        // reflection 부모, 자식 클래스가 뭔지 모를 떄 실행 중 확인 가능
        //        if (obj.GetType() == typeof(Wall))
        //        {
        //            WCount++;
        //        }
        //        Console.WriteLine(WCount);
        //    }


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
            foreach (Component component in gameObject.components)
            {
                component.Update(); // 컴포넌트 중 어떤 업데이트가 먼저 실행되는지 알 수 없음
            }
        }

        //foreach (GameObject gameObject in gameObjects)
        //{
        //    gameObject.Update();
        //}
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
            Renderer? renderer = gameObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.Render();
            }
        }
    }
}

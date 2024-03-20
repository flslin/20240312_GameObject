
using System;

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

    public bool isNextLoading = false;
    public string nextSceneName = string.Empty;

    public void NextLevel(string _nextSceneName)
    {
        isNextLoading = true;
        nextSceneName = _nextSceneName;
    }

    public ConsoleKeyInfo keyInfo;
    public Renderer renderer;

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
                GameObject newGameObject;
                if (map[y][x] == '*')
                {
                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Wall";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.shape = '*';
                    renderer.renderOrder = RenderOrder.Wall;
                    newGameObject.AddComponent<Collider2D>();


                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Floor";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    newGameObject.AddComponent<SpriteRenderer>();
                    renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.renderOrder = RenderOrder.Floor;

                    //Instantiate(new Wall(x, y));
                    //Instantiate(new Floor(x, y)); // 2024.03.18 변경

                    //newGameObject.x = x; // 생성자 오버로드를 사용하면 필요없음
                    //newGameObject.y = y;
                }
                else if (map[y][x] == ' ')
                {
                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Floor";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    newGameObject.AddComponent<SpriteRenderer>();
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.renderOrder = RenderOrder.Floor;

                    //newGameObject.GetComponent<SpriteRenderer>().shape = ' ';
                    //Instantiate(new Floor(x, y));
                }
                else if (map[y][x] == 'P')
                {
                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Player";
                    newGameObject.transform.x = 1;
                    newGameObject.transform.y = 1;
                    newGameObject.AddComponent<SpriteRenderer>();
                    newGameObject.GetComponent<SpriteRenderer>().shape = 'P';
                    newGameObject.AddComponent<PlayerController>();
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.renderOrder = RenderOrder.Player;
                    newGameObject.AddComponent<Collider2D>();

                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Floor";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    newGameObject.AddComponent<SpriteRenderer>();
                    renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.renderOrder = RenderOrder.Floor;
                }
                else if (map[y][x] == 'G')
                {
                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Goal";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    newGameObject.AddComponent<SpriteRenderer>();
                    newGameObject.GetComponent<SpriteRenderer>().shape = 'G';
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.renderOrder = RenderOrder.Goal;
                    Collider2D collider2D = newGameObject.AddComponent<Collider2D>();
                    collider2D.isTrigger = true;

                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Floor";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    newGameObject.AddComponent<SpriteRenderer>();
                    renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.renderOrder = RenderOrder.Floor;

                }
                else if (map[y][x] == 'M')
                {
                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Monster";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    newGameObject.AddComponent<SpriteRenderer>();
                    newGameObject.GetComponent<SpriteRenderer>().shape = 'M';
                    SpriteRenderer renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.renderOrder = RenderOrder.Wall;
                    Collider2D collider2D = newGameObject.AddComponent<Collider2D>();
                    collider2D.isTrigger = true;
                    
                    newGameObject = Instantiate<GameObject>();
                    newGameObject.name = "Floor";
                    newGameObject.transform.x = x;
                    newGameObject.transform.y = y;
                    newGameObject.AddComponent<SpriteRenderer>();
                    renderer = newGameObject.AddComponent<SpriteRenderer>();
                    renderer.renderOrder = RenderOrder.Floor;

                }
            }
        }

        GameObject GameObject = Instantiate<GameObject>();
        GameObject.name = "GameManager";
        GameObject.AddComponent<GameManager>();

        RenderSort();
    }

    public void RenderSort()
    {
        //gameObjects

        for (int i = 0; i < gameObjects.Count; i++) // 선택 정렬
        {
            for (int j = i + 1; j < gameObjects.Count; j++)
            {
                SpriteRenderer? prevRender = gameObjects[i].GetComponent<SpriteRenderer>();
                SpriteRenderer? nextRender = gameObjects[j].GetComponent<SpriteRenderer>();

                if (prevRender != null && nextRender != null)
                {

                    if ((int)prevRender.renderOrder > (int)nextRender.renderOrder)
                    {
                        GameObject temp = gameObjects[i];
                        gameObjects[i] = gameObjects[j];
                        gameObjects[j] = temp;
                    }
                }
            }
        }


    }

    public void Run()
    {
        while (isRunning)
        {
            ProcessInput();
            Update();
            Render();
            if (isNextLoading)
            {
                gameObjects.Clear();
                LoadScene(nextSceneName);
                isNextLoading = false;
                nextSceneName = string.Empty;
            }
        } // 1frame
    }

    public void Term()
    {
        gameObjects.Clear();
    }

    public T Instantiate<T>() where T : GameObject, new() // T에 들어갈수 있는 걸 정의
    {
        T newObject = new T();
        gameObjects.Add(newObject);

        return newObject;
    }

    //public GameObject Instantiate(GameObject newgameObject)
    //{
    //    gameObjects.Add(newgameObject);

    //    return newgameObject;
    //}

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

    public GameObject Find(string name)
    {
        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject.name == name)
            {
                return gameObject;
            }
        }
        return null;
    }
}

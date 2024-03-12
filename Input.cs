class Input
{
    public Input()
    {

    }

    ~Input()
    {

    }

    public struct KeyList
    {
        public KeyList(ConsoleKey newButton, ConsoleKey newAltButton)
        {
            button = newButton;
            altButton = newAltButton;
        }
        public ConsoleKey button;
        public ConsoleKey altButton;
    }

    public static void Init()
    {
        // editor 설정
        InputMapping["Up"] = new KeyList(ConsoleKey.W, ConsoleKey.UpArrow);
        InputMapping["Down"] = new KeyList(ConsoleKey.S, ConsoleKey.DownArrow);
        InputMapping["Left"] = new KeyList(ConsoleKey.A, ConsoleKey.LeftArrow);
        InputMapping["Right"] = new KeyList(ConsoleKey.D, ConsoleKey.RightArrow);
        InputMapping["Quit"] = new KeyList(ConsoleKey.Escape, ConsoleKey.None);
        /*InputMapping["Up"][0] = ConsoleKey.W;
        InputMapping["Up"][1] = ConsoleKey.UpArrow;
        InputMapping["Down"][0] = ConsoleKey.S;
        InputMapping["Down"][1] = ConsoleKey.DownArrow;
        InputMapping["Left"][0] = ConsoleKey.A;
        InputMapping["Left"][1] = ConsoleKey.LeftArrow;
        InputMapping["Right"][0] = ConsoleKey.D;
        InputMapping["Right"][1] = ConsoleKey.RightArrow;*/
    }
    public static Dictionary<string, KeyList> InputMapping = new Dictionary<string, KeyList>();
    //public static Dictionary<string, ConsoleKey[]> InputMapping = new Dictionary<string, ConsoleKey[]>();

    public static ConsoleKeyInfo keyInfo;

    public static bool GetKey(ConsoleKey checkKeyCode)
    {
        return (keyInfo.Key == checkKeyCode);
    }

    public static bool GetButton(string buttonName)
    {
        /*bool a = (InputMapping[buttonName][0] == keyInfo.Key || InputMapping[buttonName][1] == keyInfo.Key);
        return a;*/
        return (InputMapping[buttonName].button == keyInfo.Key || InputMapping[buttonName].altButton == keyInfo.Key);
    }
}


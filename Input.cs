class Input
{
    public Input()
    {

    }

    ~Input()
    {

    }

    public static void Init()
    {
        // editor 설정
        InputMapping["Up"] = ConsoleKey.W;
        InputMapping["Down"] = ConsoleKey.S;
        InputMapping["Left"] = ConsoleKey.A;
        InputMapping["Right"] = ConsoleKey.D;
    }
    public static Dictionary<string, ConsoleKey> InputMapping = new Dictionary<string, ConsoleKey>();

    public static ConsoleKeyInfo keyInfo;

    public static bool GetKey(ConsoleKey checkKeyCode)
    {
        return (keyInfo.Key == checkKeyCode);
    }

    public static bool GetButton(string buttonName)
    {
        return (InputMapping[buttonName] == keyInfo.Key);
    }
}


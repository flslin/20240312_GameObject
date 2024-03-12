class Input
{
    public Input()
    {

    }

    ~Input()
    {

    }

    public static ConsoleKeyInfo keyInfo;

    public static bool GetKey(ConsoleKey checkKeyCode)
    {
        return (keyInfo.Key == checkKeyCode);
    }
}


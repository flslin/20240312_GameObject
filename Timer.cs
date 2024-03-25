class Timer
{
    public ulong executeTime = 0;
    protected ulong elapsedTime = 0;

    public delegate void Callback();
    public event Callback callback; // event추가하면 추가하거나 삭제만 가능하고 덮어씌우기 불가능

    public Timer(ulong _executeTime, Callback _callback)
    {
        SetTimer(_executeTime, _callback);
    }

    public void SetTimer(ulong _executeTime, Callback _callback)
    {
        executeTime = _executeTime;
        callback = _callback;
    }

    public void Update()
    {
        elapsedTime += Engine.GetInstance().deltaTime;
        if(elapsedTime >= executeTime)
        {
            // 함수를 등록해서 그 함수 자동으로 실행되게 함
            callback();
            elapsedTime = 0;

        }
    }
}


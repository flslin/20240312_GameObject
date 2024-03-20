class Component
{
    public Component()
    {
        //gameObject = null;
        //transform = null;
    }

    ~Component()
    {

    }

    public virtual void Start()
    {

    }

    public virtual void Update()
    {

    }

    public GameObject gameObject; // 내가 어디있는지 확인하는 용도
    public Transform transform; // 내가 속해 있는 게임오브젝트의 이동을 처리하는 용도
}
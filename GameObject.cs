
using static System.Runtime.InteropServices.JavaScript.JSType;

class GameObject
{
    public Transform transform;

    public List<Component> components;

    public string name;

    public int x;
    public int y;

    public GameObject()
    {
        name = "";
        transform = new Transform();
        components = new List<Component>();

        components.Add(transform);

        //x = 1;
        //y = 1;
        //layerOrder = 0;
    }

    public T? GetComponent<T>() where T : Component
    {
        int findIndex = -1;
        for (int i = 0; i < components.Count; i++)
        {
            if (components[i] is T)
            {
                findIndex = i;
                break;
            }
        }

        if (findIndex > 0)
        {
            return (T)components[findIndex];
        }
        else
        {
            return null;
        }

    }

    public T AddComponent<T>() where T : Component, new() // new가 없으면 생성되지않도록
    {
        T newT = new T();
        newT.gameObject = this;
        newT.transform = transform;
        components.Add(newT);

        return newT;
    }

    //public void RemoveComponent<T>() where T : Component
    //{
    //    if (findIndex > 0)
    //    {
    //        (T)components[findIndex];
    //    }

    //}

    //public GameObject(int newX, int newY)
    //{
    //    x = newX;
    //    y = newY;
    //    layerOrder = 0;
    //}

    //~GameObject()
    //{

    //}

    //public virtual void Start() // 자식이 재정의 할수도 있음을 표시
    //{

    //}

    //public virtual void Update()
    //{

    //}

    //public virtual void Render()
    //{
    //    Console.SetCursorPosition(x, y);
    //    Console.Write(shape);
    //}

    //public char shape;
    //protected int layerOrder;

    //public int CompareTo(GameObject? other)
    //{
    //    if (other == null)
    //    {
    //        return 1;
    //    }

    //    if (layerOrder > other.layerOrder)
    //    {
    //        return 1;
    //    }

    //    else if (layerOrder == other.layerOrder)
    //    {
    //        return 0;
    //    }

    //    else
    //    {
    //        return -1;
    //    }
    //}
}
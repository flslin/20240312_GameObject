
using System.Reflection;

class Program
{
    //class Parent
    //{
    //    public virtual void Pay()
    //    {
    //        Console.WriteLine("pay");
    //    }
    //}

    //class Child1 : Parent
    //{
    //    public override void Pay()
    //    {
    //        Console.WriteLine("pay");
    //    }
    //}

    //class Child2 : Parent
    //{
    //    public void Run()
    //    {
    //        Console.WriteLine("도망rk");
    //    }
    //}

    //class Singleton
    //{
    //    private Singleton()
    //    {

    //    }

    //    public static Singleton GetInstance()
    //    {
    //        if (instance == null)
    //        {
    //            instance = new Singleton();
    //        }
    //        return instance;
    //    }

    //    private static Singleton? instance;

    //    public void Draw()
    //    {

    //    }
    //}

    static void Main(string[] args)
    {
        //Singleton.GetInstance().Draw(); // 의존성이 좋지 않음
        Engine engine = Engine.GetInstance();

        engine.Init();
        engine.LoadScene("level01.map");
        engine.Run();
        engine.Term();

        //engine.Init();
        //engine.LoadScene("level01.map");
        //engine.Run();
        //engine.Term();

        //List<Parent> list = new List<Parent>();
        //list.Add(new Child1());
        //list.Add(new Parent());
        //list.Add(new Child2());

        //for (int i = 0; i < list.Count; i++)
        //{
        //list[i].Pay();
        // 리플렉션
        //if (list[i].GetType() == typeof(Child2))
        //{
        //    ((Child2)list[i]).Run();
        //}

        // 다운 캐스팅
        //Child2 child2 = list[i] as Child2;
        //if (child2 != null)
        //{
        //    child2.Run();
        //}
        //else
        //{
        //    Console.WriteLine("아님");
        //}
    }

        //GetConstructors()
        //GetFields()
        //GetInterfaces()
        //GetMembers()
        //GetMethods()
        //GetProperties()

        //int c = new int();
        //Type t = c.GetType(); // 타입알아보기

        //ConstructorInfo[] datas = t.GetConstructors();

        //foreach (ConstructorInfo d in datas)
        //{
        //    ParameterInfo[] ps = d.GetParameters();
        //    foreach (ParameterInfo p in ps)
        //    {
        //        Console.WriteLine(p.Name);
        //    }
        //}

        //Parent parent = new Child1();

        //Console.WriteLine(t.GetType());
        //if (parent is Parent) // 상속관계 물어보는 참이면 True
        //{
        //    Console.WriteLine("T");
        //}
        //else
        //{
        //    Console.WriteLine("F");
        //}


        //Data d1 = new Data(1, 2);
        //Data d2 = new Data(3, 4);
        //List<Data> datas = new List<Data>();

        //Random random = new Random();

        //for (int i = 0; i < 10; i++)
        //{
        //    datas.Add(new Data(random.Next(0,101), random.Next(0,101)));
        //}

        //datas.Sort();

        //for (int i = 0;i < 10; i++)
        //{
        //    Console.WriteLine(datas[i].a);
        //}
    //}

    class Data : IComparable<Data>
    {
        public Data(int _a, int _b)
        {
            a = _a; 
            b = _b;
        }
        public int a;
        public int b;

        public int CompareTo(Data? other)
        {
            if (other == null)
            {
                return -1;
            }

            if (b > other.b)
            {
                return -1;
            }

            else if (b == other.b)
            {
                return 0;
            }

            else
            {
                return 1;
            }
        }
    }
}
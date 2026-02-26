namespace LinqAndDelegate;

public class Program
{
    static void Main(string[] args)
    {


        //var hasht = new Dictionary<string, int>();
        //hasht.Add("apple", 1);
        //hasht.Add("ananas", 2);
        //hasht.Add("olma", 3);
        //hasht.Add("nok", 4);
        //hasht.Add("banan", 5);
        //foreach (var i in hasht)
        //{
        //    Console.WriteLine(i.Key);
        //}



        Predicate<int> predicate;
        predicate = Pred1;
        Console.WriteLine(predicate.Invoke(111));

        predicate += Pred2;
        Console.WriteLine(predicate.Invoke(111));

        predicate += Pred3;
        predicate += Pred4;

        Console.WriteLine(predicate.Invoke(111));
        ////-------------------------
        //Func<string, string> func;
        //func = Boo1;
        //func += Boo2;
        //func += Boo3;
        //func += Boo4;

        //func.Invoke("uzbekistan");
        ////-------------------------
        //Action<string, int> action;
        //action = Foo1;
        //action += Foo2;
        //action += Foo3;
        //action += Foo4;

        //action.Invoke("uzbekistan", 2);
    }
    static void Foo1(string s, int n)
    {
        Console.WriteLine(s.Substring(0, n));
    }
    static void Foo2(string s, int n)
    {
        Console.WriteLine(s.Substring(s.Length-1));
    }
    static void Foo3(string s, int n)
    {
        Console.WriteLine(s.Substring(s.Length/2, n));
    }
    static void Foo4(string s, int n)
    {
        Console.WriteLine(s);
    }
    //-------------------------------------
    static string Boo1(string s)
    {
        return s + "1";
    }
    static string Boo2(string s)
    {
        return s + "2";
    }
    static string Boo3(string s)
    {
        return s + "3";
    }
    static string Boo4(string s)
    {
        return s + "4";
    }
    //-------------------------------------
    static bool Pred1(int numb)
    {
        return numb % 2 == 0;
    }
    static bool Pred2(int numb)
    {
        return numb % 2 != 0;
    }
    static bool Pred3(int numb)
    {
        return numb > 0;
    }
    static bool Pred4(int numb)
    {
        return numb < 0;
    }

}

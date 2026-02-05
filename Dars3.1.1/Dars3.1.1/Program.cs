namespace Dars3._1._1;

internal class Program
{
    static void Main(string[] args)
    {
        MyList myList = new MyList(5);
        myList.Add(77);
        myList.Add(71);
        myList.Add(73);
        myList.Add(11);
        myList.Add(77);
        Console.WriteLine(myList.RemoveAt(0));
        myList.DisplayElements();




        //MyList myList = new MyList(2);
        //Console.WriteLine(myList.Capacity);
        //myList.Add(45);
        //myList.Add(88);
        //Console.WriteLine(myList.Capacity);
        //myList.Add(44);
        //Console.WriteLine(myList.Capacity);
        //Console.WriteLine(myList.GetById(0));
        //Console.WriteLine(myList.GetById(1));
        //Console.WriteLine(myList.GetById(2));
        Console.WriteLine("Hello, World!");

    }
}

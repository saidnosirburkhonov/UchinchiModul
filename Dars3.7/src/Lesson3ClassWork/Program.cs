namespace Lesson3ClassWork;

public class Program
{
    static void Main(string[] args)
    {

        //var books = new List<Book>();


        //Func<int, int, int, int> foo1 = (a, b, c) => Math.Max(a, Math.Max(b, c));


        //var foo2 = (string s1, string s2) => Console.WriteLine(s1.Length + s2.Length);


        //Func<List<Book>, Book> foo3 = (List<Book> books) =>
        //{
        //    return books.MaxBy(books => books.Price);
        //};


        //Action<Book> foo4 = (b) =>
        //{
        //    Console.WriteLine(b.Price = b.Price * 10);
        //};

        //-----------------------------------Task1--------------------------

        Func<User, string> task1 = (User user) => user.Age >= 18 ? "Adult" : "Minor";
  
        //-----------------------------------Task2--------------------------

        Action<Car> task2 = (Car car) => Console.WriteLine(2026 - car.Year);

        //-----------------------------------Task3--------------------------

        Func<List<Product>, Product> task3 = (List<Product> products) => products.MinBy(p => p.Price);

        //-----------------------------------Task4--------------------------

        Action<Order> task4 = (Order order) => Console.WriteLine(order.Price * order.Quantity);

        //-----------------------------------Task5--------------------------

        Func<List<Student>, List<Student>> task5 = (List<Student> students) => students.Where(g => g.Grade > 90).ToList();

        //-----------------------------------Task6--------------------------

        Func<Employee, decimal> task6 = (Employee employee) => employee.Salary += (employee.Salary / 100) * 15;

        //-----------------------------------Task7--------------------------

        Func<string, int> task7 = (string text) =>
        {
            var count = 0;
            foreach (var t in text)
            {
                if ("aAoOUuIiEe".Contains(t))
                {
                    ++count;
                }
            }
            return count;
        };

        //-----------------------------------Task8--------------------------

        Action<int, int> task8 = (int num1, int num2) => Console.WriteLine(Math.Max(num1, num2));

        //-----------------------------------Task9--------------------------

        Func<int, bool> task9 = (int num) => num % 2 == 0 ? true : false;

        //-----------------------------------Task10--------------------------

        Func<string, string> task10 = (string text) => (string)text.Reverse();
    }
}

public class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }
}

public class Student
{
    public string Name { get; set; }
    public int Grade { get; set; }
}
public class Order
{
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}
public class Car
{
    public string Model { get; set; }
    public int Year { get; set; }
}
public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
}
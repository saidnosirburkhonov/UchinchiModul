using System.Text.Json;

namespace Dars3._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = "D:\\Coding\\DotNet\\UchinchiModul\\Dars3.3\\Dars3.3\\salom.txt";
            var ex = File.Create(path);
            //ex.Close();
            //File.WriteAllText(path, "hello world");


            File.Delete(path);
            //File.Delete(path);\
            var json = JsonSerializer.Serialize("sds");
            var js = JsonSerializer.Deserialize(json);

        }
    }
}

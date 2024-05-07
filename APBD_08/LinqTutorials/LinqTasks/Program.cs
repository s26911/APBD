using LinqTasks.Models;

namespace LinqTasks;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("======= ZAD X =======");

        IEnumerable<object> result = Tasks.Task10();

        foreach (Emp emp in result)
        {
            Console.WriteLine(emp);
        }
    }
}
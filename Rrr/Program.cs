namespace Rrr;
internal class Program
{
    static void Main(string[] args)
    {
        var list = new List<int>();
        for(int i = 0; i < 100 ; i++)
            list.Add(i);
        var iterator = new SomeIterator<int>(list.ToArray());
        foreach(var a in iterator.MyWhere(x => x % 5 == 0))
            Console.Write(a + " ");
        Console.WriteLine();
        foreach (var a in iterator.MyTake(10))
            Console.Write(a + " ");
    }
}
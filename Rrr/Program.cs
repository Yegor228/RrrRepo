namespace Rrr;
internal class Program
{
    static void Main(string[] args)
    {

        SomeIterator some = new SomeIterator(GetEnumaration());
        
        foreach(var a in some.MyWhere(p => p % 2 == 0).MyTake(1))
            Console.WriteLine(a);

    }

    public static IEnumerable<int> GetEnumaration()
    {
        int i = 0;
        while (true)
        {
            yield return i++;
        }
    }
}
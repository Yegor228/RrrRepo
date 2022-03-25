namespace Rrr;
internal class Program
{
    static void Main(string[] args)
    {
        foreach(var a in GetEnum().MyWhere(p => p % 2 == 0).MyTake(10))
            Console.WriteLine(a);

    }

    public static MyIterator GetEnum()
    {
        var tmp = new MyIterator();
        while (true)
        {
            tmp.Add(0); 
            return tmp;
        }
    }
}
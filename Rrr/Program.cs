namespace Rrr;
internal class Program
{
    static void Main(string[] args)
    {

        MyEnumerator myEnum = new MyEnumerator(GetEnumaration());

        foreach(var a in myEnum.MyWhere(p => p % 2 == 0).MyTake(10))
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
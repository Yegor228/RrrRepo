namespace Rrr;

internal class MyIterator
{
    public int value;
    private Predicate<int> _predicate;
    public int flag = 0;
    public int takeCount = -1;
    public int takeTmp = 0;

    public int Current => value;


    public void Dispose()
    { Console.WriteLine("Dispose!"); }

    public MyIterator GetEnumerator()
    {
        return this;
    }

    public void Add(int val)
    {
        value = val;
    }

    public bool MoveNext()
    {
        switch (flag)
        {
            case 0:
                while (takeTmp != takeCount)
                {
                    takeTmp++;
                    value++;
                    return true;
                }
                return false;
            case 1:
                while (takeTmp != takeCount)
                {
                    value++;
                    var tmp = Current;
                    if (_predicate(tmp))
                    {
                        takeTmp++;
                        return true;
                    }
                }
                return false;
        }
        return false;

    }

    public void Reset()
    {
        value = default(int);
    }

    public MyIterator MyWhere(Predicate<int> predicate)
    {
        _predicate = predicate;
        flag = 1;
        return this;
    }

    public MyIterator MyTake(int num)
    {
        takeCount = num;
        return this;
    }
}


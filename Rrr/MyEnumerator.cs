using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rrr
{
    internal class MyEnumerator
    {
        public IEnumerator<int> IE;
        public int Value;
        private Predicate<int>? _predicate;
        public int Current => Value;

        public int flag;
        public int takeCount = -1;
        public int takeTmp = 0;

        public void Dispose()
        { Console.WriteLine("Dispose!"); }

        public MyEnumerator GetEnumerator()
        {
            return this;
        }

        public MyEnumerator(IEnumerable<int> iE)
        {
            IE = iE.GetEnumerator();
        }

        public bool MoveNext()
        {

            switch (flag)
            {
                case 0:
                    while (IE.MoveNext() && takeTmp != takeCount)
                    {
                        Value = IE.Current;
                        takeTmp++;
                        return true;
                    }
                    return false;
                case 1:
                    while (IE.MoveNext() && takeTmp != takeCount)
                    {
                        var tmp = IE.Current;
                        if (_predicate(tmp))
                        {
                            Value = tmp;
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
            Value = default(int);
        }

        public MyEnumerator MyWhere(Predicate<int> predicate)
        {
            _predicate = predicate;
            flag = 1;
            return this;
        }

        public MyEnumerator MyTake(int num)
        {
            takeCount = num;
            return this;
        }
    }
}

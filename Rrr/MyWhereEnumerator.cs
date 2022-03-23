using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rrr
{
    internal class MyWhereEnumerator<T> : MyIterator<T>
    {

        Predicate<T> Predicate;

        public MyWhereEnumerator(SomeIterator<T> sI, Predicate<T> predicate)
        {
            Predicate = predicate;
            SI = sI;
            Index = -1;
        }

        public bool MoveNext()
        {
            while(Index < SI.EndingPoint - 1)
            {
                Index++;
                var tmp = Current;  
                if (Predicate(tmp)) 
                    return true;     
            }
            return false;
        }

        public MyWhereEnumerator<T> GetEnumerator()
        {
            return new MyWhereEnumerator<T>(SI,Predicate);
        }

    }
}
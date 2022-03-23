using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rrr
{
    internal class SomeIteratorEnumerator<T> : MyIterator<T>
    {
        public SomeIteratorEnumerator(SomeIterator<T> sI)
        {
            SI = sI;
            Index = -1;
        }

        public bool MoveNext()
        {
            if (Index != SI.EndingPoint)
                Index++;
            return Index < SI.EndingPoint;
        }

        public SomeIteratorEnumerator<T> GetEnumerator()
        {
            return new SomeIteratorEnumerator<T>(SI);
        }
    }
}

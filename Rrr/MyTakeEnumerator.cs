using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rrr
{
    internal class MyTakeEnumerator<T> :MyIterator<T>
    {
        int Len;
        public MyTakeEnumerator(SomeIterator<T> sI, int len)
        {
            SI = sI;
            Index = -1;
            try
            { 
                if(len < 0 || len > SI.Length())
                    throw new ArgumentOutOfRangeException($"{len}: not valid");
            }
            catch
            {
                throw;
            }
            Len = len;
            SI.EndingPoint = len;
        }

        public MyTakeEnumerator<T> GetEnumerator()
        {
            return new MyTakeEnumerator<T>(SI, Len);
        }

        public virtual bool MoveNext()
        {
            if (Index != SI.EndingPoint)
                Index++;
            return Index < SI.EndingPoint;
        }
    }
}

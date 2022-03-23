using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rrr
{
    internal class MyIterator<T>
    {
        public SomeIterator<T> SI;
        public int Index;
        public MyWhereEnumerator<T> MWE;

        public T Current
        {
            get
            {
                int pos = Index + SI.StartingPoint;
                pos = pos % SI.Length();
                return SI[pos];
            }
        }

        public void Reset()
        {
            Index = -1;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
                return;
            disposing = true;
        }
    }
}

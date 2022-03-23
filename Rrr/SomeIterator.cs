using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rrr
{
    internal class SomeIterator<T>
    {
        private T[] _Arr;
        public int StartingPoint = 0;
        public int EndingPoint { get; set; }

        public SomeIterator(T[] arr)
        {
            _Arr = arr;
            EndingPoint = Length();
        }

        public int Length() => _Arr.Length;

        public T this[int index]
        {
            get => _Arr[index];
            set => _Arr[index] = value;
        }

        public MyWhereEnumerator<T> MyWhere(Predicate<T> predicate)
        {
            return GetEnumerator(predicate);
        }

        public MyTakeEnumerator<T> MyTake(int len)
        {
            return GetEnumerator(len);
        }

        public MyWhereEnumerator<T> GetEnumerator(Predicate<T> predicate)
        {
            return new MyWhereEnumerator<T>(this, predicate);
        }

        public MyTakeEnumerator<T> GetEnumerator(int len)
        {
            return new MyTakeEnumerator<T>(this, len);
        }

        public SomeIteratorEnumerator<T> GetEnumerator()
        {
            return new SomeIteratorEnumerator<T>(this);
        }
    }
}

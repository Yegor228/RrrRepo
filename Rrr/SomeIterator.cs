using System.Collections;

namespace Rrr
{
    internal class SomeIterator : IEnumerator<int>, IEnumerable<int>
    {
        private IEnumerator<int>? _iterator;
        private int _value;

        public int Current => _value;
        object IEnumerator.Current => Current;

        public SomeIterator(IEnumerable<int> iterator)
        {
            _iterator = iterator.GetEnumerator();
        }

        public SomeIterator(){ }

        public virtual bool MoveNext()
        {
            if(_iterator != null)
            {
                while (_iterator.MoveNext())
                {
                    _value = _iterator.Current;
                    return true;
                }
            }  
            return false;
        }
        public IEnumerator<int> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public void Dispose()
        { Console.WriteLine("Dispose"); }

        public void Reset()
        { throw new NotImplementedException(); }

        public WhereSomeIterator MyWhere(Predicate<int> predicate)
        { return new WhereSomeIterator(this, predicate); }

        public TakeSomeIterator MyTake(int count)
            { return new TakeSomeIterator(this, count); }

    }
}

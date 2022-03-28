using System.Collections;

namespace Rrr
{
    internal class WhereSomeIterator : IEnumerator<int>, IEnumerable<int>
    {
        private Predicate<int> _predicate;
        private int _value;
        private IEnumerator<int> _whereIterator;

        public int Current => _value;
        object IEnumerator.Current => Current;

        public WhereSomeIterator(IEnumerable<int> iterator, Predicate<int> predicate)
        {
            _whereIterator = iterator.GetEnumerator();
            _predicate = predicate;
        }
        public bool MoveNext()
        {
            while (_whereIterator.MoveNext())
            {
                if (_predicate(_whereIterator.Current))
                {
                    _value = _whereIterator.Current;
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<int> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        public void Dispose()
        { Console.WriteLine("Dispose!"); }
        public void Reset()
        { throw new NotImplementedException(); } 
        public TakeSomeIterator MyTake(int count) => new TakeSomeIterator(this, count);

    }
}

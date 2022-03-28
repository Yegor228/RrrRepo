using System.Collections;


namespace Rrr
{
    internal class TakeSomeIterator : IEnumerator<int>, IEnumerable<int>
    {
        private int _value;
        private int _count;
        private int _tmp;
        private IEnumerator<int> _takeIterator;

        public int Current => _value;
        object IEnumerator.Current => Current;

        public TakeSomeIterator(IEnumerable<int> iterator, int count)
        {
            _takeIterator = iterator.GetEnumerator();
            _count = count;
        }
        public bool MoveNext()
        {
            while (_takeIterator.MoveNext() && _tmp < _count)
            {
                _value = _takeIterator.Current;
                _tmp++;
                return true;
            }
            return false;
        }
        public IEnumerator<int> GetEnumerator() => this;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public void Dispose()
        { Console.WriteLine("Dispose!"); }
        public void Reset()
        { throw new NotImplementedException(); }
    }
}

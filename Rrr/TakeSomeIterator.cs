using System.Collections;


namespace Rrr
{
    internal class TakeSomeIterator : SomeIterator, IEnumerator<int>, IEnumerable<int>
    {
        private int _value;
        private int _count;
        private int _tmp;
        private IEnumerator<int> _takeIterator;

        public new int Current => _value;
        object IEnumerator.Current => Current;

        public TakeSomeIterator(IEnumerable<int> iterator, int count)
        {
            _takeIterator = iterator.GetEnumerator();
            _count = count;
        }
        public override bool MoveNext()
        {
            while (_takeIterator.MoveNext() && _tmp < _count)
            {
                _value = _takeIterator.Current;
                _tmp++;
                return true;
            }
            return false;
        }
    }
}

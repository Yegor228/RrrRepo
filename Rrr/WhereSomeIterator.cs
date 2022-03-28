using System.Collections;

namespace Rrr
{
    internal class WhereSomeIterator : SomeIterator, IEnumerator<int>, IEnumerable<int>
    {
        private Predicate<int> _predicate;
        private int _value;
        private IEnumerator<int> _whereIterator;

        public new int Current => _value;
        object IEnumerator.Current => Current;

        public WhereSomeIterator(IEnumerable<int> iterator, Predicate<int> predicate)
        {
            _whereIterator = iterator.GetEnumerator();
            _predicate = predicate;
        }
        public override bool MoveNext()
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

    }
}

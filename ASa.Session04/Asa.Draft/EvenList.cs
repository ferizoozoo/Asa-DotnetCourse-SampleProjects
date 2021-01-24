using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Asa.Draft
{
    public class EvenList : IEnumerable<int>
    {

        List<int> _backList;
        EvenListEnumerator evenListEnumerator;
        public EvenList()
        {
            _backList = new List<int>();
            evenListEnumerator = new EvenListEnumerator(this);
        }
        public EvenList Add(int item)
        {
            _backList.Add(item);
            return this;
        }
        //public this[int indx]
        //{
        //    get { };
        //    set
        //    {

        //    }
        //}

        public int GetItemAt(int indx) => _backList[indx];

        public IEnumerator<int> GetEnumerator() => evenListEnumerator;

        IEnumerator IEnumerable.GetEnumerator() => evenListEnumerator;
        public int Count => _backList.Count;
    }
    class EvenListEnumerator : IEnumerator<int>
    {
        EvenList _evenList;
        int _currentIndex = -2;

        public EvenListEnumerator(EvenList evenList)
        {
            _evenList = evenList;
        }
        public int Current => _evenList.GetItemAt(_currentIndex);

        object IEnumerator.Current => _evenList.GetItemAt(_currentIndex);

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            _currentIndex += 2;
            return _currentIndex < _evenList.Count;
        }

        public void Reset()
        {
            _currentIndex = 0;
        }
    }

}

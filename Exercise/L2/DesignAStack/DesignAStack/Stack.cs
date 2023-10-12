using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignAStack
{
    internal class Stack
    {
        private readonly List<object> _list = new List<object>();

        public Stack()
        {
            Console.WriteLine("Stack is created!");
        }
        public void Push(object obj)
        {
            if (obj == null)
                throw new InvalidOperationException("Cannot add null to stack.");

            _list.Add(obj);
        }

        public object Pop()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("Cannot pop from an empty stack.");

            var lastIndex = _list.Count - 1;
            var lastItem = _list[lastIndex];
            _list.RemoveAt(lastIndex);

            return lastItem;
        }

        public void Clear()
        {
            _list.Clear();
        }
    }
}

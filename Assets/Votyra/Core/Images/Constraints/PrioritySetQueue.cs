using System;
using System.Collections.Generic;
using System.Linq;

namespace Votyra.Core.Images.Constraints
{
    public class PrioritySetQueue<TValue, TPriority>
    {
        private readonly IComparer<TPriority> _priorityOrderComparer;
        private readonly LinkedList<PrioritisedValue> _queue;
        private readonly IEqualityComparer<TValue> _valueEqualityComparer;

        public PrioritySetQueue(IEnumerable<TValue> values, IEqualityComparer<TValue> valueEqualityComparer, Func<TValue, TPriority> getPriority, IComparer<TPriority> priorityOrderComparer)
        {
            _priorityOrderComparer = priorityOrderComparer;
            _valueEqualityComparer = valueEqualityComparer;
            _queue = new LinkedList<PrioritisedValue>(values.Select(cell => new PrioritisedValue(cell, getPriority(cell)))
                .OrderBy(cell => cell.Priority, priorityOrderComparer));
        }

        public PrioritySetQueue(IEqualityComparer<TValue> valueEqualityComparer, IComparer<TPriority> priorityOrderComparer)
        {
            _priorityOrderComparer = priorityOrderComparer;
            _valueEqualityComparer = valueEqualityComparer;
            _queue = new LinkedList<PrioritisedValue>();
        }

        public int Count => _queue.Count;

        public PrioritisedValue GetFirst()
        {
            var cellWithValue = _queue.First.Value;
            _queue.RemoveFirst();

            return cellWithValue;
        }

        public void Add(TValue newCellToCheck, TPriority newCellToCheckValue)
        {
            var addded = false;
            var node = _queue.First;
            while (node != null)
            {
                var isOldToRemove = _valueEqualityComparer.Equals(node.Value.Value, newCellToCheck);
                var isNewToBeAddedBeforeCurrent = _priorityOrderComparer.Compare(node.Value.Priority, newCellToCheckValue) > 0 && !addded; //node.Value.Value < newCellToCheckValue && !addded;

                if (isOldToRemove && isNewToBeAddedBeforeCurrent)
                {
                    node.Value = new PrioritisedValue(newCellToCheck, newCellToCheckValue);
                    addded = true;
                    break;
                }

                if (isOldToRemove)
                {
                    _queue.Remove(node);
                }
                else if (isNewToBeAddedBeforeCurrent)
                {
                    _queue.AddBefore(node, new PrioritisedValue(newCellToCheck, newCellToCheckValue));
                    addded = true;
                }

                node = node.Next;
            }

            if (!addded)
                _queue.AddLast(new PrioritisedValue(newCellToCheck, newCellToCheckValue));
        }

        public struct PrioritisedValue
        {
            public readonly TValue Value;
            public readonly TPriority Priority;

            public PrioritisedValue(TValue pos, TPriority value)
            {
                Value = pos;
                Priority = value;
            }
        }
    }
}
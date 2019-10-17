using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericQueue
{
    /// <summary>
    /// Generic Queue.
    /// </summary>
    /// <typeparam name="T">The type.</typeparam>
    /// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
    public class Queue<T> : IEnumerable<T>, IEnumerable
    {
        private T[] _array;
        private int _head;       // First valid element in the queue
        private int _tail;       // Last valid element in the queue
        private int _size;       // Number of elements.
        private int _version;

        private const int _DefaultCapacity = 4;
        static T[] _emptyArray = new T[0];
                     
        /// <summary>
        /// Creates a queue with room for capacity objects. 
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        public Queue()
        {
            _array = _emptyArray;
        }

        /// <summary>
        /// Creates a queue with room for capacity objects.
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        /// <param name="capacity">The capacity.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Need non negative capacity.</exception>
        public Queue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException($"Need non negative {nameof(capacity)}.");
            }

            _array = new T[capacity];
            _head = 0;
            _tail = 0;
            _size = 0;
        }
       
        /// <summary>
        /// Fills a Queue with the elements of an ICollection.
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <exception cref="System.ArgumentNullException">Throws when collection is null.</exception>
        public Queue(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException($"{nameof(collection)} can't be null.");
            }

            _array = new T[_DefaultCapacity];
            _size = 0;
            _version = 0;

            using (IEnumerator<T> en = collection.GetEnumerator())
            {
                while (en.MoveNext())
                {
                    Enqueue(en.Current);
                }
            }
        }

        /// <summary>
        /// Adds item to the tail of the queue.  
        /// </summary>
        /// <param name="item">The item.</param>
        public void Enqueue(T item)
        {
            if (_size == _array.Length)
            {
                int newcapacity = _array.Length * 2;
                SetCapacity(newcapacity);
            }

            _array[_tail] = item;
            _tail = (_tail + 1) % _array.Length;
            _size++;
            _version++;
        }
                     
        /// <summary>
        ///  Removes the object at the head of the queue and returns it.
        /// </summary>
        /// <returns>
        ///  Returns the object at the head of the queue.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">Queue is empty.</exception>
        public T Dequeue()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T removed = _array[_head];
            _array[_head] = default(T);
            _head = (_head + 1) % _array.Length;
            _size--;
            _version++;
            return removed;
        }
       
        /// <summary>
        /// Returns the object at the head of the queue. The object remains in the queue.
        /// </summary>
        /// <returns>Returns the object at the head of the queue.</returns>
        /// <exception cref="System.InvalidOperationException">Queue is empty.</exception>
        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return _array[_head];
        }

        /// <summary>
        /// Removes all Objects from the queue.
        /// </summary>
        public void Clear()
        {
            if (_head < _tail)
                Array.Clear(_array, _head, _size);
            else
            {
                Array.Clear(_array, _head, _array.Length - _head);
                Array.Clear(_array, 0, _tail);
            }

            _head = 0;
            _tail = 0;
            _size = 0;
            _version++;
        }
      
        /// <summary>
        /// Determines whether this instance contains the object.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        ///   <c>true</c> if [contains] if the queue contains at least one object equal to item; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Throws if item is null.</exception>
        public bool Contains(T item)
        {
            int index = _head;
            int count = _size;

            while (count-- > 0)
            {
                if (item == null && _array[index] == null)
                {
                    return true;
                }
                else if (_array[index] != null && Equals(_array[index], item))
                {
                    return true;
                }

                index = (index + 1) % _array.Length;
            }

            return false;
        }

        /// <summary>
        /// Iterates over the objects in the queue, returning an array of the
        /// objects in the Queue, or an empty array if the queue is empty.
        /// </summary>
        /// <returns>
        /// Returns an array of the objects in the Queue, or an empty array if the queue is empty.
        /// </returns>
        public T[] ToArray()
        {
            T[] arr = new T[_size];
            if (_size == 0)
                return arr;

            if (_head < _tail)
            {
                Array.Copy(_array, _head, arr, 0, _size);
            }
            else
            {
                Array.Copy(_array, _head, arr, 0, _array.Length - _head);
                Array.Copy(_array, 0, arr, _array.Length - _head, _tail);
            }

            return arr;
        }
      
        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="System.Collections.IEnumerator"></see> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        /// <summary>
        /// Gets the element by index.
        /// </summary>
        /// <param name="i">The index.</param>
        /// <returns>Returns the element.</returns>
        internal T GetElement(int i)
        {
            return _array[(_head + i) % _array.Length];
        }
     
        /// <summary>
        /// Grows the buffer to hold capacity objects.
        /// </summary>
        /// <param name="capacity">The capacity.</param>
        /// <exception cref="System.ArgumentException">Throws when capasity < _size.</exception>
        private void SetCapacity(int capacity)
        {
            if (capacity < _size)
            {
                throw new ArgumentException($"{nameof(capacity)} must be >= queue size.");
            }

            T[] newarray = new T[capacity];
            if (_size > 0)
            {
                if (_head < _tail)
                {
                    Array.Copy(_array, _head, newarray, 0, _size);
                }
                else
                {
                    Array.Copy(_array, _head, newarray, 0, _array.Length - _head);
                    Array.Copy(_array, 0, newarray, _array.Length - _head, _tail);
                }
            }

            _array = newarray;
            _head = 0;
            _tail = (_size == capacity) ? 0 : _size;
            _version++;
        }

        //--------------------------------------------------------------------------------------

        /// <summary>
        /// The Enumerator of the Queue<T>.
        /// </summary>
        /// <seealso cref="System.Collections.Generic.IEnumerable{T}" />
        public struct Enumerator : IEnumerator<T>, IEnumerator
        {
            private Queue<T> _q;
            private int _index;   // -1 = not started, -2 = ended/disposed
            private readonly int _version;
            private T _currentElement;

            /// <summary>
            /// Initializes a new instance of the <see cref="Enumerator"/> struct.
            /// </summary>
            /// <param name="q">The q.</param>
            internal Enumerator(Queue<T> q)
            {
                _q = q;
                _version = _q._version;
                _index = -1;
                _currentElement = default(T);
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                _index = -2;
                _currentElement = default(T);
            }

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            /// <returns>
            /// true if the enumerator was successfully advanced to the next element; 
            /// false if the enumerator has passed the end of the collection.
            /// </returns>
            /// <exception cref="System.InvalidOperationException">Enum failed version.</exception>
            public bool MoveNext()
            {
                if (_version != _q._version)
                {
                    throw new InvalidOperationException("Enum failed version.");
                }

                if (_index == -2)
                {
                    return false;
                }

                _index++;

                if (_index == _q._size)
                {
                    _index = -2;
                    _currentElement = default(T);
                    return false;
                }

                _currentElement = _q.GetElement(_index);
                return true;
            }

            /// <summary>Gets the current.</summary>
            /// <value>The current.</value>
            /// <exception cref="System.InvalidOperationException">
            /// Enum not started or enum ended.
            /// </exception>
            public T Current
            {
                get
                {
                    if (_index < 0)
                    {
                        if (_index == -1)
                        {
                            throw new InvalidOperationException("Enum not started.");
                        }

                        throw new InvalidOperationException("Enum ended.");
                    }

                    return _currentElement;
                }
            }

            /// <summary>Gets the current.</summary>
            /// <value>The current.</value>
            /// <exception cref="System.InvalidOperationException">
            /// Enum not started or enum ended.
            /// </exception>
            Object IEnumerator.Current
            {
                get
                {
                    if (_index < 0)
                    {
                        if (_index == -1)
                        {
                            throw new InvalidOperationException("Enum not started.");
                        }

                        throw new InvalidOperationException("Enum ended.");
                    }

                    return _currentElement;
                }
            }

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>
            /// <exception cref="System.InvalidOperationException">Enum failed version.</exception>
            void IEnumerator.Reset()
            {
                if (_version != _q._version)
                {
                    throw new InvalidOperationException("Enum failed version.");
                }

                _index = -1;
                _currentElement = default(T);
            }
        }
    }
}

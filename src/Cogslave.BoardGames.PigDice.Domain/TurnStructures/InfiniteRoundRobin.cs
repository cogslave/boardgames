using System;

namespace Cogslave.BoardGames.PigDice.Domain.TurnStructures
{
    public class InfiniteRoundRobin<T> : INext<T>
    {
        private readonly T[] _elements;
        private int _current;

        public InfiniteRoundRobin(T[] elements)
        {
            if (elements == null) throw new ArgumentNullException(nameof(elements));
            if (elements.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(elements));

            _elements = elements;
        }

        public T Next()
        {
            return _elements[_current++ % _elements.Length];
        }
    }
}
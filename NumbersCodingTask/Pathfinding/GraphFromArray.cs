using System;
using System.Collections.Generic;
using System.Linq;

namespace NumbersCodingTask.Pathfinding
{
    public class GraphFromArray : IGraph
    {
        private readonly int[] _numbers;

        public GraphFromArray(int[] numbers)
        {
            _numbers = numbers;
        }

        public bool IsEmpty()
        {
            return _numbers.Length == 0;
        }

        public IEnumerable<IGraphNode> Nodes()
        {
            return _numbers.Select((_, index) => new GraphNodeFromArray(_numbers, index));
        }

        public IGraphNode Start()
        {
            return new GraphNodeFromArray(_numbers, 0);
        }

        public IGraphNode Finish()
        {
            return new GraphNodeFromArray(_numbers, _numbers.Length - 1);
        }

        private class GraphNodeFromArray : IGraphNode
        {
            private readonly int[] _numbers;
            private readonly int _index;

            public GraphNodeFromArray(int[] numbers, int index)
            {
                _numbers = numbers;
                _index = index;
            }

            public string Name()
            {
                return $"[{_index}]";
            }

            public IEnumerable<IGraphNode> Neighbors()
            {
                int steps = Value();
                if (steps == 0)
                {
                    yield break;
                }

                // NOTE: "min" can exceed "max" for cases when there are no neighbors.
                // No "for" loop iterations will occur. This is by design.
                (int min, int max) = NeighborIndexRange(steps);
                for (int i = min; i <= max; i++)
                {
                    yield return new GraphNodeFromArray(_numbers, i);
                }
            }

            private (int LeftmostNeighborIndex, int RightmostNeighborIndex) NeighborIndexRange(int steps)
            {
                int EnsureIndexNotTooLarge(int index) => Math.Min(index, _numbers.Length - 1);
                int EnsureIndexNotTooSmall(int index) => Math.Max(index, 0);

                return steps > 0
                    ? (_index + 1, EnsureIndexNotTooLarge(_index + steps))
                    : (EnsureIndexNotTooSmall(_index + steps), _index - 1);
            }

            private int Value()
            {
                return _numbers[_index];
            }

            public bool Equals(IGraphNode other)
            {
                // ReSharper disable once PossibleNullReferenceException - NOTE: "null" value ignored on purpose.
                return Name() == other.Name();
            }

            public override bool Equals(object obj)
            {
                return Equals((IGraphNode)obj);
            }

            public override int GetHashCode()
            {
                return Name().GetHashCode();
            }

            public override string ToString()
            {
                return $"{Name()}: {Value()}";
            }
        }
    }
}

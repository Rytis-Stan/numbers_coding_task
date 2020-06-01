using NumbersCodingTask.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace NumbersCodingTask.Pathfinding
{
    public class PathFinder : IPathFinder
    {
        private const int DistanceIncrement = 1;

        public IMaybe<IPath> ShortestPathFor(IGraph graph)
        {
            List<IGraphNode> nodes = graph.Nodes().ToList();

            Dictionary<IGraphNode, int> distanceTo = nodes.ToDictionary(node => node, node => DefaultDistanceToNode(graph, node));
            Dictionary<IGraphNode, IMaybe<IGraphNode>> previousNodeFor = nodes.ToDictionary(node => node, node => Maybe.None<IGraphNode>());

            foreach (IGraphNode node in nodes)
            {
                IGraphNode[] neighbors = node.Neighbors().ToArray();
                foreach (IGraphNode neighbor in neighbors)
                {
                    int newDistance = distanceTo[node] + DistanceIncrement;
                    int distanceToNeighbor = distanceTo[neighbor];
                    if (newDistance < distanceToNeighbor)
                    {
                        distanceTo[neighbor] = newDistance;
                        previousNodeFor[neighbor] = Maybe.Just(node);
                    }
                }
            }

            return BuildPath(graph, previousNodeFor);
        }

        private IMaybe<IPath> BuildPath(IGraph graph, Dictionary<IGraphNode, IMaybe<IGraphNode>> previousNodeFor)
        {
            bool pathExists = PathExists(graph, previousNodeFor);
            return pathExists
                ? Maybe.Just<IPath>(new Path(graph, previousNodeFor))
                : Maybe.None<IPath>();
        }

        private bool PathExists(IGraph graph, Dictionary<IGraphNode, IMaybe<IGraphNode>> previousNodeFor)
        {
            if (!graph.IsEmpty())
            {
                IGraphNode finish = graph.Finish();
                return previousNodeFor[finish].HasValue() || finish.Equals(graph.Start());
            }
            return false;
        }

        private int DefaultDistanceToNode(IGraph graph, IGraphNode node)
        {
            // NOTE: using a huge value that is expected to always be larger than any other distance in practice,
            // thus causing actual calculated distances to always overwrite this big value. A value for representing
            // infinity would be great to use, but "int" data type does not support any such value (unlike "float" and "double" types).
            const int fakeInfinity = int.MaxValue - DistanceIncrement;
            return graph.Start().Equals(node) ? 0 : fakeInfinity;
        }

        private class Path : IPath
        {
            private readonly IGraph _graph;
            private readonly Dictionary<IGraphNode, IMaybe<IGraphNode>> _previousNodeFor;

            public Path(IGraph graph, Dictionary<IGraphNode, IMaybe<IGraphNode>> previousNodeFor)
            {
                _graph = graph;
                _previousNodeFor = previousNodeFor;
            }

            public IEnumerable<IGraphNode> Nodes()
            {
                return BackwardNodes().Reverse();
            }

            private IEnumerable<IGraphNode> BackwardNodes()
            {
                IMaybe<IGraphNode> node = Maybe.Just(_graph.Finish());
                do
                {
                    yield return node.Value();
                    node = _previousNodeFor[node.Value()];

                } while (node.HasValue());
            }
        }
    }
}

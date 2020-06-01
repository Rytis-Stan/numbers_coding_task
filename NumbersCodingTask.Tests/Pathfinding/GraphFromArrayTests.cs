using System.Collections.Generic;
using System.Linq;
using NumbersCodingTask.Pathfinding;
using NUnit.Framework;

namespace NumbersCodingTask.Tests.Pathfinding
{
    [TestFixture]
    public class GraphFromArrayTests
    {
        [Test]
        public void IsEmptyWhenNoNodesProvided()
        {
            Assert.That(
                 new GraphFromArray(new int[0]).IsEmpty(),
                 Is.True
            );
        }

        [TestCase(new[] { 0 })]
        [TestCase(new[] { 0, 0 })]
        public void IsNotEmptyWhenHasAtLeastOneNode(int[] numbers)
        {
            Assert.That(
                new GraphFromArray(numbers).IsEmpty(),
                Is.False
            );
        }

        [TestCase(new[] { 0 }, new[] { "[0]" })]
        [TestCase(new[] { 0, 0 }, new[] { "[0]", "[1]" })]
        [TestCase(new[] { 0, 1 }, new[] { "[0]", "[1]" })]
        [TestCase(new[] { 1, 1 }, new[] { "[0]", "[1]" })]
        [TestCase(new[] { 1, 1, 1 }, new[] { "[0]", "[1]", "[2]" })]
        public void NodesMatchArrayElementsInSameOrder(int[] numbers, string[] expectedNodeNames)
        {
            Assert.That(
                NodeNames(new GraphFromArray(numbers).Nodes()),
                Is.EqualTo(expectedNodeNames)
            );
        }

        [TestCase(new[] { 0 })]
        [TestCase(new[] { 0, 0 })]
        public void StartMatchesFirstExistingNode(int[] numbers)
        {
            IGraph graph = new GraphFromArray(numbers);
            Assert.That(
                graph.Start(),
                Is.EqualTo(graph.Nodes().First())
            );
        }

        [TestCase(new[] { 0 })]
        [TestCase(new[] { 0, 0 })]
        public void FinishMatchesLastExistingNode(int[] numbers)
        {
            IGraph graph = new GraphFromArray(numbers);
            Assert.That(
                graph.Finish(),
                Is.EqualTo(graph.Nodes().Last())
            );
        }

        [TestCase(new[] { 0 }, 0, new string[0])]
        [TestCase(new[] { 0, 0 }, 0, new string[0])]
        [TestCase(new[] { 1, 0 }, 0, new[] { "[1]" })]
        [TestCase(new[] { 2, 0 }, 0, new[] { "[1]" })]
        [TestCase(new[] { 2, 0, 0 }, 0, new[] { "[1]", "[2]" })]
        [TestCase(new[] { 2, 0, 0 }, 1, new string[0])]
        [TestCase(new[] { 2, 1, 0 }, 1, new[] { "[2]" })]
        [TestCase(new[] { 2, 2, 0 }, 1, new[] { "[2]" })]
        [TestCase(new[] { 2, 2, 0, 0 }, 1, new[] { "[2]", "[3]" })]
        [TestCase(new[] { 2, 2, 0, 0, 0 }, 1, new[] { "[2]", "[3]" })]
        [TestCase(new[] { 2, -2, 0, 0, 0 }, 1, new[] { "[0]" })]
        [TestCase(new[] { 2, 0, -2, 0, 0 }, 1, new string[0])]
        [TestCase(new[] { 2, 0, -2, 0, 0 }, 2, new[] { "[0]", "[1]" })]
        [TestCase(new[] { 2, 0, -2, 0, 0 }, 4, new string[0])]
        [TestCase(new[] { 2, 0, -2, 0, 1 }, 4, new string[0])]
        [TestCase(new[] { 2, 0, -2, 0, 2 }, 4, new string[0])]
        [TestCase(new[] { -2, 0, -2, 0, -2 }, 0, new string[0])]
        public void SpecificNodeReturnsCorrectNeighbors(int[] numbers, int index, string[] expectedNeighborNames)
        {
            Assert.That(
                NodeNames(new GraphFromArray(numbers).Nodes().ElementAt(index).Neighbors()),
                Is.EqualTo(expectedNeighborNames)
            );
        }

        private string[] NodeNames(IEnumerable<IGraphNode> nodes)
        {
            return nodes.Select(x => x.Name()).ToArray();
        }
    }
}
